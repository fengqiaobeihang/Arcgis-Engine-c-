using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class frmGeoReport : Form
    {
        bool displaySelectedFeatures = true;
        bool displayViaReport = true;
        IMap m_map;

        public frmGeoReport(IMap map)
        {
            InitializeComponent();
            m_map = map;
        }

        private void frmGeoReport_Load(object sender, EventArgs e)
        {

        }

        private void rdoSelectedFeatures_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSelectedFeatures.Checked)
                displaySelectedFeatures = true;
            else
                displaySelectedFeatures = false;
        }

        private void rdoReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReport.Checked)
                displayViaReport = true;
            else
                displayViaReport = false;
        }

        private void btnAttributesReport_Click(object sender, EventArgs e)
        {
            if (displayViaReport)
            {
                DynamicAttributesReport displayAtrributes = new DynamicAttributesReport(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
            else
            {
                AttributesForm displayAtrributes = new AttributesForm(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
