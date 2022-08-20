namespace Form_list
{
    partial class Worker
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.부서 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.electricGrid1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electricGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(0, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 101);
            this.button1.TabIndex = 1;
            this.button1.Text = "전기부 ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(0, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(309, 101);
            this.button2.TabIndex = 2;
            this.button2.Text = "용접부 ";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(0, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(309, 101);
            this.button3.TabIndex = 3;
            this.button3.Text = "시설부 ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(0, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(309, 101);
            this.button4.TabIndex = 4;
            this.button4.Text = "물류부 ";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(0, 483);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(309, 101);
            this.button5.TabIndex = 5;
            this.button5.Text = "수리부 ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // 부서
            // 
            this.부서.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.부서.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.부서.Location = new System.Drawing.Point(0, 0);
            this.부서.Name = "부서";
            this.부서.Size = new System.Drawing.Size(309, 101);
            this.부서.TabIndex = 6;
            this.부서.Text = "부서";
            this.부서.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.부서);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 616);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // electricGrid1
            // 
            this.electricGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.electricGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricGrid1.Location = new System.Drawing.Point(313, 0);
            this.electricGrid1.Name = "electricGrid1";
            this.electricGrid1.RowTemplate.Height = 23;
            this.electricGrid1.Size = new System.Drawing.Size(864, 616);
            this.electricGrid1.TabIndex = 9;
            // 
            // Worker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 616);
            this.Controls.Add(this.electricGrid1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Worker";
            this.Text = "Worker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.electricGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button 부서;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView electricGrid1;
    }
}