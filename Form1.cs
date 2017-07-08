using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Analyst3D;
using System.Windows.Forms;
using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //自定义菜单\工具栏\自定义对话框
        IToolbarMenu m_ToolbarMenu;//地图右键菜单


        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        IMapDocument m_MapDocument = new MapDocumentClass();
        Sunisoft.IrisSkin.SkinEngine se = null;
        public Form1()
        {
            //this.skinEngine1.SkinFile = "office2007.ssk";
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
            se.SkinFile = "Skins\\SteelBlack.ssk";    
            InitializeComponent();
        }

        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)//右健弹出快捷键
            {
                m_ToolbarMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);
            }
            // axMapControl1.Pan();
           // axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
           // axMapControl1.Extent = axMapControl1.TrackRectangle();
           // axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void axMapControl2_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    axMapControl1.CenterAt(pPoint);
                    axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = axMapControl2.TrackRectangle();
                    axMapControl1.Extent = pEnv;
                    axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                }
            }

        }

        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            CopyAndOverwriteMap();
            if (axMapControl1.LayerCount > 0) 
            {
                axMapControl2.Map = new MapClass(); 
                for (int i = 0; i <= axMapControl1.Map.LayerCount - 1; i++) 
            { 
                  axMapControl2.AddLayer(axMapControl1.get_Layer(i)); 
             } 
                axMapControl2.Extent = axMapControl1.Extent;
                axMapControl2.Refresh(); 
            } 
           
        }

        private void axMapControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // 得到新范围 
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            //在绘制前，清除axMapControl2中的任何图形元素 
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;
            //设置鹰眼图中的红线框 
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            //产生一个线符号对象 
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3;
            pOutline.Color = pColor;
            //设置颜色属性 
            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;
            //设置填充符号的属性 
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);
            pActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null); 

        }

        private void axMapControl2_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                axMapControl1.CenterAt(pPoint);
                axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
            } 

        }

        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                //鼠标右键按下
                if (axMapControl1.LayerCount > 0)//主视图中要有地理数据
                {
                    esriTOCControlItem mItem = new esriTOCControlItem();
                    IBasicMap pMap = new MapClass();
                    ILayer pLayer = new FeatureLayerClass();
                    object pOther = new object();
                    object pIndex = new object();
                    axTOCControl1.HitTest(e.x, e.y, ref mItem, ref pMap, ref pLayer, ref pOther, ref pIndex);
                    IGeoFeatureLayer pGeoFeatureLayer;
                    pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
                    //添加显示属性表的代码
                    string layerPath;
                    string layerDatafileName;
                    IWorkspaceName pWorkspaceName;
                    IDatasetName pDatasetName;
                    IDataLayer pDataLayer;
                    pDataLayer = pGeoFeatureLayer as IDataLayer;
                    pDatasetName = pDataLayer.DataSourceName as IDatasetName;
                    pWorkspaceName = pDatasetName.WorkspaceName;
                    layerPath = pWorkspaceName.PathName;
                    layerDatafileName = pLayer.Name.Trim() + ".dbf";
                    string dbfFilePath = layerPath; ;
                    string dbfFileName = layerDatafileName; ;
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(dbfFilePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    if (pFeatureWorkspace != null)
                    {
                        IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(dbfFileName);
                        if (pFeatureClass != null)
                        {
                            DataTable dt = new DataTable();
                            DataColumn dc;
                            for (int i = 0; i <= pFeatureClass.Fields.FieldCount - 1; i++)
                            {
                                dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                                dt.Columns.Add(dc);
                            }
                            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                            IFeature pFeature = pFeatureCursor.NextFeature();
                            DataRow dr;
                            while (pFeature != null)
                            {
                                dr = dt.NewRow();
                                for (int j = 0; j <= pFeatureClass.Fields.FieldCount - 1; j++)
                                {
                                    if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                                    {
                                        dr[j] = pFeatureClass.ShapeType.ToString();
                                    }
                                    else
                                    {
                                        dr[j] = pFeature.get_Value(j).ToString();
                                    }
                                }
                                dt.Rows.Add(dr);
                                pFeature = pFeatureCursor.NextFeature();
                            }
                            GeoMapAttribute frmTable = new GeoMapAttribute();
                            frmTable.Show();
                            frmTable.dataGridView1.DataSource = dt;
                        }
                    }
                }
            }            
        }

        public static System.Data.DataTable CreateDataTable(ILayer pLayer, string tableName)
        {
            //根据选择的图层创建空DataTable
            System.Data.DataTable pDataTable = CreateDataTableByLayer(pLayer, tableName);
            pDataTable.TableName = pLayer.Name;
            //取得图层类型
            string shapeType = getShapeType(pLayer);
            //创建DataTable的行对象
            DataRow pDataRow = null;
            //从ILayer查询到ITable
            ITable pTable = pLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            //取得ITable中的行信息
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                //新建DataTable的行对象
                pDataRow = pDataTable.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                    if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        pDataRow[i] = shapeType;
                    }
                    //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                    //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                    else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        pDataRow[i] = "Element";
                    }
                    else
                    {
                        pDataRow[i] = pRow.get_Value(i);
                    }
                }
                //添加DataRow到DataTable
                pDataTable.Rows.Add(pDataRow);
                pDataRow = null;
                n++;
                pRow = pCursor.NextRow();
            }
            return pDataTable;
        }
        public static string getShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return "";
            }
        }
        private static System.Data.DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
        {
            //创建一个DataTable表
            System.Data.DataTable pDataTable = new System.Data.DataTable(tableName);
            //取得ITable接口
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;
            //根据每个字段的属性建立DataColumn对象
            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                //新建一个DataColumn并设置其属性
                pDataColumn = new DataColumn(pField.Name);
                if (pField.Name == pTable.OIDFieldName)
                {
                    pDataColumn.Unique = true;//字段值是否唯一
                }
                //字段值是否允许为空
                pDataColumn.AllowDBNull = pField.IsNullable;
                //字段别名
                pDataColumn.Caption = pField.AliasName;
                //字段数据类型
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                //字段默认值
                pDataColumn.DefaultValue = pField.DefaultValue;
                //当字段为String类型是设置字段长度
                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                //字段添加到表中
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }
            return pDataTable;
        }
        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.String";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }
        //因为DataTable的表名不允许含有“.”，因此我们用“_”替换。函数如下：
        public static string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }
        private void CopyAndOverwriteMap()
        {
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            //map to copy
            object toCopyMap = axMapControl1.Map;
            //copied map
            object copiedMap = pObjectCopy.Copy(toCopyMap);
            //map to overwrite
            object toOverwriteMap = axPageLayoutControl1.ActiveView.FocusMap;
            //overwrite the pagelayoutcontrol's map
            pObjectCopy.Overwrite(copiedMap, ref toOverwriteMap);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UID pUid = new ESRI.ArcGIS.esriSystem.UID();            //初始化菜单工具栏命令
            pUid.Value = "esriControls.ControlsOpenDocCommand";
            axToolbarControl1.AddItem(pUid, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            pUid.Value = "esriControls.ControlsMapZoomInTool";
            axToolbarControl1.AddItem(pUid, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconAndText);
            pUid.Value = "esriControls.ControlsMapZoomOutTool";
            axToolbarControl1.AddItem(pUid, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconAndText);
            pUid.Value = "esriControls.ControlsMapPanTool";
            axToolbarControl1.AddItem(pUid, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconAndText);
            pUid.Value = "esriControls.ControlsMapFullExtentCommand";
            axToolbarControl1.AddItem(pUid, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconAndText);
            pUid.Value = "esriControls.ControlsMapZoomToLastExtentBackCommand";
            axToolbarControl1.AddItem(pUid, -1, -1, true, 20, esriCommandStyles.esriCommandStyleIconOnly);
            pUid.Value = "esriControls.ControlsMapZoomToLastExtentForwardCommand";
            axToolbarControl1.AddItem(pUid, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            //右键菜单
            m_ToolbarMenu = new ESRI.ArcGIS.Controls.ToolbarMenu();

            String progID;//初始化地图控件右键快捷菜单工具栏命令
            progID = "esriControls.ControlsMapFullExtentCommand";
            m_ToolbarMenu.AddItem(progID, -1, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            progID = "esriControls.ControlsMapZoomPanTool";
            m_ToolbarMenu.AddItem(progID, -1, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            progID = "esriControls.ControlsMapZoomInTool";
            m_ToolbarMenu.AddItem(progID, -1, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            progID = "esriControls.ControlsMapZoomOutTool";
            m_ToolbarMenu.AddItem(progID, -1, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            progID = "esriControls.ControlsMapPanTool";
            m_ToolbarMenu.AddItem(progID, -1, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.SetHook(axMapControl1);
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {

        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView pActiveView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = axMapControl1.Extent;
            axPageLayoutControl1.ActiveView.Refresh();
            CopyAndOverwriteMap();
        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            axTOCControl1.Update();
            CopyAndOverwriteMap();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenMXD = new OpenFileDialog();
            OpenMXD.Title = "打开地图";
            OpenMXD.InitialDirectory = "E:";
            OpenMXD.Filter = "Map Documents (*.mxd)|*.mxd";
            if (OpenMXD.ShowDialog() == DialogResult.OK)
            {
                string MxdPath = OpenMXD.FileName;
                axMapControl1.LoadMxFile(MxdPath);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
        }
        private void 创建点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreatePointTool();
            cmd.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = cmd as ITool;
        }

        private void 创建点ToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void 属性条件查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.AttributeQueryCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 创建线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreatePolylineTool();
            cmd.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = cmd as ITool;
        }

        private void 创建面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreatePolygonTool();
            cmd.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = cmd as ITool;
        }

        private void 创建圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreateCircleTool();
            cmd.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = cmd as ITool;
        }

        private void 创建矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreateRectangleTool();
            cmd.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = cmd as ITool;
        }

        private void createGeographicCoordinateSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new WindowsFormsApplication1.CreateGeopraphicCoordinateSystem();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void createProjectedCoordinateSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new WindowsFormsApplication1.CreateProjectedCoordinateSystem();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void createVerticalCoordinateSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new WindowsFormsApplication1.CreateVerticalCoordinateSystem();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void 单一符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.SingleSymbolCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 通用符号化ArcGIS桌面有效ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.SymbolizationByLayerPropPageCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 分类符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.ClassBreaksRendererSymbolCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 分级符号符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.GraduatedSymbolsCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 分级色彩符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.GraduatedColorSymbolsCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 依比例符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.ProportionalSymbolsCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 点值符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.DotDensitySymbolsCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 统计符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.StatisticsSymbolsCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 唯一值符号化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new WindowsFormsApplication1.UniqueValuesSymbolCmd();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void skinEngine1_CurrentSkinChanged(object sender, Sunisoft.IrisSkin.SkinChangedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 标注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.地图标注 form = new WindowsFormsApplication1.地图标注(m_mapControl);
            form.Show();
        }
    }
}
