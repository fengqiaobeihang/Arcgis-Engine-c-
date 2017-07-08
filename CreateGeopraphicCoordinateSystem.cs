using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("ea17ded7-13eb-482d-90f1-05a90c27d713")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication1.空间参考.CeeateGeopraphicCoordinateSystem")]
    public sealed class CreateGeopraphicCoordinateSystem : BaseCommand
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
        IMap m_map=null ;
        IActiveView m_activeView;

        public CreateGeopraphicCoordinateSystem()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "WindowsFormsApplication1"; 
            base.m_caption = "CeateGeopraphicCoordinateSystem";   
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";
            base.m_toolTip = "CeateGeopraphicCoordinateSystem";
            base.m_name = "CeateGeopraphicCoordinateSystem";  

            try
            {
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
            if (m_map == null) return;
            CreateGeographicCoordinateSystem();
        }

        #endregion

        private void  CreateGeographicCoordinateSystem()
        {
            ISpatialReferenceFactory3 spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            IDatum datum = spatialReferenceFactory.CreateDatum((int)esriSRDatumType.esriSRDatum_OSGB1936);
            IPrimeMeridian primeMeridian = spatialReferenceFactory.CreatePrimeMeridian((int)esriSRPrimeMType.esriSRPrimeM_Greenwich);
            IUnit unit = spatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Degree);
            IGeographicCoordinateSystemEdit geographicCoordinateSystemEdit = new GeographicCoordinateSystemClass();
            object name = "UserDefined Geographic Coordinate System";
            object alias = "UserDefined GCS";
            object abbreviation = "UserDefined";
            object remarks = "User Defined Geographic Coordinate System based on OSGB1936";
            object usage = "Suitable for the UK";
            object datumObject = datum as object;
            object primeMeridianObject = primeMeridian as object;
            object unitObject = unit as object;
            geographicCoordinateSystemEdit.Define(ref name, ref alias, ref abbreviation, ref   remarks, ref usage, ref datumObject, ref primeMeridianObject, ref unitObject);
            IGeographicCoordinateSystem userDefinedGeographicCoordinateSystem = geographicCoordinateSystemEdit as IGeographicCoordinateSystem;


            m_map.SpatialReference = userDefinedGeographicCoordinateSystem;
            m_activeView.Refresh();
            MessageBox.Show("已将当前坐标系统转换为自定义GeographicCoordinateSystem！");
        }
    }
}
