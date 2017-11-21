namespace Pos.Products
{
    partial class Storage
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
            this.dataBaseDataSet6 = new Pos.DataBaseDataSet6();
            this.dbProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_ProductsTableAdapter = new Pos.DataBaseDataSet6TableAdapters.db_ProductsTableAdapter();
            this.productNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存详情";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.colorNameDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn,
            this.sellPriceDataGridViewTextBoxColumn,
            this.jobPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dbProductsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(818, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataBaseDataSet6
            // 
            this.dataBaseDataSet6.DataSetName = "DataBaseDataSet6";
            this.dataBaseDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbProductsBindingSource
            // 
            this.dbProductsBindingSource.DataMember = "db_Products";
            this.dbProductsBindingSource.DataSource = this.dataBaseDataSet6;
            // 
            // db_ProductsTableAdapter
            // 
            this.db_ProductsTableAdapter.ClearBeforeFill = true;
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
            this.numDataGridViewTextBoxColumn.HeaderText = "库存数量";
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
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "SellPrice";
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "售价";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jobPriceDataGridViewTextBoxColumn
            // 
            this.jobPriceDataGridViewTextBoxColumn.DataPropertyName = "JobPrice";
            this.jobPriceDataGridViewTextBoxColumn.HeaderText = "批发价";
            this.jobPriceDataGridViewTextBoxColumn.Name = "jobPriceDataGridViewTextBoxColumn";
            this.jobPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Storage";
            this.Size = new System.Drawing.Size(830, 332);
            this.Load += new System.EventHandler(this.Storage_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbProductsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dbProductsBindingSource;
        private DataBaseDataSet6 dataBaseDataSet6;
        private DataBaseDataSet6TableAdapters.db_ProductsTableAdapter db_ProductsTableAdapter;
    }
}
