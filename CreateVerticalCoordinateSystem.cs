using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("b6ac32c8-3814-4c4f-9f6c-3160c7350db3")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication1.空间参考.CreateVerticalCoordinateSystem")]
    public sealed class CreateVerticalCoordinateSystem : BaseCommand
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
        IMapControl3 m_mapControl;
        IMap m_map = null;
        IActiveView m_activeView;

        public CreateVerticalCoordinateSystem()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; 
            base.m_caption = "CreateVerticalCoordinateSystem";   
            base.m_message = "";  
            base.m_toolTip = "";  
            base.m_name = "";  

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            m_mapControl = m_hookHelper.Hook as IMapControl3;
            m_map = m_mapControl.Map;
            m_activeView = m_mapControl.ActiveView;
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            if (m_map == null)
                return;
            createVerticalCoordinateSystem();
        }

        #endregion

        private void createVerticalCoordinateSystem()
        {
       ISpatialReferenceFactory3 spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
       IVerticalDatum verticalDatum = spatialReferenceFactory.CreateVerticalDatum((int)esriSRVerticalDatumType.esriSRVertDatum_Taranaki);
       IHVDatum hvDatum = verticalDatum as IHVDatum;
       ILinearUnit linearUnit = spatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Meter) as ILinearUnit;
       IVerticalCoordinateSystemEdit verticalCoordinateSystemEdit = new VerticalCoordinateSystemClass();
       object name = "New VCoordinateSystem";
       object alias = "VCoordinateSystem alias";
       object abbreviation = "abbr";
       object remarks = "Test for options";
       object usage = "New Zealand";
       object hvDatumObject = hvDatum as object;
       object unitObject = linearUnit as object;
       object verticalShift = 40 as object;
       object positiveDirection = -1 as object;
       verticalCoordinateSystemEdit.Define(ref name, ref alias, ref abbreviation, ref remarks, ref usage, ref hvDatumObject, ref unitObject, ref verticalShift, ref positiveDirection);
       IVerticalCoordinateSystem verticalCoordinateSystem = verticalCoordinateSystemEdit as IVerticalCoordinateSystem;
      

       m_map.SpatialReference = verticalCoordinateSystem as ISpatialReference ;
       m_activeView.Refresh();
       MessageBox.Show("自定义verticalCoordinateSystem完成！");
        }
 


    }
}
