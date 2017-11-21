namespace Pos.Orders
{
    partial class BuyOrderSearch
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbBuyProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBaseDataSet2 = new Pos.DataBaseDataSet2();
            this.BPsearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dbProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBaseDataSet1 = new Pos.DataBaseDataSet1();
            this.label2 = new System.Windows.Forms.Label();
            this.db_ProductsTableAdapter = new Pos.DataBaseDataSet1TableAdapters.db_ProductsTableAdapter();
            this.db_BuyProductsTableAdapter = new Pos.DataBaseDataSet2TableAdapters.db_BuyProductsTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BOsearch = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dbBuyOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBaseDataSet3 = new Pos.DataBaseDataSet3();
            this.db_BuyOrdersTableAdapter = new Pos.DataBaseDataSet3TableAdapters.db_BuyOrdersTableAdapter();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下单时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供应商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.经手人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBuyProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBuyOrdersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.BPsearch);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购进货明细";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.productNoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn,
            this.colorNameDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dbBuyProductsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(19, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(739, 169);
            this.dataGridView1.TabIndex = 8;
            // 
            // dbBuyProductsBindingSource
            // 
            this.dbBuyProductsBindingSource.DataMember = "db_BuyProducts";
            this.dbBuyProductsBindingSource.DataSource = this.dataBaseDataSet2;
            // 
            // dataBaseDataSet2
            // 
            this.dataBaseDataSet2.DataSetName = "DataBaseDataSet2";
            this.dataBaseDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BPsearch
            // 
            this.BPsearch.Location = new System.Drawing.Point(672, 191);
            this.BPsearch.Name = "BPsearch";
            this.BPsearch.Size = new System.Drawing.Size(86, 27);
            this.BPsearch.TabIndex = 6;
            this.BPsearch.Text = "查询";
            this.BPsearch.UseVisualStyleBackColor = true;
            this.BPsearch.Click += new System.EventHandler(this.BPsearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbProductsBindingSource, "Name", true));
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(500, 195);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "Name";
            // 
            // dbProductsBindingSource
            // 
            this.dbProductsBindingSource.DataMember = "db_Products";
            this.dbProductsBindingSource.DataSource = this.dataBaseDataSet1;
            // 
            // dataBaseDataSet1
            // 
            this.dataBaseDataSet1.DataSetName = "DataBaseDataSet1";
            this.dataBaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "商品名：";
            // 
            // db_ProductsTableAdapter
            // 
            this.db_ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // db_BuyProductsTableAdapter
            // 
            this.db_BuyProductsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BOsearch);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(16, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 190);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单明细";
            // 
            // BOsearch
            // 
            this.BOsearch.Location = new System.Drawing.Point(672, 76);
            this.BOsearch.Name = "BOsearch";
            this.BOsearch.Size = new System.Drawing.Size(86, 26);
            this.BOsearch.TabIndex = 5;
            this.BOsearch.Text = "查询";
            this.BOsearch.UseVisualStyleBackColor = true;
            this.BOsearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(572, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "下单时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "经手人";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(572, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(186, 20);
            this.comboBox2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderID,
            this.下单时间,
            this.供应商,
            this.经手人,
            this.总价});
            this.dataGridView2.DataSource = this.dbBuyOrdersBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(19, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(475, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // dbBuyOrdersBindingSource
            // 
            this.dbBuyOrdersBindingSource.DataMember = "db_BuyOrders";
            this.dbBuyOrdersBindingSource.DataSource = this.dataBaseDataSet3;
            // 
            // dataBaseDataSet3
            // 
            this.dataBaseDataSet3.DataSetName = "DataBaseDataSet3";
            this.dataBaseDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // db_BuyOrdersTableAdapter
            // 
            this.db_BuyOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // OrderID
            // 
            this.OrderID.DataPropertyName = "OrderID";
            this.OrderID.HeaderText = "订单号";
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            // 
            // 下单时间
            // 
            this.下单时间.DataPropertyName = "OrderDate";
            this.下单时间.HeaderText = "下单时间";
            this.下单时间.Name = "下单时间";
            this.下单时间.ReadOnly = true;
            // 
            // 供应商
            // 
            this.供应商.DataPropertyName = "SupplierName";
            this.供应商.HeaderText = "供应商";
            this.供应商.Name = "供应商";
            this.供应商.ReadOnly = true;
            // 
            // 经手人
            // 
            this.经手人.DataPropertyName = "BuyName";
            this.经手人.HeaderText = "经手人";
            this.经手人.Name = "经手人";
            this.经手人.ReadOnly = true;
            // 
            // 总价
            // 
            this.总价.DataPropertyName = "TotalPrice";
            this.总价.HeaderText = "总价";
            this.总价.Name = "总价";
            this.总价.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn1.HeaderText = "订单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // productNoDataGridViewTextBoxColumn
            // 
            this.productNoDataGridViewTextBoxColumn.DataPropertyName = "ProductNo";
            this.productNoDataGridViewTextBoxColumn.HeaderText = "商品编号";
            this.productNoDataGridViewTextBoxColumn.Name = "productNoDataGridViewTextBoxColumn";
            this.productNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNoDataGridViewTextBoxColumn.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "商品名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "采购数量";
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "进价";
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.unitNameDataGridViewTextBoxColumn.HeaderText = "计量单位";
            this.unitNameDataGridViewTextBoxColumn.Name = "unitNameDataGridViewTextBoxColumn";
            this.unitNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BuyOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BuyOrderSearch";
            this.Size = new System.Drawing.Size(830, 466);
            this.Load += new System.EventHandler(this.BuyOrderSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBuyProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBuyOrdersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BPsearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource dbProductsBindingSource;
        private DataBaseDataSet1 dataBaseDataSet1;
        private DataBaseDataSet1TableAdapters.db_ProductsTableAdapter db_ProductsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dbBuyProductsBindingSource;
        private DataBaseDataSet2 dataBaseDataSet2;
        private DataBaseDataSet2TableAdapters.db_BuyProductsTableAdapter db_BuyProductsTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BOsearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource dbBuyOrdersBindingSource;
        private DataBaseDataSet3 dataBaseDataSet3;
        private DataBaseDataSet3TableAdapters.db_BuyOrdersTableAdapter db_BuyOrdersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下单时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供应商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 经手人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总价;
    }
}
