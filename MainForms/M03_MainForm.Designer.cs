namespace MainForms
{
    partial class M03_MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.M_TEST = new System.Windows.Forms.ToolStripMenuItem();
            this.RowMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.MF_StockMM = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_StockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.MF_StockMMRec2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MaterialOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.S_MENU = new System.Windows.Forms.ToolStripMenuItem();
            this.Form03_UserMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.Form04_SystemMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsNowDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tacMyTab = new Assamble.MyTabControl();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.LotTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_TEST,
            this.S_MENU});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // M_TEST
            // 
            this.M_TEST.BackColor = System.Drawing.SystemColors.Control;
            this.M_TEST.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RowMaster,
            this.MF_StockMM,
            this.MM_StockOut,
            this.MF_StockMMRec2,
            this.MaterialOrder,
            this.LotTracking});
            this.M_TEST.Name = "M_TEST";
            this.M_TEST.Size = new System.Drawing.Size(43, 20);
            this.M_TEST.Text = "관리";
            this.M_TEST.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_TEST_DropDownItemClicked);
            // 
            // RowMaster
            // 
            this.RowMaster.Name = "RowMaster";
            this.RowMaster.Size = new System.Drawing.Size(182, 22);
            this.RowMaster.Text = "품목 마스터";
            // 
            // MF_StockMM
            // 
            this.MF_StockMM.Name = "MF_StockMM";
            this.MF_StockMM.Size = new System.Drawing.Size(182, 22);
            this.MF_StockMM.Text = "자재 재고 관리";
            // 
            // MM_StockOut
            // 
            this.MM_StockOut.Name = "MM_StockOut";
            this.MM_StockOut.Size = new System.Drawing.Size(182, 22);
            this.MM_StockOut.Text = "자재 출고 등록";
            // 
            // MF_StockMMRec2
            // 
            this.MF_StockMMRec2.Name = "MF_StockMMRec2";
            this.MF_StockMMRec2.Size = new System.Drawing.Size(182, 22);
            this.MF_StockMMRec2.Text = "원자재 입출고 이력";
            // 
            // MaterialOrder
            // 
            this.MaterialOrder.Name = "MaterialOrder";
            this.MaterialOrder.Size = new System.Drawing.Size(182, 22);
            this.MaterialOrder.Text = "원자재 발주 및 입고";
            // 
            // S_MENU
            // 
            this.S_MENU.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form03_UserMaster,
            this.Form04_SystemMaster});
            this.S_MENU.Name = "S_MENU";
            this.S_MENU.Size = new System.Drawing.Size(68, 20);
            this.S_MENU.Text = "LOT 추적";
            this.S_MENU.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_TEST_DropDownItemClicked);
            // 
            // Form03_UserMaster
            // 
            this.Form03_UserMaster.Name = "Form03_UserMaster";
            this.Form03_UserMaster.Size = new System.Drawing.Size(154, 22);
            this.Form03_UserMaster.Text = "작업 지시 등록";
            // 
            // Form04_SystemMaster
            // 
            this.Form04_SystemMaster.Name = "Form04_SystemMaster";
            this.Form04_SystemMaster.Size = new System.Drawing.Size(154, 22);
            this.Form04_SystemMaster.Text = "시스템관리";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sts,
            this.toolStripStatusLabel2,
            this.stsUserName,
            this.stsNowDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1081, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sts
            // 
            this.sts.Name = "sts";
            this.sts.Size = new System.Drawing.Size(67, 17);
            this.sts.Text = "FormName";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(854, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // stsUserName
            // 
            this.stsUserName.Name = "stsUserName";
            this.stsUserName.Size = new System.Drawing.Size(62, 17);
            this.stsUserName.Text = "UserName";
            // 
            // stsNowDateTime
            // 
            this.stsNowDateTime.Name = "stsNowDateTime";
            this.stsNowDateTime.Size = new System.Drawing.Size(83, 17);
            this.stsNowDateTime.Text = "NowDateTime";
            // 
            // tacMyTab
            // 
            this.tacMyTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacMyTab.Location = new System.Drawing.Point(0, 118);
            this.tacMyTab.Name = "tacMyTab";
            this.tacMyTab.SelectedIndex = 0;
            this.tacMyTab.Size = new System.Drawing.Size(1081, 485);
            this.tacMyTab.TabIndex = 7;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 94);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.tsbAdd,
            this.tsbDelete,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbClose,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1081, 94);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = global::MainForms.Properties.Resources.조회;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(58, 91);
            this.tsbSearch.Text = "조회";
            this.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSearch.Click += new System.EventHandler(this.ToolButton_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::MainForms.Properties.Resources.추가;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(48, 91);
            this.tsbAdd.Text = "추가";
            this.tsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.Click += new System.EventHandler(this.ToolButton_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::MainForms.Properties.Resources.삭제;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(48, 91);
            this.tsbDelete.Text = "삭제";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.ToolButton_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::MainForms.Properties.Resources.저장;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(48, 91);
            this.tsbSave.Text = "저장";
            this.tsbSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.ToolButton_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::MainForms.Properties.Resources.닫기;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(58, 91);
            this.tsbClose.Text = "닫기";
            this.tsbClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::MainForms.Properties.Resources.종료;
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(48, 91);
            this.tsbExit.Text = "종료";
            this.tsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // LotTracking
            // 
            this.LotTracking.Name = "LotTracking";
            this.LotTracking.Size = new System.Drawing.Size(182, 22);
            this.LotTracking.Text = "LOT 추적";
            // 
            // M03_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 625);
            this.Controls.Add(this.tacMyTab);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "M03_MainForm";
            this.Text = "LOT 추적 관리 시스템";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.M03_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.M03_MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem M_TEST;
        private System.Windows.Forms.ToolStripMenuItem RowMaster;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel stsUserName;
        private System.Windows.Forms.ToolStripStatusLabel stsNowDateTime;
        private Assamble.MyTabControl tacMyTab;
        private System.Windows.Forms.ToolStripMenuItem S_MENU;
        private System.Windows.Forms.ToolStripMenuItem Form03_UserMaster;
        private System.Windows.Forms.ToolStripMenuItem Form04_SystemMaster;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem MF_StockMMRec2;
        private System.Windows.Forms.ToolStripMenuItem MF_StockMM;
        private System.Windows.Forms.ToolStripMenuItem MM_StockOut;
        private System.Windows.Forms.ToolStripMenuItem MaterialOrder;
        private System.Windows.Forms.ToolStripMenuItem LotTracking;
    }
}