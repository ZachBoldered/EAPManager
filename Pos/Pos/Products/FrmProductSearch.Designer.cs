namespace Pos
{
    partial class FrmProductSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.color);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.productNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // productName
            // 
            this.productName.Location = new System.Drawing.Point(93, 20);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(253, 21);
            this.productName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "产品名称：";
            // 
            // color
            // 
            this.color.FormattingEnabled = true;
            this.color.Location = new System.Drawing.Point(294, 59);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(121, 20);
            this.color.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "颜色：";
            // 
            // productNo
            // 
            this.productNo.Location = new System.Drawing.Point(93, 59);
            this.productNo.Name = "productNo";
            this.productNo.Size = new System.Drawing.Size(108, 21);
            this.productNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号：";
            // 
            // searchButton
            // 
            this.searchButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.searchButton.Location = new System.Drawing.Point(138, 123);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "查 询(&Q)";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(266, 123);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "关 闭(&C)";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SearchProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 161);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品查询";
            this.Load += new System.EventHandler(this.SearchProductForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productName;
    }
}