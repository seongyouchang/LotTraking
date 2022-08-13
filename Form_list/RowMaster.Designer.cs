namespace Form_list
{
    partial class RowMaster
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
            this.txtRowName = new System.Windows.Forms.TextBox();
            this.txtiLROW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textRowAccount = new System.Windows.Forms.TextBox();
            this.textRowStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GridRowMaster = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRowMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRowStock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textRowAccount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtiLROW);
            this.groupBox1.Controls.Add(this.txtRowName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tstUserId);
            this.groupBox1.Size = new System.Drawing.Size(899, 125);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridRowMaster);
            this.groupBox2.Size = new System.Drawing.Size(899, 325);
            // 
            // tstUserId
            // 
            this.tstUserId.AutoSize = true;
            this.tstUserId.Location = new System.Drawing.Point(219, 56);
            this.tstUserId.Name = "tstUserId";
            this.tstUserId.Size = new System.Drawing.Size(67, 15);
            this.tstUserId.TabIndex = 4;
            this.tstUserId.Text = "원자재명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "원자재번호";
            // 
            // txtRowName
            // 
            this.txtRowName.Location = new System.Drawing.Point(292, 53);
            this.txtRowName.Name = "txtRowName";
            this.txtRowName.Size = new System.Drawing.Size(100, 25);
            this.txtRowName.TabIndex = 7;
            // 
            // txtiLROW
            // 
            this.txtiLROW.Location = new System.Drawing.Point(106, 53);
            this.txtiLROW.Name = "txtiLROW";
            this.txtiLROW.Size = new System.Drawing.Size(100, 25);
            this.txtiLROW.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "원자재 거래처";
            // 
            // textRowAccount
            // 
            this.textRowAccount.Location = new System.Drawing.Point(506, 53);
            this.textRowAccount.Name = "textRowAccount";
            this.textRowAccount.Size = new System.Drawing.Size(100, 25);
            this.textRowAccount.TabIndex = 10;
            // 
            // textRowStock
            // 
            this.textRowStock.Location = new System.Drawing.Point(756, 56);
            this.textRowStock.Name = "textRowStock";
            this.textRowStock.Size = new System.Drawing.Size(100, 25);
            this.textRowStock.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "원자재 입고일자";
            // 
            // GridRowMaster
            // 
            this.GridRowMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRowMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridRowMaster.Location = new System.Drawing.Point(3, 22);
            this.GridRowMaster.Name = "GridRowMaster";
            this.GridRowMaster.RowHeadersWidth = 51;
            this.GridRowMaster.RowTemplate.Height = 27;
            this.GridRowMaster.Size = new System.Drawing.Size(893, 299);
            this.GridRowMaster.TabIndex = 0;
            // 
            // RowMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "RowMaster";
            this.Text = "품목 마스터";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRowMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tstUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRowStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRowAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtiLROW;
        private System.Windows.Forms.TextBox txtRowName;
        private System.Windows.Forms.DataGridView GridRowMaster;
    }
}