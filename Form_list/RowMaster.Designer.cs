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
            this.GridRowMaster = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRowMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRowAccount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtiLROW);
            this.groupBox1.Controls.Add(this.txtRowName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tstUserId);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(787, 100);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridRowMaster);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(787, 260);
            // 
            // tstUserId
            // 
            this.tstUserId.AutoSize = true;
            this.tstUserId.Location = new System.Drawing.Point(306, 52);
            this.tstUserId.Name = "tstUserId";
            this.tstUserId.Size = new System.Drawing.Size(53, 12);
            this.tstUserId.TabIndex = 4;
            this.tstUserId.Text = "원자재명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "원자재번호";
            // 
            // txtRowName
            // 
            this.txtRowName.Location = new System.Drawing.Point(370, 49);
            this.txtRowName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRowName.Name = "txtRowName";
            this.txtRowName.Size = new System.Drawing.Size(88, 21);
            this.txtRowName.TabIndex = 7;
            // 
            // txtiLROW
            // 
            this.txtiLROW.Location = new System.Drawing.Point(207, 49);
            this.txtiLROW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtiLROW.Name = "txtiLROW";
            this.txtiLROW.Size = new System.Drawing.Size(88, 21);
            this.txtiLROW.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "원자재 거래처";
            // 
            // textRowAccount
            // 
            this.textRowAccount.Location = new System.Drawing.Point(557, 49);
            this.textRowAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textRowAccount.Name = "textRowAccount";
            this.textRowAccount.Size = new System.Drawing.Size(88, 21);
            this.textRowAccount.TabIndex = 10;
            // 
            // GridRowMaster
            // 
            this.GridRowMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRowMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridRowMaster.Location = new System.Drawing.Point(3, 16);
            this.GridRowMaster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridRowMaster.Name = "GridRowMaster";
            this.GridRowMaster.RowHeadersWidth = 51;
            this.GridRowMaster.RowTemplate.Height = 27;
            this.GridRowMaster.Size = new System.Drawing.Size(781, 242);
            this.GridRowMaster.TabIndex = 0;
            // 
            // RowMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 360);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RowMaster";
            this.Text = "품목 마스터";
            this.Load += new System.EventHandler(this.RowMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRowMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tstUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRowAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtiLROW;
        private System.Windows.Forms.TextBox txtRowName;
        private System.Windows.Forms.DataGridView GridRowMaster;
    }
}