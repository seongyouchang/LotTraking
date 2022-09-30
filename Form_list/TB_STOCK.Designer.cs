namespace Form_list
{
    partial class TB_STOCK
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
            this.tstUserId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GridStockMMRec2 = new System.Windows.Forms.DataGridView();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.cboRowname = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridStockMMRec2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRowname);
            this.groupBox1.Controls.Add(this.txtLotNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tstUserId);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1264, 100);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridStockMMRec2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1264, 600);
            // 
            // tstUserId
            // 
            this.tstUserId.AutoSize = true;
            this.tstUserId.Location = new System.Drawing.Point(455, 54);
            this.tstUserId.Name = "tstUserId";
            this.tstUserId.Size = new System.Drawing.Size(53, 12);
            this.tstUserId.TabIndex = 4;
            this.tstUserId.Text = "LOT번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "품목";
            // 
            // GridStockMMRec2
            // 
            this.GridStockMMRec2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridStockMMRec2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridStockMMRec2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridStockMMRec2.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.GridStockMMRec2.Location = new System.Drawing.Point(3, 16);
            this.GridStockMMRec2.Name = "GridStockMMRec2";
            this.GridStockMMRec2.RowTemplate.Height = 23;
            this.GridStockMMRec2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridStockMMRec2.Size = new System.Drawing.Size(1258, 582);
            this.GridStockMMRec2.TabIndex = 34;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(514, 49);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(200, 21);
            this.txtLotNo.TabIndex = 39;
            // 
            // cboRowname
            // 
            this.cboRowname.FormattingEnabled = true;
            this.cboRowname.Location = new System.Drawing.Point(319, 49);
            this.cboRowname.Name = "cboRowname";
            this.cboRowname.Size = new System.Drawing.Size(121, 20);
            this.cboRowname.TabIndex = 40;
            // 
            // TB_STOCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 700);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TB_STOCK";
            this.Text = "";
            this.Load += new System.EventHandler(this.StockMMRec2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridStockMMRec2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tstUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GridStockMMRec2;
        private System.Windows.Forms.ComboBox cboRowname;
        private System.Windows.Forms.TextBox txtLotNo;
    }
}