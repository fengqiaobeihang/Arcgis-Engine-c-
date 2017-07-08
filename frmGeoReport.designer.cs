namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class frmGeoReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAttributesReport = new System.Windows.Forms.Button();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpActionType = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoDataGridView = new System.Windows.Forms.RadioButton();
            this.grpFearuesContents = new System.Windows.Forms.GroupBox();
            this.rdoSelectedFeatures = new System.Windows.Forms.RadioButton();
            this.rdoAllFeatures = new System.Windows.Forms.RadioButton();
            this.grpAttributes.SuspendLayout();
            this.grpActionType.SuspendLayout();
            this.grpFearuesContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAttributesReport
            // 
            this.btnAttributesReport.Location = new System.Drawing.Point(97, 135);
            this.btnAttributesReport.Name = "btnAttributesReport";
            this.btnAttributesReport.Size = new System.Drawing.Size(64, 23);
            this.btnAttributesReport.TabIndex = 21;
            this.btnAttributesReport.Text = "确定";
            this.btnAttributesReport.UseVisualStyleBackColor = true;
            this.btnAttributesReport.Click += new System.EventHandler(this.btnAttributesReport_Click);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.grpActionType);
            this.grpAttributes.Controls.Add(this.grpFearuesContents);
            this.grpAttributes.Location = new System.Drawing.Point(12, 12);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(346, 109);
            this.grpAttributes.TabIndex = 19;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "选择报表内容与方式";
            // 
            // grpActionType
            // 
            this.grpActionType.Controls.Add(this.rdoReport);
            this.grpActionType.Controls.Add(this.rdoDataGridView);
            this.grpActionType.Location = new System.Drawing.Point(193, 26);
            this.grpActionType.Name = "grpActionType";
            this.grpActionType.Size = new System.Drawing.Size(123, 63);
            this.grpActionType.TabIndex = 2;
            this.grpActionType.TabStop = false;
            this.grpActionType.Text = "操作方式";
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Checked = true;
            this.rdoReport.Location = new System.Drawing.Point(9, 39);
            this.rdoReport.Name = "rdoReport";
            this.rdoReport.Size = new System.Drawing.Size(71, 16);
            this.rdoReport.TabIndex = 1;
            this.rdoReport.TabStop = true;
            this.rdoReport.Text = "属性报表";
            this.rdoReport.UseVisualStyleBackColor = true;
            this.rdoReport.CheckedChanged += new System.EventHandler(this.rdoReport_CheckedChanged);
            // 
            // rdoDataGridView
            // 
            this.rdoDataGridView.AutoSize = true;
            this.rdoDataGridView.Location = new System.Drawing.Point(9, 20);
            this.rdoDataGridView.Name = "rdoDataGridView";
            this.rdoDataGridView.Size = new System.Drawing.Size(83, 16);
            this.rdoDataGridView.TabIndex = 0;
            this.rdoDataGridView.Text = "普通属性表";
            this.rdoDataGridView.UseVisualStyleBackColor = true;
            // 
            // grpFearuesContents
            // 
            this.grpFearuesContents.Controls.Add(this.rdoSelectedFeatures);
            this.grpFearuesContents.Controls.Add(this.rdoAllFeatures);
            this.grpFearuesContents.Location = new System.Drawing.Point(27, 26);
            this.grpFearuesContents.Name = "grpFearuesContents";
            this.grpFearuesContents.Size = new System.Drawing.Size(133, 63);
            this.grpFearuesContents.TabIndex = 2;
            this.grpFearuesContents.TabStop = false;
            this.grpFearuesContents.Text = "要素范围";
            // 
            // rdoSelectedFeatures
            // 
            this.rdoSelectedFeatures.AutoSize = true;
            this.rdoSelectedFeatures.Checked = true;
            this.rdoSelectedFeatures.Location = new System.Drawing.Point(9, 39);
            this.rdoSelectedFeatures.Name = "rdoSelectedFeatures";
            this.rdoSelectedFeatures.Size = new System.Drawing.Size(95, 16);
            this.rdoSelectedFeatures.TabIndex = 1;
            this.rdoSelectedFeatures.TabStop = true;
            this.rdoSelectedFeatures.Text = "仅选择的要素";
            this.rdoSelectedFeatures.UseVisualStyleBackColor = true;
            this.rdoSelectedFeatures.CheckedChanged += new System.EventHandler(this.rdoSelectedFeatures_CheckedChanged);
            // 
            // rdoAllFeatures
            // 
            this.rdoAllFeatures.AutoSize = true;
            this.rdoAllFeatures.Location = new System.Drawing.Point(9, 20);
            this.rdoAllFeatures.Name = "rdoAllFeatures";
            this.rdoAllFeatures.Size = new System.Drawing.Size(71, 16);
            this.rdoAllFeatures.TabIndex = 0;
            this.rdoAllFeatures.Text = "全部要素";
            this.rdoAllFeatures.UseVisualStyleBackColor = true;
            // 
            // frmGeoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 178);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAttributesReport);
            this.Controls.Add(this.grpAttributes);
            this.Name = "frmGeoReport";
            this.Text = "地理属性报表";
            this.Load += new System.EventHandler(this.frmGeoReport_Load);
            this.grpAttributes.ResumeLayout(false);
            this.grpActionType.ResumeLayout(false);
            this.grpActionType.PerformLayout();
            this.grpFearuesContents.ResumeLayout(false);
            this.grpFearuesContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAttributesReport;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpActionType;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoDataGridView;
        private System.Windows.Forms.GroupBox grpFearuesContents;
        private System.Windows.Forms.RadioButton rdoSelectedFeatures;
        private System.Windows.Forms.RadioButton rdoAllFeatures;
    }
}