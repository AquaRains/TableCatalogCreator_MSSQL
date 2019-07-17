namespace TableCatalogView
{
    partial class Form1
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
            this.listTbName = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNull = new System.Windows.Forms.TextBox();
            this.txtTbName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConstraint = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtConstraintCol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listTbName
            // 
            this.listTbName.FormattingEnabled = true;
            this.listTbName.ItemHeight = 12;
            this.listTbName.Location = new System.Drawing.Point(15, 38);
            this.listTbName.Name = "listTbName";
            this.listTbName.Size = new System.Drawing.Size(177, 520);
            this.listTbName.TabIndex = 0;
            this.listTbName.Click += new System.EventHandler(this.ListTbName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table Name";
            // 
            // txtColno
            // 
            this.txtColno.Location = new System.Drawing.Point(200, 68);
            this.txtColno.Multiline = true;
            this.txtColno.Name = "txtColno";
            this.txtColno.Size = new System.Drawing.Size(46, 370);
            this.txtColno.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Col.No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Col.Name";
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(250, 68);
            this.txtColName.Multiline = true;
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(204, 370);
            this.txtColName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Col.description";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(460, 68);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(204, 370);
            this.txtDesc.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "datatype";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(672, 68);
            this.txtType.Multiline = true;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(94, 370);
            this.txtType.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(777, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "pk";
            // 
            // txtPk
            // 
            this.txtPk.Location = new System.Drawing.Point(774, 68);
            this.txtPk.Multiline = true;
            this.txtPk.Name = "txtPk";
            this.txtPk.Size = new System.Drawing.Size(52, 370);
            this.txtPk.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(835, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "NULL";
            // 
            // txtNull
            // 
            this.txtNull.Location = new System.Drawing.Point(832, 68);
            this.txtNull.Multiline = true;
            this.txtNull.Name = "txtNull";
            this.txtNull.Size = new System.Drawing.Size(52, 370);
            this.txtNull.TabIndex = 2;
            // 
            // txtTbName
            // 
            this.txtTbName.Location = new System.Drawing.Point(284, 8);
            this.txtTbName.Name = "txtTbName";
            this.txtTbName.Size = new System.Drawing.Size(206, 21);
            this.txtTbName.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "connection setting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "GET list";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(203, 450);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Constraint info";
            // 
            // txtConstraint
            // 
            this.txtConstraint.Location = new System.Drawing.Point(200, 465);
            this.txtConstraint.Multiline = true;
            this.txtConstraint.Name = "txtConstraint";
            this.txtConstraint.Size = new System.Drawing.Size(168, 93);
            this.txtConstraint.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 450);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "Constraint columns";
            // 
            // txtConstraintCol
            // 
            this.txtConstraintCol.Location = new System.Drawing.Point(374, 465);
            this.txtConstraintCol.Multiline = true;
            this.txtConstraintCol.Name = "txtConstraintCol";
            this.txtConstraintCol.Size = new System.Drawing.Size(510, 93);
            this.txtConstraintCol.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 570);
            this.Controls.Add(this.txtConstraintCol);
            this.Controls.Add(this.txtConstraint);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTbName);
            this.Controls.Add(this.txtNull);
            this.Controls.Add(this.txtPk);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtColName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtColno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listTbName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listTbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNull;
        private System.Windows.Forms.TextBox txtTbName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtConstraint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConstraintCol;
    }
}

