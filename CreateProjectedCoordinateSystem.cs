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
    [Guid("7d0c88f5-ee44-4277-927b-ec77d194b484")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication1.空间参考.CreateProjectedCoordinateSystem")]
    public sealed class CreateProjectedCoordinateSystem : BaseCommand
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

        public CreateProjectedCoordinateSystem()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; 
            base.m_caption = " CreateProjectedCoordinateSystem";   
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
            if (m_map == null) return;
            createProjectedCoordinateSystem();
        }

        #endregion

        private void  createProjectedCoordinateSystem()
        {
            ISpatialReferenceFactory2 spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            IProjectionGEN projection = spatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_Sinusoidal) as IProjectionGEN;
            IGeographicCoordinateSystem geographicCoordinateSystem = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            ILinearUnit unit = spatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Meter) as ILinearUnit;
            IParameter[] parameters = projection.GetDefaultParameters();
            IProjectedCoordinateSystemEdit projectedCoordinateSystemEdit = new ProjectedCoordinateSystemClass();

            object name = "Newfoundland"; object alias = "NF_LAB";
            object abbreviation = "NF";
            object remarks = "Most Eastern Province in Canada";
            object usage = "When making maps of Newfoundland";
            object geographicCoordinateSystemObject = geographicCoordinateSystem as object;
            object unitObject = unit as object;
            object projectionObject = projection as object;
            object parametersObject = parameters as object; 
            projectedCoordinateSystemEdit.Define(ref name, ref alias, ref abbreviation, ref remarks, ref usage, ref geographicCoordinateSystemObject, ref unitObject, ref projectionObject, ref parametersObject);
            IProjectedCoordinateSystem userDefinedProjectedCoordinateSystem=projectedCoordinateSystemEdit as IProjectedCoordinateSystem ;

            m_map.SpatialReference = userDefinedProjectedCoordinateSystem;
            m_activeView.Refresh();
            MessageBox.Show("自定义ProjectedCoordinateSystem完成！");
        }
    }
}
