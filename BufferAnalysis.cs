using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class BufferAnalysis : Form
    {

        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;

        double bufferDistance = 10; //缓冲距离
        string strBufferField; //缓冲字段名
        string strSideType;   //线缓冲的方向
        string strEndType;    //线末端缓冲区的封闭类型
        string strDissolveType;  //缓冲区融合类型
        IFeatureLayer featureBufferLayer;//缓冲图层
        object bufferDistanceField;
        string strDissolveFields;//缓冲区融合字段，即根据融合字段的取值进行缓冲区合并
        string strOutputPath = System.IO.Path.GetTempPath();
        string bufferedFeatureClassName;  //缓冲区要素类名

        string strBufferLayer;//缓冲图层
        double tolerance = 0.1;

        string strJoinAttributeType = "ALL";//叠置分析结果属性输出类型，即输出哪些属性字段
        string strOutputFeatureType = "INPUT";//叠置分析结果要素输出类型

        int inputLevel = 1;
        int overlayLevel = 1;


        //以下2个变量用于设置要素属性的显示与打印，displaySelectedFeatures变量设置为true时，
        //仅对要素的选择集有效； 否则对所有要素有效。
        //displayViaReport变量设置为true时，以报表方式显示或打印要素属性；
        //否则，以普通的属性表方式显示要素的属性
        public BufferAnalysis(IHookHelper hookHelper)
        {
            InitializeComponent();
            if (hookHelper == null) return;
            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;

        }

        private void BufferAnalysis_Load(object sender, EventArgs e)
        {
            initialize();
        }

        private void initialize()
        {
            if (GetLayers() == null) return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    chklstOverlayLayers.Items.Add(layer.Name, true);
                    cboBufferLayer.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }

            cboBufferLayer.SelectedIndex = 0;
            cboBufferField.Enabled = false;
            txtBufferDistance.Enabled = true;
            cboSideType.Enabled = false;
            cboEndType.Enabled = false;
            chklstFields.Visible = false;
        }

        private void cboBufferLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBufferLayer.SelectedItem != null)
            {
                strBufferLayer = cboBufferLayer.SelectedItem.ToString();
                if (GetFeatureLayer(strBufferLayer) == null) return;
                IFeatureLayer featureLayer = GetFeatureLayer(strBufferLayer);
                if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    cboSideType.Enabled = true;
                    cboEndType.Enabled = true;
                }
                else
                {
                    cboSideType.Enabled = false;
                    cboEndType.Enabled = false;
                }
            }
        }

        #region "GetLayers"
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            //uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";  // IGeoFeatureLayer
            //uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";  // IDataLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }
        #endregion

        private void rdoBufferDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBufferDistance.Checked)
                txtBufferDistance.Enabled = true;
            else
                txtBufferDistance.Enabled = false;
        }

        private void rdoBufferField_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBufferField.Checked)
            {
                cboBufferField.Enabled = true;
                if (strBufferLayer != "")
                {
                    if (GetFeatureLayer(strBufferLayer) == null) return;
                    featureBufferLayer = GetFeatureLayer(strBufferLayer);
                    CboBufferFieldAdditems(featureBufferLayer);
                }

            }
            else
                cboBufferField.Enabled = false;
        }

        private void CboBufferFieldAdditems(IFeatureLayer featureLayer)
        {
            IFields fields = featureLayer.FeatureClass.Fields;
            IField field = null;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                field = fields.get_Field(i);
                if (field.Type == esriFieldType.esriFieldTypeDouble || field.Type == esriFieldType.esriFieldTypeInteger || field.Type == esriFieldType.esriFieldTypeSingle || field.Type == esriFieldType.esriFieldTypeSmallInteger)
                    cboBufferField.Items.Add(field.Name);
            }
        }

        #region "GetFeatureLayer"
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            if (GetLayers() == null) return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }

        #endregion    

        private void txtBufferDistance_Leave(object sender, EventArgs e)
        {
            if (rdoBufferDistance.Checked)
            {
                if (Information.IsNumeric(txtBufferDistance.Text))
                {
                    bufferDistance = Convert.ToDouble(txtBufferDistance.Text);
                    bufferDistanceField = bufferDistance;
                }
            }
        }

        private void cboBufferField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBufferField.Checked)
            {
                if (cboBufferField.SelectedItem != null)
                {
                    strBufferField = cboBufferField.SelectedItem.ToString();
                    bufferDistanceField = strBufferField;
                }
            }
        }

        private void cboSideType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSideType;
            if (cboSideType.SelectedItem != null)
            {
                selectedSideType = cboSideType.SelectedItem.ToString();
                switch (selectedSideType)
                {
                    case "两边":
                        strSideType = "FULL";
                        break;
                    case "左边":
                        strSideType = "LEFT";
                        break;
                    case "右边":
                        strSideType = "RIGHT";
                        break;
                    default:
                        break;
                }
            }
        }

        private void cboEndType_SelectedIndexChanged(object sender, EventArgs e)
        {
             string selectedEndType;
             if (cboEndType.SelectedItem != null)
             {
                 selectedEndType = cboEndType.SelectedItem.ToString();
                 switch (selectedEndType)
                 {
                     case "圆弧型":
                         strEndType = "ROUND";
                         break;
                     case "平直型":
                         strEndType = "FLAT";
                         break;
                     default:
                         break;
                 }
             }
        }

        private void cboDissolveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectDissolveTyppe;
            if (cboDissolveType.SelectedItem != null)
            {
                selectDissolveTyppe = cboDissolveType.SelectedItem.ToString();
                switch (selectDissolveTyppe)
                {
                    case "不融合":
                        strDissolveType = "NONE";
                        chklstFields.Enabled = false;
                        break;
                    case "融合所有缓冲区":
                        strDissolveType = "ALL";
                        chklstFields.Enabled = false;
                        break;
                    case "根据字段属性融合":
                        strDissolveType = "LIST";
                        chklstFields.Visible = true;
                        chklstFields.Enabled = true;
                        ChklstFieldsAddItems(featureBufferLayer);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChklstFieldsAddItems(IFeatureLayer featureLayer)
        {
            if (featureLayer == null)
            {
                featureLayer = GetFeatureLayer(strBufferLayer);
            }
            if (featureLayer == null) return;

            IFields fields = featureLayer.FeatureClass.Fields;
            IField field = null;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                field = fields.get_Field(i);
                chklstFields.Items.Add(field.Name);
            }
            chklstFields.Refresh();
        }

        private void chklstFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (object itemChecked in chklstFields.CheckedItems)
            {
                strDissolveFields += itemChecked + ";";
            }
        }

        private void btnOutpuPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strOutputPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBufferAnalysis_Click(object sender, EventArgs e)
        {
            txtMessages.Text += "开始缓冲区分析,请稍候... " + "\r\n";
            txtMessages.Text += DateTime.Now.ToString() + "\r\n";
            txtMessages.Update();

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            gp.AddOutputsToMap = true;
            //DisplayEnvironmentPameters(gp);

            IGeoProcessorResult results = CreateBuffer(gp);
            if ((results != null) && (results.Status == esriJobStatus.esriJobSucceeded))
            {
                BufferOverlayAnalysis(gp);
                txtMessages.Text += "缓冲区分析结束！" + "\r\n";
                txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                ScrollToBottom(txtMessages);
                txtMessages.Update();
            }
            gp = null;
        }


        #region "Create FeatureClass"
        public IFeatureClass CreateFeatureClass(string featureClassName, string geometryType, ISpatialReference spatialReference)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
            fieldsEdit.FieldCount_2 = 2;
            //Create the Object ID field.
            IField fieldUserDefined = new Field();
            IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
            fieldEdit.Name_2 = "FID";
            fieldEdit.AliasName_2 = "OBJECT ID";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.set_Field(0, fieldUserDefined);
            // Create the Shape field.
            fieldUserDefined = new Field();
            fieldEdit = (IFieldEdit)fieldUserDefined;
            // Set up the geometry definition for the Shape field.
            IGeometryDef geometryDef = new GeometryDefClass();
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            switch (geometryType)
            {
                case "点":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
                case "线":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                    break;
                case "多边形":
                case "矩形":
                case "圆":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                    break;
                default:
                    break;
            }
            // By setting the grid size to 0, you're allowing ArcGIS to determine the appropriate grid sizes for the feature class. 
            // If in a personal geodatabase, the grid size will be 1000. If in a file or ArcSDE geodatabase, the grid size
            // will be based on the initial loading or inserting of features.
            geometryDefEdit.GridCount_2 = 1;
            geometryDefEdit.set_GridSize(0, 0);
            geometryDefEdit.HasM_2 = false;
            geometryDefEdit.HasZ_2 = false;
            //Assign the spatial reference that was passed in, possibly from
            //IGeodatabase.SpatialReference for the containing feature dataset.
            if (spatialReference != null)
            {
                geometryDefEdit.SpatialReference_2 = spatialReference;
            }
            // Set standard field properties.
            fieldEdit.Name_2 = "SHAPE";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geometryDef;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.Required_2 = true;
            fieldsEdit.set_Field(1, fieldUserDefined);

            UID CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";

            return featureWorkspace.CreateFeatureClass(featureClassName, fields, CLSID, null, esriFeatureType.esriFTSimple, fields.get_Field(1).Name, "");
        }
        #endregion

        private IGeoProcessorResult CreateBuffer(Geoprocessor gp)
        {
            txtMessages.Text += "正在创建缓冲区: " + "\r\n";
            txtMessages.Update();
            //Buffer_analysis (in_features, out_feature_class, buffer_distance_or_field, line_side, line_end_type, dissolve_option, dissolve_field) 
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer();
            IFeatureLayer bufferLayer = GetFeatureLayer(strBufferLayer);
            buffer.in_features = bufferLayer;
            bufferedFeatureClassName = strBufferLayer + "_" + "Buffer";
            string outputFullPath = System.IO.Path.Combine(strOutputPath, bufferedFeatureClassName);
            buffer.out_feature_class = outputFullPath;
            buffer.buffer_distance_or_field = bufferDistanceField;
            buffer.line_side = strSideType;
            buffer.line_end_type = strEndType;
            buffer.dissolve_option = strDissolveType;
            buffer.dissolve_field = strDissolveFields;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(buffer, null);
            buffer = null;
            txtMessages.Text += ReturnMessages(gp);
            txtMessages.Text += "缓冲区创建完成！ " + "\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
            return results;

        }


        private void BufferOverlayAnalysis(Geoprocessor gp)
        {
            foreach (object itemChecked in chklstOverlayLayers.CheckedItems)
            {
                BufferOverlayAnalysisOneLayer(itemChecked.ToString(), gp);
                ScrollToBottom(txtMessages);
            }
        }


        private IGeoProcessorResult BufferOverlayAnalysisOneLayer(string layerName, Geoprocessor gp)
        {
            //Intersect_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, output_type) 
            txtMessages.Text += "输入图层: " + layerName + "\r\n";
            txtMessages.Text += "叠置图层: " + bufferedFeatureClassName + "\r\n";
            txtMessages.Text += "可能要较长时间，请稍候... " + "\r\n";

            IGpValueTableObject vtobject = new GpValueTableObjectClass();
            vtobject.SetColumns(1);
            object row1 = "";
            //row1 = layerName + " " + inputLevel.ToString();
            row1 = GetFeatureLayer(layerName);
            vtobject.AddRow(ref row1);
            object row2 = "";
            string outputFullOverlay = System.IO.Path.Combine(strOutputPath, bufferedFeatureClassName);
            row2 = outputFullOverlay + ".shp";
            vtobject.AddRow(ref row2);

            IVariantArray pVarArray = new VarArrayClass();
            pVarArray.Add(vtobject);
            //string outputFullPath = System.IO.Path.Combine(strOutputPath, layerName + "_" + bufferedFeatureClassName + "_" + "BufferOverlay.shp");
            string outputFullPath = System.IO.Path.Combine(strOutputPath, layerName + "_" + "BufferOverlay.shp");

            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);
            pVarArray.Add(strOutputFeatureType);

            IGeoProcessorResult results = gp.Execute("Intersect_analysis", pVarArray, null) as IGeoProcessorResult;
            txtMessages.Text += layerName + "图层与" + bufferedFeatureClassName + "图层叠置处理完毕！" + "\r\n";

            return results;
        }

        private void txtTolerance_Leave(object sender, EventArgs e)
        {
            if (IsDouble(txtTolerance.Text))
                tolerance = Convert.ToDouble(txtTolerance.Text);
        }


        private bool IsDouble(string s)
        {
            try
            {
                Double.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void numUpDownOverlayLevel_ValueChanged(object sender, EventArgs e)
        {
            overlayLevel = (int)numUpDownOverlayLevel.Value;
        }

        private void numUpDownInputLevel_ValueChanged(object sender, EventArgs e)
        {
            inputLevel = (int)numUpDownInputLevel.Value;
        }

        private void btnAttributes_Click(object sender, EventArgs e)
        {
            frmGeoReport geoReport = new frmGeoReport(m_map);
            geoReport.Show(m_hookHelper as System.Windows.Forms.IWin32Window);
        }

        private void cboAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string attributeType = cboAttributeType.SelectedItem.ToString();
            switch (attributeType)
            {
                case "所有属性":
                    strJoinAttributeType = "ALL";
                    break;
                case "不包括FID":
                    strJoinAttributeType = "NO_FID";
                    break;
                case "仅包括FID":
                    strJoinAttributeType = "ONLY_FID";
                    break;
                default:
                    break;
            }
        }

        private void cboFeatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string featureType = cboFeatureType.SelectedItem.ToString();
            switch (featureType)
            {
                case "根据输入要素确定":
                    strOutputFeatureType = "INPUT";
                    break;
                case "线":
                    strOutputFeatureType = "LINE";
                    break;
                case "点":
                    strOutputFeatureType = "POINT";
                    break;
                default:
                    break;
            }
        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        } 
    }
}
