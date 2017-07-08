using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using System.IO;
using Microsoft.Reporting.WinForms;
using ESRI.ArcGIS.Geodatabase;


namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    //功能：以动态报表的方式实现地理要素的属性报表功能。
    //      报表的数据源为XML格式的文件，可以由当前地图图层构造DataSet，然后将其写成XML格式；
    //      报表的数据源还可以由非当前地图中的要素集和（或）要素类、shapefile构造DataSet，然后将其写成XML格式,
    //      这一功能可以使用“将地图图层输出为报表数据文件(&L)”菜单实现。
    //      本系统生成的报表可以转换为Excel、pdf两种格式。
    public partial class DynamicAttributesReport : Form
    {
        IMap m_map;
        private DataSet m_dataSet;
        private MemoryStream m_rdl;
        const string m_dataSetName = "m_layerDataSet";
        const string m_dataSourceName = "GeoDataSource";
        DataSet m_layerDataSet = new DataSet(m_dataSetName);

        string reportDirectory = System.IO.Path.GetTempPath();
        string rdlFullFilePath;

        bool displaySelectedFeatures = true;

        public DynamicAttributesReport(IMap map, bool displaySelFeatures)
        {
            InitializeComponent();
            m_map = map;
            displaySelectedFeatures = displaySelFeatures;
        }

        private void DynamicAttributesReport_Load(object sender, EventArgs e)
        {

            CreateLayersTreeView();
            SelectReportDirectory();
        }

        private void SelectReportDirectory()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                reportDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ShowReport()
        {
            this.reportViewer1.Reset();
            this.reportViewer1.ShowExportButton = true;
            this.reportViewer1.LocalReport.LoadReportDefinition(m_rdl);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(m_dataSetName, m_dataSet.Tables[0]));
            this.reportViewer1.RefreshReport();
        }

        private MemoryStream GenerateRdl(List<string> allFields, List<string> selectedFields)
        {
            MemoryStream ms = new MemoryStream();
            SpatialQueryAndAnalysis.空间查询与空间分析.RdlGenerator gen = new SpatialQueryAndAnalysis.空间查询与空间分析.RdlGenerator(m_dataSetName, m_dataSourceName);
            gen.AllFields = allFields;
            gen.SelectedFields = selectedFields;
            gen.WriteXml(ms);
            ms.Position = 0;
            return ms;
        }

        private void DumpRdl(MemoryStream rdlFile)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(rdlFullFilePath, FileMode.Create))
            {
                rdlFile.WriteTo(fs);
            }
        }
        private List<string> GetAvailableFields()
        {
            DataTable dataTable = m_dataSet.Tables[0];
            List<string> availableFields = new List<string>();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                availableFields.Add(dataTable.Columns[i].ColumnName);
            }
            return availableFields;
        }

        private void OpenDataFile(string filename, bool showOptionsDialog)
        {
            try
            {
                m_dataSet = new DataSet();
                m_dataSet.ReadXml(filename);

                List<string> allFields = GetAvailableFields();
                SpatialQueryAndAnalysis.空间查询与空间分析.ReportOptionDialog dlg = new SpatialQueryAndAnalysis.空间查询与空间分析.ReportOptionDialog(allFields);
                if (showOptionsDialog)
                {
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                }
                List<string> selectedFields = dlg.GetSelectedFields();

                if (m_rdl != null)
                    m_rdl.Dispose();
                m_rdl = GenerateRdl(allFields, selectedFields);
                DumpRdl(m_rdl);

                ShowReport();
            }
            catch
            {
                MessageBox.Show("该图层无要素！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region "CreateLayersTreeView"
        private void CreateLayersTreeView()
        {
            TreeNode rootnode = new TreeNode("图层");
            trvLayers.Nodes.Add(rootnode);
            for (int i = 0; i <= m_map.LayerCount - 1; i++)
            {
                TreeNode layerName = new TreeNode(m_map.get_Layer(i).Name);
                if (m_map.get_Layer(i) is IGroupLayer || m_map.get_Layer(i) is ICompositeLayer)
                {
                    ICompositeLayer cLayer = m_map.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j <= cLayer.Count - 1; j++)
                    {
                        TreeNode subLayerName = new TreeNode(cLayer.get_Layer(j).Name);
                        layerName.Nodes.Add(subLayerName);
                    }
                }
                rootnode.Nodes.Add(layerName);
            }
            trvLayers.Sort();
        }

        #endregion

        private void trvLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string layerName = e.Node.Text;
            IFeatureLayer featureLayer = GetLayerByName(layerName);
            if (featureLayer == null) return;

            string xmlFileName = featureLayer.Name + ".xml";
            string rdlFileName = featureLayer.Name + ".rdlc";
            string xmlFilepath = System.IO.Path.Combine(reportDirectory, xmlFileName);
            rdlFullFilePath = System.IO.Path.Combine(reportDirectory, rdlFileName);
            ConstructDataSet(featureLayer);
            m_layerDataSet.Tables[featureLayer.Name].WriteXml(xmlFilepath);
            OpenDataFile(xmlFilepath, true);
            toolStripStatusLabel1.Text = "总记录数：" + m_layerDataSet.Tables[featureLayer.Name].Rows.Count.ToString();

        }

        #region "ConstructDataSet"
        private void ConstructDataSet(IFeatureLayer pFeatLyr)
        {
            ILayerFields pFeatlyrFields;
            pFeatlyrFields = pFeatLyr as ILayerFields;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            if (m_layerDataSet.Tables[pFeatLyr.Name] == null)
            {
                DataTable pTable = new DataTable(pFeatLyr.Name);
                DataColumn pTableCol;
                for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                {
                    pTableCol = new DataColumn(pFeatlyrFields.get_Field(i).AliasName);
                    pTable.Columns.Add(pTableCol);
                    pTableCol = null;
                }
                if (displaySelectedFeatures)
                {
                    IFeatureSelection selectLayer = pFeatLyr as IFeatureSelection;
                    ISelectionSet selectionSet = selectLayer.SelectionSet;
                    IEnumIDs enumIDs = selectionSet.IDs;
                    IFeature feature;
                    int iD = enumIDs.Next();
                    while (iD != -1) //-1 is reutned after the last valid ID has been reached        
                    {
                        feature = pFeatCls.GetFeature(iD);
                        DataRow pTableRow = pTable.NewRow();
                        for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                        {
                            //pTableRow[i] = feature.get_Value(i);

                            if (pFeatlyrFields.FindField(pFeatCls.ShapeFieldName) == i)
                            {
                                pTableRow[i] = pFeatCls.ShapeType;
                            }
                            else
                            {
                                pTableRow[i] = feature.get_Value(i);
                            }
                        }
                        pTable.Rows.Add(pTableRow);
                        iD = enumIDs.Next();
                    }
                    m_layerDataSet.Tables.Add(pTable);
                }
                else
                {
                    IFeatureCursor features = pFeatLyr.Search(null, false);
                    IFeature feature = features.NextFeature();
                    while (feature != null)
                    {
                        DataRow pTableRow = pTable.NewRow();
                        for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                        {
                            //pTableRow[i] = feature.get_Value(i);

                            if (pFeatlyrFields.FindField(pFeatCls.ShapeFieldName) == i)
                            {
                                pTableRow[i] = pFeatCls.ShapeType;
                            }
                            else
                            {
                                pTableRow[i] = feature.get_Value(i);
                            }
                        }
                        pTable.Rows.Add(pTableRow);
                        feature = features.NextFeature();
                    }
                    m_layerDataSet.Tables.Add(pTable);
                }
            }
        }

        #endregion

        #region "GetLayerByName"
        private IFeatureLayer GetLayerByName(string layerName)
        {
            for (int i = 0; i <= m_map.LayerCount - 1; i++)
            {
                ILayer layer = m_map.get_Layer(i);
                if (layer != null)
                {
                    if (layer is IFeatureLayer)
                    {
                        if (((IFeatureLayer)layer).FeatureClass.AliasName == layerName)
                            return layer as IFeatureLayer;
                    }
                }
                if (layer is IGroupLayer || layer is ICompositeLayer)
                {
                    ICompositeLayer cLayer = layer as ICompositeLayer;
                    for (int j = 0; j <= cLayer.Count - 1; j++)
                    {
                        ILayer subLayer = cLayer.get_Layer(j);
                        if (((IFeatureLayer)subLayer).FeatureClass.AliasName == layerName)
                            return subLayer as IFeatureLayer;
                    }
                }
            }
            return null;
        }
        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenDataFile(openFileDialog1.FileName, true);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.ShowContextMenu = true; ;
        }

        private void saveLayerAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialQueryAndAnalysis.空间查询与空间分析.LayerDataToXML frmLayerToXML = new SpatialQueryAndAnalysis.空间查询与空间分析.LayerDataToXML();
            frmLayerToXML.Show(this as System.Windows.Forms.IWin32Window);
        }

        private void SetupReportDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectReportDirectory();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            saveFileDialog1.Filter = "Excel files|*.xls";
            string outputFile;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFile = saveFileDialog1.FileName;
                //string fileName = reportViewer1.LocalReport.DisplayName + ".xls";
                //string excelFile = System.IO.Path.Combine(reportDirectory, fileName);
                FileStream fs = new FileStream(outputFile, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                MessageBox.Show("Report exported to " + outputFile, "Info");
            }
        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            saveFileDialog1.Filter = "Acrobat PDF files|*.pdf";
            string outputFile;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFile = saveFileDialog1.FileName;
                FileStream fs = new FileStream(outputFile, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                MessageBox.Show("Report exported to " + outputFile, "Info");
            }
        }

        private void printReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
