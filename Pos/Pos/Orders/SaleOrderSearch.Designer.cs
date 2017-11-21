namespace Pos.Orders
{
    partial class SaleOrderSearch
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataBaseDataSet4 = new Pos.DataBaseDataSet4();
            this.dbSaleProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_SaleProductsTableAdapter = new Pos.DataBaseDataSet4TableAdapters.db_SaleProductsTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataBaseDataSet5 = new Pos.DataBaseDataSet5();
            this.dbSaleOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_SaleOrdersTableAdapter = new Pos.DataBaseDataSet5TableAdapters.db_SaleOrdersTableAdapter();
            this.orderIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbSaleProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbSaleOrdersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售商品明细";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单明细";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.productNoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.colorNameDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.sellPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dbSaleProductsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(784, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataBaseDataSet4
            // 
            this.dataBaseDataSet4.DataSetName = "DataBaseDataSet4";
            this.dataBaseDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbSaleProductsBindingSource
            // 
            this.dbSaleProductsBindingSource.DataMember = "db_SaleProducts";
            this.dbSaleProductsBindingSource.DataSource = this.dataBaseDataSet4;
            // 
            // db_SaleProductsTableAdapter
            // 
            this.db_SaleProductsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn1,
            this.orderDateDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.saleNameDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.dbSaleOrdersBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(6, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(549, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataBaseDataSet5
            // 
            this.dataBaseDataSet5.DataSetName = "DataBaseDataSet5";
            this.dataBaseDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbSaleOrdersBindingSource
            // 
            this.dbSaleOrdersBindingSource.DataMember = "db_SaleOrders";
            this.dbSaleOrdersBindingSource.DataSource = this.dataBaseDataSet5;
            // 
            // db_SaleOrdersTableAdapter
            // 
            this.db_SaleOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // orderIDDataGridViewTextBoxColumn1
            // 
            this.orderIDDataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn1.HeaderText = "订单号";
            this.orderIDDataGridViewTextBoxColumn1.Name = "orderIDDataGridViewTextBoxColumn1";
            this.orderIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "下单时间";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "顾客名称";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleNameDataGridViewTextBoxColumn
            // 
            this.saleNameDataGridViewTextBoxColumn.DataPropertyName = "SaleName";
            this.saleNameDataGridViewTextBoxColumn.HeaderText = "经手人";
            this.saleNameDataGridViewTextBoxColumn.Name = "saleNameDataGridViewTextBoxColumn";
            this.saleNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "总价";
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品名\r\n";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(561, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "经手人";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(633, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "下单时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(633, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(157, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "订单号";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNoDataGridViewTextBoxColumn
            // 
            this.productNoDataGridViewTextBoxColumn.DataPropertyName = "ProductNo";
            this.productNoDataGridViewTextBoxColumn.HeaderText = "商品编号";
            this.productNoDataGridViewTextBoxColumn.Name = "productNoDataGridViewTextBoxColumn";
            this.productNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "商品名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "颜色";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitNameDataGridViewTextBoxColumn
            // 
            this.unitNameDataGridViewTextBoxColumn.DataPropertyName = "UnitName";
            this.unitNameDataGridViewTextBoxColumn.HeaderText = "单位";
            this.unitNameDataGridViewTextBoxColumn.Name = "unitNameDataGridViewTextBoxColumn";
            this.unitNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "数量";
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "SellPrice";
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "售价";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SaleOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SaleOrderSearch";
            this.Size = new System.Drawing.Size(830, 426);
            this.Load += new System.EventHandler(this.SaleOrderSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbSaleProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbSaleOrdersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dbSaleProductsBindingSource;
        private DataBaseDataSet4 dataBaseDataSet4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dbSaleOrdersBindingSource;
        private DataBaseDataSet5 dataBaseDataSet5;
        private DataBaseDataSet4TableAdapters.db_SaleProductsTableAdapter db_SaleProductsTableAdapter;
        private DataBaseDataSet5TableAdapters.db_SaleOrdersTableAdapter db_SaleOrdersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
    }
}
