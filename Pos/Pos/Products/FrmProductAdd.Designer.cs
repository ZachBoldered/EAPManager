namespace Pos
{
    partial class FrmProductAdd
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
            this.name = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sellPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.spec = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.costPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.unitName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.productNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.saveButton.Location = new System.Drawing.Point(186, 208);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "保 存(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(300, 208);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
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
            this.tabControl1.Size = new System.Drawing.Size(568, 181);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.name);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.sellPrice);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.spec);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.costPrice);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.unitName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.colorName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.productNo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.FormattingEnabled = true;
            this.name.Location = new System.Drawing.Point(91, 10);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(317, 20);
            this.name.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(522, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "元";
            // 
            // sellPrice
            // 
            this.sellPrice.Location = new System.Drawing.Point(395, 118);
            this.sellPrice.Name = "sellPrice";
            this.sellPrice.Size = new System.Drawing.Size(121, 21);
            this.sellPrice.TabIndex = 21;
            this.sellPrice.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(339, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "零售价：";
            // 
            // spec
            // 
            this.spec.FormattingEnabled = true;
            this.spec.Location = new System.Drawing.Point(91, 91);
            this.spec.Name = "spec";
            this.spec.Size = new System.Drawing.Size(248, 20);
            this.spec.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "规格：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "元";
            // 
            // costPrice
            // 
            this.costPrice.Location = new System.Drawing.Point(91, 118);
            this.costPrice.Name = "costPrice";
            this.costPrice.Size = new System.Drawing.Size(111, 21);
            this.costPrice.TabIndex = 13;
            this.costPrice.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "进价：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(234, 42);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(161, 12);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "如果为空系统会自动产生编号";
            // 
            // unitName
            // 
            this.unitName.FormattingEnabled = true;
            this.unitName.Location = new System.Drawing.Point(395, 65);
            this.unitName.Name = "unitName";
            this.unitName.Size = new System.Drawing.Size(121, 20);
            this.unitName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "单位：";
            // 
            // colorName
            // 
            this.colorName.FormattingEnabled = true;
            this.colorName.Location = new System.Drawing.Point(91, 65);
            this.colorName.Name = "colorName";
            this.colorName.Size = new System.Drawing.Size(121, 20);
            this.colorName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "颜色：";
            // 
            // productNo
            // 
            this.productNo.Location = new System.Drawing.Point(91, 37);
            this.productNo.Name = "productNo";
            this.productNo.Size = new System.Drawing.Size(121, 21);
            this.productNo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "产品编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "产品名称：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.descn);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 156);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "资料备注";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // descn
            // 
            this.descn.Location = new System.Drawing.Point(17, 17);
            this.descn.Multiline = true;
            this.descn.Name = "descn";
            this.descn.Size = new System.Drawing.Size(525, 122);
            this.descn.TabIndex = 10;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 246);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增产品资料";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
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
        private System.Windows.Forms.TextBox productNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox colorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox unitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox costPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sellPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox spec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox descn;
        private System.Windows.Forms.ComboBox name;
    }
}