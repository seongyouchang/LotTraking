namespace MainForms
{
    partial class M02_PassWordChange
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
            this.txtPerPW = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPWChange = new System.Windows.Forms.Button();
            this.txtChangPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPerPW
            // 
            this.txtPerPW.Location = new System.Drawing.Point(124, 85);
            this.txtPerPW.Name = "txtPerPW";
            this.txtPerPW.PasswordChar = '*';
            this.txtPerPW.Size = new System.Drawing.Size(173, 21);
            this.txtPerPW.TabIndex = 7;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(124, 44);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(173, 21);
            this.txtUserID.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "기존 P/W";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "사용자 ID";
            // 
            // btnPWChange
            // 
            this.btnPWChange.Location = new System.Drawing.Point(222, 174);
            this.btnPWChange.Name = "btnPWChange";
            this.btnPWChange.Size = new System.Drawing.Size(75, 47);
            this.btnPWChange.TabIndex = 8;
            this.btnPWChange.Text = "비밀번호 변경";
            this.btnPWChange.UseVisualStyleBackColor = true;
            this.btnPWChange.Click += new System.EventHandler(this.btnPWChange_Click);
            // 
            // txtChangPW
            // 
            this.txtChangPW.Location = new System.Drawing.Point(124, 132);
            this.txtChangPW.Name = "txtChangPW";
            this.txtChangPW.PasswordChar = '*';
            this.txtChangPW.Size = new System.Drawing.Size(173, 21);
            this.txtChangPW.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "변경 P/W";
            // 
            // M02_PassWordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 248);
            this.Controls.Add(this.txtChangPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPWChange);
            this.Controls.Add(this.txtPerPW);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "M02_PassWordChange";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPerPW;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPWChange;
        private System.Windows.Forms.TextBox txtChangPW;
        private System.Windows.Forms.Label label3;
    }
}