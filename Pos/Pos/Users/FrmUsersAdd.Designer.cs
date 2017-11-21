namespace Pos
{
    partial class FrmUsersAdd
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
            this.label6 = new System.Windows.Forms.Label();
            this.sex1 = new System.Windows.Forms.RadioButton();
            this.sex = new System.Windows.Forms.RadioButton();
            this.memo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.flag1 = new System.Windows.Forms.RadioButton();
            this.flag = new System.Windows.Forms.RadioButton();
            this.password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.password2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(161, 314);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "保 存(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(308, 313);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "关 闭(&C)";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 293);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.sex1);
            this.tabPage1.Controls.Add(this.sex);
            this.tabPage1.Controls.Add(this.memo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.address);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.mob);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tel);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.name);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "性别：";
            // 
            // sex1
            // 
            this.sex1.AutoSize = true;
            this.sex1.Location = new System.Drawing.Point(403, 15);
            this.sex1.Name = "sex1";
            this.sex1.Size = new System.Drawing.Size(47, 16);
            this.sex1.TabIndex = 23;
            this.sex1.TabStop = true;
            this.sex1.Text = "女士";
            this.sex1.UseVisualStyleBackColor = true;
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Checked = true;
            this.sex.Location = new System.Drawing.Point(337, 15);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(47, 16);
            this.sex.TabIndex = 22;
            this.sex.TabStop = true;
            this.sex.Text = "先生";
            this.sex.UseVisualStyleBackColor = true;
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(85, 115);
            this.memo.Multiline = true;
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(409, 137);
            this.memo.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "资料备注：";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(85, 76);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(409, 21);
            this.address.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "联系地址：";
            // 
            // mob
            // 
            this.mob.Location = new System.Drawing.Point(337, 43);
            this.mob.Name = "mob";
            this.mob.Size = new System.Drawing.Size(157, 21);
            this.mob.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "手机：";
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(85, 43);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(157, 21);
            this.tel.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "联系电话：";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(85, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(157, 21);
            this.name.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "员工姓名：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.password2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.flag1);
            this.tabPage2.Controls.Add(this.flag);
            this.tabPage2.Controls.Add(this.password);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.userName);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "帐号信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "权限：";
            // 
            // flag1
            // 
            this.flag1.AutoSize = true;
            this.flag1.Location = new System.Drawing.Point(268, 152);
            this.flag1.Name = "flag1";
            this.flag1.Size = new System.Drawing.Size(71, 16);
            this.flag1.TabIndex = 5;
            this.flag1.Text = "超级帐号";
            this.flag1.UseVisualStyleBackColor = true;
            // 
            // flag
            // 
            this.flag.AutoSize = true;
            this.flag.Checked = true;
            this.flag.Location = new System.Drawing.Point(174, 152);
            this.flag.Name = "flag";
            this.flag.Size = new System.Drawing.Size(71, 16);
            this.flag.TabIndex = 4;
            this.flag.TabStop = true;
            this.flag.Text = "普通帐号";
            this.flag.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(173, 82);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(265, 21);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "密码：";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(173, 49);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(265, 21);
            this.userName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "用户名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "确认密码：";
            // 
            // password2
            // 
            this.password2.Location = new System.Drawing.Point(173, 116);
            this.password2.Name = "password2";
            this.password2.Size = new System.Drawing.Size(265, 21);
            this.password2.TabIndex = 8;
            this.password2.UseSystemPasswordChar = true;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 346);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加员工";
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox mob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.RadioButton sex1;
        private System.Windows.Forms.RadioButton sex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton flag;
        private System.Windows.Forms.RadioButton flag1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox password2;
    }
}