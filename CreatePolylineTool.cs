using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Summary description for CreatePolylineTool.
    /// </summary>
    [Guid("04ccb570-5cbd-4c7d-8437-a5a70fcc49cd")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("GeometryAndSR.CreatePolylineTool")]
    public sealed class CreatePolylineTool : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;
        IMap m_Map;
        IActiveView m_ActiveView;    

        public CreatePolylineTool( )
        {
            base.m_category = "WindowsFormsApplication1";  
            base.m_caption = "������Ԫ��";
            base.m_message = "������Ԫ��";
            base.m_toolTip = "������Ԫ��";
            base.m_name = "CreatePolylineTool";    
            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            m_ActiveView = m_hookHelper.ActiveView;
            m_Map = m_hookHelper.FocusMap;
            IScreenDisplay pScreenDisplay = m_ActiveView.ScreenDisplay;
            IRubberBand pRubberPolyline = new RubberLineClass();
            ISimpleLineSymbol pLineSymbol = new SimpleLineSymbolClass();
            pLineSymbol.Color = getRGB(255, 255, 0);
            IPolyline pPolyline = pRubberPolyline.TrackNew(pScreenDisplay, (ISymbol)pLineSymbol) as IPolyline;
            pLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            pLineSymbol.Color = getRGB(0, 255, 255);
            ILineElement pPolylineEle = new LineElementClass();
            pPolylineEle.Symbol = pLineSymbol;
            IElement pEle = pPolylineEle as IElement;
            pEle.Geometry = pPolyline;
            IGraphicsContainer pGraphicsContainer = m_Map as IGraphicsContainer;
            pGraphicsContainer.AddElement(pEle, 0);
            m_ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {
            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }
        #endregion
    }
}
