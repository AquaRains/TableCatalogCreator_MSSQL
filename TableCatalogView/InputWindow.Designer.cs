namespace TableCatalogView
{
    partial class InputWindow
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
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(73, 12);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(101, 21);
            this.txt1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(73, 39);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(101, 21);
            this.txt2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "DBName";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(73, 66);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(101, 21);
            this.txt3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID";
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(73, 93);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(101, 21);
            this.txt4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pass";
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(73, 120);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(101, 21);
            this.txt5.TabIndex = 5;
            this.txt5.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // InputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 200);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label2);
            this.Name = "InputWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.Button button1;
    }
}