namespace Form_list
{
    partial class SWorkOrder
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnWP = new System.Windows.Forms.Button();
            this.btnProcess_S = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlaceGrid = new System.Windows.Forms.DataGridView();
            this.ProcessGrid = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SWorkOrderGrid = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWorkOrderGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.panel3.Size = new System.Drawing.Size(1418, 100);
            this.panel3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("휴먼모음T", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(10, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1398, 43);
            this.textBox2.TabIndex = 31;
            this.textBox2.Text = "생 산 지 시 조 회";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.btnWP);
            this.panel1.Controls.Add(this.btnProcess_S);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 636);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcess.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("휴먼모음T", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(0, 167);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(198, 167);
            this.btnProcess.TabIndex = 39;
            this.btnProcess.Text = "공 정 선 택";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.SeaGreen;
            this.button10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("휴먼모음T", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(0, 476);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(198, 158);
            this.button10.TabIndex = 37;
            this.button10.Text = "작업지시선택";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // btnWP
            // 
            this.btnWP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnWP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnWP.FlatAppearance.BorderSize = 0;
            this.btnWP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnWP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWP.Font = new System.Drawing.Font("휴먼모음T", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWP.ForeColor = System.Drawing.Color.White;
            this.btnWP.Location = new System.Drawing.Point(0, 0);
            this.btnWP.Name = "btnWP";
            this.btnWP.Size = new System.Drawing.Size(198, 167);
            this.btnWP.TabIndex = 36;
            this.btnWP.Text = "작 업 장 선 택";
            this.btnWP.UseVisualStyleBackColor = false;
            this.btnWP.Click += new System.EventHandler(this.btnWP_Click);
            // 
            // btnProcess_S
            // 
            this.btnProcess_S.Location = new System.Drawing.Point(0, 0);
            this.btnProcess_S.Name = "btnProcess_S";
            this.btnProcess_S.Size = new System.Drawing.Size(75, 23);
            this.btnProcess_S.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.PlaceGrid);
            this.panel2.Controls.Add(this.ProcessGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1083, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 636);
            this.panel2.TabIndex = 4;
            // 
            // PlaceGrid
            // 
            this.PlaceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlaceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaceGrid.Location = new System.Drawing.Point(0, 0);
            this.PlaceGrid.Name = "PlaceGrid";
            this.PlaceGrid.RowHeadersWidth = 51;
            this.PlaceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlaceGrid.Size = new System.Drawing.Size(333, 634);
            this.PlaceGrid.TabIndex = 1;
            this.PlaceGrid.Visible = false;
            this.PlaceGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PlaceGrid_CellMouseClick);
            this.PlaceGrid.VisibleChanged += new System.EventHandler(this.btnWP_Click);
            // 
            // ProcessGrid
            // 
            this.ProcessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessGrid.Location = new System.Drawing.Point(0, 0);
            this.ProcessGrid.Name = "ProcessGrid";
            this.ProcessGrid.RowHeadersWidth = 51;
            this.ProcessGrid.Size = new System.Drawing.Size(333, 634);
            this.ProcessGrid.TabIndex = 0;
            this.ProcessGrid.Visible = false;
            this.ProcessGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProcessGrid_CellMouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(200, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(839, 636);
            this.dataGridView1.TabIndex = 5;
            // 
            // SWorkOrderGrid
            // 
            this.SWorkOrderGrid.AllowUserToAddRows = false;
            this.SWorkOrderGrid.AllowUserToDeleteRows = false;
            this.SWorkOrderGrid.AllowUserToResizeColumns = false;
            this.SWorkOrderGrid.AllowUserToResizeRows = false;
            this.SWorkOrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SWorkOrderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SWorkOrderGrid.Location = new System.Drawing.Point(200, 100);
            this.SWorkOrderGrid.Name = "SWorkOrderGrid";
            this.SWorkOrderGrid.RowHeadersWidth = 51;
            this.SWorkOrderGrid.RowTemplate.Height = 23;
            this.SWorkOrderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SWorkOrderGrid.Size = new System.Drawing.Size(883, 636);
            this.SWorkOrderGrid.TabIndex = 5;
            // 
            // SWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1418, 736);
            this.Controls.Add(this.SWorkOrderGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SWorkOrder";
            this.Text = "작업지시조회";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SWorkOrder_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlaceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWorkOrderGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnWP;
        private System.Windows.Forms.Button btnProcess_S;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView SWorkOrderGrid;
        private System.Windows.Forms.DataGridView ProcessGrid;
        private System.Windows.Forms.DataGridView PlaceGrid;
        private System.Windows.Forms.Button button1;
    }
}