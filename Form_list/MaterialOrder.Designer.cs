
namespace Form_list
{
    partial class MaterialOrder
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboAccount = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPono = new System.Windows.Forms.TextBox();
            this.txtRowname = new System.Windows.Forms.Label();
            this.cboRowname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.btnInput = new System.Windows.Forms.Button();
            this.GridOrder = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInput);
            this.groupBox1.Controls.Add(this.cboEnd);
            this.groupBox1.Controls.Add(this.cboStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRowname);
            this.groupBox1.Controls.Add(this.cboRowname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPono);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cboAccount);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridOrder);
            // 
            // cboAccount
            // 
            this.cboAccount.Location = new System.Drawing.Point(135, 30);
            this.cboAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(88, 21);
            this.cboAccount.TabIndex = 1;
            // 
            // txtAccount
            // 
            this.txtAccount.AutoSize = true;
            this.txtAccount.Location = new System.Drawing.Point(44, 33);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(41, 12);
            this.txtAccount.TabIndex = 2;
            this.txtAccount.Text = "거래처";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "발주번호";
            // 
            // txtPono
            // 
            this.txtPono.Location = new System.Drawing.Point(360, 28);
            this.txtPono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPono.Name = "txtPono";
            this.txtPono.Size = new System.Drawing.Size(88, 21);
            this.txtPono.TabIndex = 3;
            // 
            // txtRowname
            // 
            this.txtRowname.AutoSize = true;
            this.txtRowname.Location = new System.Drawing.Point(44, 69);
            this.txtRowname.Name = "txtRowname";
            this.txtRowname.Size = new System.Drawing.Size(29, 12);
            this.txtRowname.TabIndex = 6;
            this.txtRowname.Text = "품목";
            // 
            // cboRowname
            // 
            this.cboRowname.Location = new System.Drawing.Point(135, 66);
            this.cboRowname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboRowname.Name = "cboRowname";
            this.cboRowname.Size = new System.Drawing.Size(88, 21);
            this.cboRowname.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "발주일자";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "~";
            // 
            // cboStart
            // 
            this.cboStart.DateButtons.Add(dateButton2);
            this.cboStart.Location = new System.Drawing.Point(360, 65);
            this.cboStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboStart.Name = "cboStart";
            this.cboStart.NonAutoSizeHeight = 25;
            this.cboStart.Size = new System.Drawing.Size(106, 21);
            this.cboStart.TabIndex = 13;
            this.cboStart.Value = new System.DateTime(2022, 9, 1, 0, 0, 0, 0);
            // 
            // cboEnd
            // 
            this.cboEnd.DateButtons.Add(dateButton1);
            this.cboEnd.Location = new System.Drawing.Point(511, 65);
            this.cboEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEnd.Name = "cboEnd";
            this.cboEnd.NonAutoSizeHeight = 25;
            this.cboEnd.Size = new System.Drawing.Size(106, 21);
            this.cboEnd.TabIndex = 14;
            this.cboEnd.Value = new System.DateTime(2022, 9, 1, 0, 0, 0, 0);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(651, 66);
            this.btnInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(66, 18);
            this.btnInput.TabIndex = 15;
            this.btnInput.Text = "입고등록";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // GridOrder
            // 
            this.GridOrder.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("휴먼모음T", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridOrder.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("휴먼모음T", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridOrder.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.GridOrder.Location = new System.Drawing.Point(3, 17);
            this.GridOrder.Name = "GridOrder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("휴먼모음T", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridOrder.RowHeadersWidth = 51;
            this.GridOrder.RowTemplate.Height = 23;
            this.GridOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridOrder.Size = new System.Drawing.Size(794, 330);
            this.GridOrder.TabIndex = 38;
            // 
            // MaterialOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MaterialOrder";
            this.Load += new System.EventHandler(this.MaterialOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtRowname;
        private System.Windows.Forms.TextBox cboRowname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPono;
        private System.Windows.Forms.Label txtAccount;
        private System.Windows.Forms.TextBox cboAccount;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEnd;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboStart;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.DataGridView GridOrder;
    }
}
