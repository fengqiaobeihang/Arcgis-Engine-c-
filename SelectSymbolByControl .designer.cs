﻿namespace WindowsFormsApplication1
{
    partial class SelectSymbolByControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSymbolByControl));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStyles = new System.Windows.Forms.ComboBox();
            this.btnOtherStyles = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Largeimage = new System.Windows.Forms.ImageList(this.components);
            this.Smallimage = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "选择样式库：";
            // 
            // cbxStyles
            // 
            this.cbxStyles.FormattingEnabled = true;
            this.cbxStyles.Location = new System.Drawing.Point(92, 3);
            this.cbxStyles.Name = "cbxStyles";
            this.cbxStyles.Size = new System.Drawing.Size(305, 20);
            this.cbxStyles.TabIndex = 11;
            this.cbxStyles.SelectedIndexChanged += new System.EventHandler(this.cbxStyles_SelectedIndexChanged);
            // 
            // btnOtherStyles
            // 
            this.btnOtherStyles.Location = new System.Drawing.Point(403, 1);
            this.btnOtherStyles.Name = "btnOtherStyles";
            this.btnOtherStyles.Size = new System.Drawing.Size(40, 25);
            this.btnOtherStyles.TabIndex = 10;
            this.btnOtherStyles.Text = "其它";
            this.btnOtherStyles.Click += new System.EventHandler(this.btnOtherStyles_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(449, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 25);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.axSymbologyControl1);
            this.groupBox3.Location = new System.Drawing.Point(12, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 310);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Symbology";
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyControl1.Location = new System.Drawing.Point(3, 17);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(425, 290);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(449, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Largeimage
            // 
            this.Largeimage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Largeimage.ImageSize = new System.Drawing.Size(16, 16);
            this.Largeimage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Smallimage
            // 
            this.Smallimage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Smallimage.ImageSize = new System.Drawing.Size(16, 16);
            this.Smallimage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SelectSymbolByControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxStyles);
            this.Controls.Add(this.btnOtherStyles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Name = "SelectSymbolByControl";
            this.Text = "选择符号";
            this.Load += new System.EventHandler(this.SelectSymbolByControl_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStyles;
        private System.Windows.Forms.Button btnOtherStyles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList Largeimage;
        private System.Windows.Forms.ImageList Smallimage;
    }
}