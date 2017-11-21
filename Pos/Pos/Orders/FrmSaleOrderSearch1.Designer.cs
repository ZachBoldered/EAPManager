namespace Pos
{
    partial class FrmSaleOrderSearch1
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
            this.label4 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.customerName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saleName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.customerName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.saleName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "到";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(250, 28);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(109, 21);
            this.endDate.TabIndex = 6;
            // 
            // customerName
            // 
            this.customerName.FormattingEnabled = true;
            this.customerName.Location = new System.Drawing.Point(277, 71);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(130, 20);
            this.customerName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户：";
            // 
            // saleName
            // 
            this.saleName.FormattingEnabled = true;
            this.saleName.Location = new System.Drawing.Point(86, 72);
            this.saleName.Name = "saleName";
            this.saleName.Size = new System.Drawing.Size(109, 20);
            this.saleName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "经手人：";
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(86, 28);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(109, 21);
            this.startDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "退货时间：";
            // 
            // searchButton
            // 
            this.searchButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.searchButton.Location = new System.Drawing.Point(123, 139);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "查 询(&Q)";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(246, 139);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "关 闭(&C)";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SearchSaleOrderForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 174);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchSaleOrderForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售退货单查询";
            this.Load += new System.EventHandler(this.SearchSaleOrderForm1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.ComboBox customerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox saleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button closeButton;
    }
}