namespace Pos
{
    partial class FrmVendorEdit
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
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bankno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.fax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkman = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.descn = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(173, 251);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(83, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保 存(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(304, 251);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(83, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "关 闭(&C)";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 220);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bankno);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.bankName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.url);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.email);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.fax);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.address);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.mob);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.linkman);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.name);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bankno
            // 
            this.bankno.Location = new System.Drawing.Point(383, 159);
            this.bankno.Name = "bankno";
            this.bankno.Size = new System.Drawing.Size(138, 21);
            this.bankno.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(318, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "银行帐号：";
            // 
            // bankName
            // 
            this.bankName.FormattingEnabled = true;
            this.bankName.Location = new System.Drawing.Point(92, 160);
            this.bankName.Name = "bankName";
            this.bankName.Size = new System.Drawing.Size(197, 20);
            this.bankName.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "开户银行：";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(93, 130);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(288, 21);
            this.url.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "网址：";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(383, 100);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(138, 21);
            this.email.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "邮箱：";
            // 
            // fax
            // 
            this.fax.Location = new System.Drawing.Point(93, 100);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(124, 21);
            this.fax.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "传真：";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(93, 71);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(426, 21);
            this.address.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "联系地址：";
            // 
            // mob
            // 
            this.mob.Location = new System.Drawing.Point(383, 44);
            this.mob.Name = "mob";
            this.mob.Size = new System.Drawing.Size(138, 21);
            this.mob.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "手机：";
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(93, 41);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(128, 21);
            this.tel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "联系电话：";
            // 
            // linkman
            // 
            this.linkman.Location = new System.Drawing.Point(383, 14);
            this.linkman.Name = "linkman";
            this.linkman.Size = new System.Drawing.Size(138, 21);
            this.linkman.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "联系人：";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(92, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(218, 21);
            this.name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "供应商名称：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.descn);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "资料备注";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // descn
            // 
            this.descn.Location = new System.Drawing.Point(17, 16);
            this.descn.Multiline = true;
            this.descn.Name = "descn";
            this.descn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descn.Size = new System.Drawing.Size(506, 162);
            this.descn.TabIndex = 20;
            // 
            // EditSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 286);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改供应商资料";
            this.Load += new System.EventHandler(this.EditSupplierForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox bankno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox bankName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox fax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox linkman;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox descn;
    }
}