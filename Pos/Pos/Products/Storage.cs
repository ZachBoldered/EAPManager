using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.DataBaseDataSet6TableAdapters;

namespace Pos.Products
{
    public partial class Storage : UserControl
    {
        private string tableName = string.Empty;
        public Storage()
        {
            InitializeComponent();
        }

        public Storage(IContainer components, GroupBox groupBox1, DataGridView dataGridView1, DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn, DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn, DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn, DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn, DataGridViewTextBoxColumn numDataGridViewTextBoxColumn, DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn, DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn, DataGridViewTextBoxColumn jobPriceDataGridViewTextBoxColumn, BindingSource dbProductsBindingSource, DataBaseDataSet6 dataBaseDataSet6, db_ProductsTableAdapter db_ProductsTableAdapter, string tableName)
        {
            this.components = components ?? throw new ArgumentNullException(nameof(components));
            this.groupBox1 = groupBox1 ?? throw new ArgumentNullException(nameof(groupBox1));
            this.dataGridView1 = dataGridView1 ?? throw new ArgumentNullException(nameof(dataGridView1));
            this.productNoDataGridViewTextBoxColumn = productNoDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(productNoDataGridViewTextBoxColumn));
            this.nameDataGridViewTextBoxColumn = nameDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(nameDataGridViewTextBoxColumn));
            this.colorNameDataGridViewTextBoxColumn = colorNameDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(colorNameDataGridViewTextBoxColumn));
            this.unitNameDataGridViewTextBoxColumn = unitNameDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(unitNameDataGridViewTextBoxColumn));
            this.numDataGridViewTextBoxColumn = numDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(numDataGridViewTextBoxColumn));
            this.costPriceDataGridViewTextBoxColumn = costPriceDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(costPriceDataGridViewTextBoxColumn));
            this.sellPriceDataGridViewTextBoxColumn = sellPriceDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(sellPriceDataGridViewTextBoxColumn));
            this.jobPriceDataGridViewTextBoxColumn = jobPriceDataGridViewTextBoxColumn ?? throw new ArgumentNullException(nameof(jobPriceDataGridViewTextBoxColumn));
            this.dbProductsBindingSource = dbProductsBindingSource ?? throw new ArgumentNullException(nameof(dbProductsBindingSource));
            this.dataBaseDataSet6 = dataBaseDataSet6 ?? throw new ArgumentNullException(nameof(dataBaseDataSet6));
            this.db_ProductsTableAdapter = db_ProductsTableAdapter ?? throw new ArgumentNullException(nameof(db_ProductsTableAdapter));
            this.TableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
        }

        public string TableName { get => tableName; set => tableName = value; }
        public string TableName1 { get => tableName; set => tableName = value; }
        public string TableName2 { get => tableName; set => tableName = value; }

        private void Storage_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice,JobPrice FROM " + BaseConfigs.GetTablePrefix + "Products ORDER BY ProductID ASC").Tables[0];
            this.dataGridView1.DataSource = dt;
        }
    }
}
