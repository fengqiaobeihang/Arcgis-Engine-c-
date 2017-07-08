namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.axSceneControl1 = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.axGlobeControl1 = new ESRI.ArcGIS.Controls.AxGlobeControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建矩形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.叠加分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可视域分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可视线分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地理变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建自定义坐标系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGeographicCoordinateSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProjectedCoordinateSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createVerticalCoordinateSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性条件查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基于空间位置空间关系的查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.邻接多边形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单一符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唯一值符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分类符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分级符号符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分级色彩符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依比例符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点值符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计符号化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消编辑UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定位到XYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.地图标注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGlobeControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl1.Location = new System.Drawing.Point(3, 62);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(195, 294);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(3, 28);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(719, 28);
            this.axToolbarControl1.TabIndex = 1;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(559, 425);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl1_OnViewRefreshed);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(737, 12);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl2.Location = new System.Drawing.Point(3, 362);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(195, 157);
            this.axMapControl2.TabIndex = 4;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开属性表ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(204, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 457);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局视图";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(559, 425);
            this.axPageLayoutControl1.TabIndex = 6;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.axSceneControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(565, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "三维视图";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axSceneControl1
            // 
            this.axSceneControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSceneControl1.Location = new System.Drawing.Point(3, 3);
            this.axSceneControl1.Name = "axSceneControl1";
            this.axSceneControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSceneControl1.OcxState")));
            this.axSceneControl1.Size = new System.Drawing.Size(559, 425);
            this.axSceneControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.axGlobeControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(565, 431);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Globe";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // axGlobeControl1
            // 
            this.axGlobeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGlobeControl1.Location = new System.Drawing.Point(3, 3);
            this.axGlobeControl1.Name = "axGlobeControl1";
            this.axGlobeControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGlobeControl1.OcxState")));
            this.axGlobeControl1.Size = new System.Drawing.Size(559, 425);
            this.axGlobeControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.制图ToolStripMenuItem,
            this.空间分析ToolStripMenuItem,
            this.地理变换ToolStripMenuItem,
            this.d分析ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.帮助ToolStripMenuItem1,
            this.帮助ToolStripMenuItem2,
            this.帮助ToolStripMenuItem3,
            this.地图标注ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(596, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.输出ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开文件ToolStripMenuItem.Image")));
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存ToolStripMenuItem.Image")));
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 输出ToolStripMenuItem
            // 
            this.输出ToolStripMenuItem.Name = "输出ToolStripMenuItem";
            this.输出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.输出ToolStripMenuItem.Text = "输出";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 制图ToolStripMenuItem
            // 
            this.制图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建点ToolStripMenuItem,
            this.创建线ToolStripMenuItem,
            this.创建面ToolStripMenuItem,
            this.创建圆ToolStripMenuItem,
            this.创建矩形ToolStripMenuItem});
            this.制图ToolStripMenuItem.Name = "制图ToolStripMenuItem";
            this.制图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.制图ToolStripMenuItem.Text = "绘图";
            // 
            // 创建点ToolStripMenuItem
            // 
            this.创建点ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建点ToolStripMenuItem.Image")));
            this.创建点ToolStripMenuItem.Name = "创建点ToolStripMenuItem";
            this.创建点ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建点ToolStripMenuItem.Text = "创建点";
            this.创建点ToolStripMenuItem.Click += new System.EventHandler(this.创建点ToolStripMenuItem_Click);
            this.创建点ToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.创建点ToolStripMenuItem_MouseDown);
            // 
            // 创建线ToolStripMenuItem
            // 
            this.创建线ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建线ToolStripMenuItem.Image")));
            this.创建线ToolStripMenuItem.Name = "创建线ToolStripMenuItem";
            this.创建线ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建线ToolStripMenuItem.Text = "创建线";
            this.创建线ToolStripMenuItem.Click += new System.EventHandler(this.创建线ToolStripMenuItem_Click);
            // 
            // 创建面ToolStripMenuItem
            // 
            this.创建面ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建面ToolStripMenuItem.Image")));
            this.创建面ToolStripMenuItem.Name = "创建面ToolStripMenuItem";
            this.创建面ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建面ToolStripMenuItem.Text = "创建多边形";
            this.创建面ToolStripMenuItem.Click += new System.EventHandler(this.创建面ToolStripMenuItem_Click);
            // 
            // 创建圆ToolStripMenuItem
            // 
            this.创建圆ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建圆ToolStripMenuItem.Image")));
            this.创建圆ToolStripMenuItem.Name = "创建圆ToolStripMenuItem";
            this.创建圆ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建圆ToolStripMenuItem.Text = "创建圆";
            this.创建圆ToolStripMenuItem.Click += new System.EventHandler(this.创建圆ToolStripMenuItem_Click);
            // 
            // 创建矩形ToolStripMenuItem
            // 
            this.创建矩形ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("创建矩形ToolStripMenuItem.Image")));
            this.创建矩形ToolStripMenuItem.Name = "创建矩形ToolStripMenuItem";
            this.创建矩形ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建矩形ToolStripMenuItem.Text = "创建矩形";
            this.创建矩形ToolStripMenuItem.Click += new System.EventHandler(this.创建矩形ToolStripMenuItem_Click);
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缓冲区分析ToolStripMenuItem,
            this.叠加分析ToolStripMenuItem,
            this.可视域分析ToolStripMenuItem,
            this.可视线分析ToolStripMenuItem,
            this.网络分析ToolStripMenuItem});
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // 缓冲区分析ToolStripMenuItem
            // 
            this.缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            this.缓冲区分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            // 
            // 叠加分析ToolStripMenuItem
            // 
            this.叠加分析ToolStripMenuItem.Name = "叠加分析ToolStripMenuItem";
            this.叠加分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.叠加分析ToolStripMenuItem.Text = "叠置分析";
            // 
            // 可视域分析ToolStripMenuItem
            // 
            this.可视域分析ToolStripMenuItem.Name = "可视域分析ToolStripMenuItem";
            this.可视域分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.可视域分析ToolStripMenuItem.Text = "可视域分析";
            // 
            // 可视线分析ToolStripMenuItem
            // 
            this.可视线分析ToolStripMenuItem.Name = "可视线分析ToolStripMenuItem";
            this.可视线分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.可视线分析ToolStripMenuItem.Text = "可视线分析";
            // 
            // 网络分析ToolStripMenuItem
            // 
            this.网络分析ToolStripMenuItem.Name = "网络分析ToolStripMenuItem";
            this.网络分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.网络分析ToolStripMenuItem.Text = "网络分析";
            // 
            // 地理变换ToolStripMenuItem
            // 
            this.地理变换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建自定义坐标系统ToolStripMenuItem});
            this.地理变换ToolStripMenuItem.Name = "地理变换ToolStripMenuItem";
            this.地理变换ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地理变换ToolStripMenuItem.Text = "空间参考";
            // 
            // 创建自定义坐标系统ToolStripMenuItem
            // 
            this.创建自定义坐标系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGeographicCoordinateSystemToolStripMenuItem,
            this.createProjectedCoordinateSystemToolStripMenuItem,
            this.createVerticalCoordinateSystemToolStripMenuItem});
            this.创建自定义坐标系统ToolStripMenuItem.Name = "创建自定义坐标系统ToolStripMenuItem";
            this.创建自定义坐标系统ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.创建自定义坐标系统ToolStripMenuItem.Text = "创建自定义坐标系统...";
            // 
            // createGeographicCoordinateSystemToolStripMenuItem
            // 
            this.createGeographicCoordinateSystemToolStripMenuItem.Name = "createGeographicCoordinateSystemToolStripMenuItem";
            this.createGeographicCoordinateSystemToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.createGeographicCoordinateSystemToolStripMenuItem.Text = "CreateGeographicCoordinateSystem";
            this.createGeographicCoordinateSystemToolStripMenuItem.Click += new System.EventHandler(this.createGeographicCoordinateSystemToolStripMenuItem_Click);
            // 
            // createProjectedCoordinateSystemToolStripMenuItem
            // 
            this.createProjectedCoordinateSystemToolStripMenuItem.Name = "createProjectedCoordinateSystemToolStripMenuItem";
            this.createProjectedCoordinateSystemToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.createProjectedCoordinateSystemToolStripMenuItem.Text = "CreateProjectedCoordinateSystem";
            this.createProjectedCoordinateSystemToolStripMenuItem.Click += new System.EventHandler(this.createProjectedCoordinateSystemToolStripMenuItem_Click);
            // 
            // createVerticalCoordinateSystemToolStripMenuItem
            // 
            this.createVerticalCoordinateSystemToolStripMenuItem.Name = "createVerticalCoordinateSystemToolStripMenuItem";
            this.createVerticalCoordinateSystemToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.createVerticalCoordinateSystemToolStripMenuItem.Text = "CreateVerticalCoordinateSystem";
            this.createVerticalCoordinateSystemToolStripMenuItem.Click += new System.EventHandler(this.createVerticalCoordinateSystemToolStripMenuItem_Click);
            // 
            // d分析ToolStripMenuItem
            // 
            this.d分析ToolStripMenuItem.Name = "d分析ToolStripMenuItem";
            this.d分析ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.d分析ToolStripMenuItem.Text = "3D分析";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性条件查询ToolStripMenuItem,
            this.基于空间位置空间关系的查询ToolStripMenuItem,
            this.缓冲区查询ToolStripMenuItem,
            this.邻接多边形查询ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.帮助ToolStripMenuItem.Text = "空间查询";
            // 
            // 属性条件查询ToolStripMenuItem
            // 
            this.属性条件查询ToolStripMenuItem.Name = "属性条件查询ToolStripMenuItem";
            this.属性条件查询ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.属性条件查询ToolStripMenuItem.Text = "属性条件查询";
            this.属性条件查询ToolStripMenuItem.Click += new System.EventHandler(this.属性条件查询ToolStripMenuItem_Click);
            // 
            // 基于空间位置空间关系的查询ToolStripMenuItem
            // 
            this.基于空间位置空间关系的查询ToolStripMenuItem.Name = "基于空间位置空间关系的查询ToolStripMenuItem";
            this.基于空间位置空间关系的查询ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.基于空间位置空间关系的查询ToolStripMenuItem.Text = "基于空间位置、空间关系的查询";
            // 
            // 缓冲区查询ToolStripMenuItem
            // 
            this.缓冲区查询ToolStripMenuItem.Name = "缓冲区查询ToolStripMenuItem";
            this.缓冲区查询ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.缓冲区查询ToolStripMenuItem.Text = "缓冲区查询";
            // 
            // 邻接多边形查询ToolStripMenuItem
            // 
            this.邻接多边形查询ToolStripMenuItem.Name = "邻接多边形查询ToolStripMenuItem";
            this.邻接多边形查询ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.邻接多边形查询ToolStripMenuItem.Text = "邻接多边形查询";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem,
            this.单一符号化ToolStripMenuItem,
            this.唯一值符号化ToolStripMenuItem,
            this.分类符号化ToolStripMenuItem,
            this.分级符号符号化ToolStripMenuItem,
            this.分级色彩符号化ToolStripMenuItem,
            this.依比例符号化ToolStripMenuItem,
            this.点值符号化ToolStripMenuItem,
            this.统计符号化ToolStripMenuItem});
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(80, 21);
            this.帮助ToolStripMenuItem1.Text = "制作专题图";
            // 
            // 通用符号化ArcGIS桌面有效ToolStripMenuItem
            // 
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem.Name = "通用符号化ArcGIS桌面有效ToolStripMenuItem";
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem.Text = "通用符号化(ArcGIS桌面有效)";
            this.通用符号化ArcGIS桌面有效ToolStripMenuItem.Click += new System.EventHandler(this.通用符号化ArcGIS桌面有效ToolStripMenuItem_Click);
            // 
            // 单一符号化ToolStripMenuItem
            // 
            this.单一符号化ToolStripMenuItem.Name = "单一符号化ToolStripMenuItem";
            this.单一符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.单一符号化ToolStripMenuItem.Text = "单一符号化";
            this.单一符号化ToolStripMenuItem.Click += new System.EventHandler(this.单一符号化ToolStripMenuItem_Click);
            // 
            // 唯一值符号化ToolStripMenuItem
            // 
            this.唯一值符号化ToolStripMenuItem.Name = "唯一值符号化ToolStripMenuItem";
            this.唯一值符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.唯一值符号化ToolStripMenuItem.Text = "唯一值符号化";
            this.唯一值符号化ToolStripMenuItem.Click += new System.EventHandler(this.唯一值符号化ToolStripMenuItem_Click);
            // 
            // 分类符号化ToolStripMenuItem
            // 
            this.分类符号化ToolStripMenuItem.Name = "分类符号化ToolStripMenuItem";
            this.分类符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.分类符号化ToolStripMenuItem.Text = "分类符号化";
            this.分类符号化ToolStripMenuItem.Click += new System.EventHandler(this.分类符号化ToolStripMenuItem_Click);
            // 
            // 分级符号符号化ToolStripMenuItem
            // 
            this.分级符号符号化ToolStripMenuItem.Name = "分级符号符号化ToolStripMenuItem";
            this.分级符号符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.分级符号符号化ToolStripMenuItem.Text = "分级符号符号化";
            this.分级符号符号化ToolStripMenuItem.Click += new System.EventHandler(this.分级符号符号化ToolStripMenuItem_Click);
            // 
            // 分级色彩符号化ToolStripMenuItem
            // 
            this.分级色彩符号化ToolStripMenuItem.Name = "分级色彩符号化ToolStripMenuItem";
            this.分级色彩符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.分级色彩符号化ToolStripMenuItem.Text = "分级色彩符号化";
            this.分级色彩符号化ToolStripMenuItem.Click += new System.EventHandler(this.分级色彩符号化ToolStripMenuItem_Click);
            // 
            // 依比例符号化ToolStripMenuItem
            // 
            this.依比例符号化ToolStripMenuItem.Name = "依比例符号化ToolStripMenuItem";
            this.依比例符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.依比例符号化ToolStripMenuItem.Text = "依比例符号化";
            this.依比例符号化ToolStripMenuItem.Click += new System.EventHandler(this.依比例符号化ToolStripMenuItem_Click);
            // 
            // 点值符号化ToolStripMenuItem
            // 
            this.点值符号化ToolStripMenuItem.Name = "点值符号化ToolStripMenuItem";
            this.点值符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.点值符号化ToolStripMenuItem.Text = "点值符号化";
            this.点值符号化ToolStripMenuItem.Click += new System.EventHandler(this.点值符号化ToolStripMenuItem_Click);
            // 
            // 统计符号化ToolStripMenuItem
            // 
            this.统计符号化ToolStripMenuItem.Name = "统计符号化ToolStripMenuItem";
            this.统计符号化ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.统计符号化ToolStripMenuItem.Text = "统计符号化";
            this.统计符号化ToolStripMenuItem.Click += new System.EventHandler(this.统计符号化ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem2
            // 
            this.帮助ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消编辑UndoToolStripMenuItem,
            this.重做RedoToolStripMenuItem,
            this.启动编辑ToolStripMenuItem,
            this.停止编辑ToolStripMenuItem,
            this.保存编辑ToolStripMenuItem,
            this.查找ToolStripMenuItem,
            this.定位到XYToolStripMenuItem});
            this.帮助ToolStripMenuItem2.Name = "帮助ToolStripMenuItem2";
            this.帮助ToolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem2.Text = "编辑";
            // 
            // 取消编辑UndoToolStripMenuItem
            // 
            this.取消编辑UndoToolStripMenuItem.Name = "取消编辑UndoToolStripMenuItem";
            this.取消编辑UndoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.取消编辑UndoToolStripMenuItem.Text = "取消编辑(Undo)";
            // 
            // 重做RedoToolStripMenuItem
            // 
            this.重做RedoToolStripMenuItem.Name = "重做RedoToolStripMenuItem";
            this.重做RedoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.重做RedoToolStripMenuItem.Text = "重做(Redo)";
            // 
            // 启动编辑ToolStripMenuItem
            // 
            this.启动编辑ToolStripMenuItem.Name = "启动编辑ToolStripMenuItem";
            this.启动编辑ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.启动编辑ToolStripMenuItem.Text = "启动编辑";
            // 
            // 停止编辑ToolStripMenuItem
            // 
            this.停止编辑ToolStripMenuItem.Name = "停止编辑ToolStripMenuItem";
            this.停止编辑ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.停止编辑ToolStripMenuItem.Text = "停止编辑";
            // 
            // 保存编辑ToolStripMenuItem
            // 
            this.保存编辑ToolStripMenuItem.Name = "保存编辑ToolStripMenuItem";
            this.保存编辑ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.保存编辑ToolStripMenuItem.Text = "保存编辑";
            // 
            // 查找ToolStripMenuItem
            // 
            this.查找ToolStripMenuItem.Name = "查找ToolStripMenuItem";
            this.查找ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.查找ToolStripMenuItem.Text = "查找...";
            // 
            // 定位到XYToolStripMenuItem
            // 
            this.定位到XYToolStripMenuItem.Name = "定位到XYToolStripMenuItem";
            this.定位到XYToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.定位到XYToolStripMenuItem.Text = "定位到 XY...";
            // 
            // 帮助ToolStripMenuItem3
            // 
            this.帮助ToolStripMenuItem3.Name = "帮助ToolStripMenuItem3";
            this.帮助ToolStripMenuItem3.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem3.Text = "帮助";
            // 
            // 地图标注ToolStripMenuItem
            // 
            this.地图标注ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标注ToolStripMenuItem});
            this.地图标注ToolStripMenuItem.Name = "地图标注ToolStripMenuItem";
            this.地图标注ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图标注ToolStripMenuItem.Text = "地图标注";
            // 
            // 标注ToolStripMenuItem
            // 
            this.标注ToolStripMenuItem.Name = "标注ToolStripMenuItem";
            this.标注ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.标注ToolStripMenuItem.Text = "标注";
            this.标注ToolStripMenuItem.Click += new System.EventHandler(this.标注ToolStripMenuItem_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            this.skinEngine1.CurrentSkinChanged += new Sunisoft.IrisSkin.SkinChanged(this.skinEngine1_CurrentSkinChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(789, 523);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SdhGIS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGlobeControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建圆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建矩形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地理变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 叠加分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可视域分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可视线分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性条件查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基于空间位置空间关系的查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 邻接多边形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 创建自定义坐标系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGeographicCoordinateSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProjectedCoordinateSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createVerticalCoordinateSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通用符号化ArcGIS桌面有效ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单一符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 唯一值符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分类符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分级符号符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分级色彩符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 依比例符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点值符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 统计符号化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 取消编辑UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重做RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定位到XYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem3;
        private System.Windows.Forms.TabPage tabPage3;
        private ESRI.ArcGIS.Controls.AxSceneControl axSceneControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private ESRI.ArcGIS.Controls.AxGlobeControl axGlobeControl1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 地图标注ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标注ToolStripMenuItem;
    }
}

