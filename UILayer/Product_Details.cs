using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Entities;

namespace UILayer
{
    public partial class Product_Details : Form
    {
        Product _product = new Product();
        PosBusiness _posBusiness = new PosBusiness();
        InventoryBusiness _inventoryBusiness = new InventoryBusiness();
        DataTable dt = new DataTable();
        public Product_Details()
        {
            InitializeComponent();
        }

        public void setGridData(DataTable dt)
        {

            this.dataGridView2.DataSource = dt;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            dt.Clear();
            dt = _posBusiness.GetProductCatagoryColumn();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["Catagory"]);
            }
            
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView2.Enabled = false;
            dt = _posBusiness.GetProductDataTable(comboBox1.Text);
            dataGridView2.Enabled = true;
            dataGridView2.DataSource = dt;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBoxId.Enabled = false;
            textBoxName.Enabled = true;
            textBoxCatagory.Enabled = true;
            textBoxStocked.Enabled = true;
            textBoxUnitPrice.Enabled = true;
            textBoxSellPrice.Enabled = true;
            labelTitle.Text = "Add Product";
            btnAny.Text = "Insert";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxCatagory.Text = "";
            textBoxStocked.Text = "";
            textBoxUnitPrice.Text = "";
            textBoxSellPrice.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBoxId.Enabled = true;
            textBoxName.Enabled = true;
            textBoxCatagory.Enabled = true;
            textBoxStocked.Enabled = true;
            textBoxUnitPrice.Enabled = true;
            textBoxSellPrice.Enabled = true;
            labelTitle.Text = "Update Product";
            btnAny.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            labelTitle.Text = "Remove Product";
            btnAny.Text = "Remove";
            textBoxId.Enabled = true;
            textBoxName.Enabled = false;
            textBoxCatagory.Enabled = false;
            textBoxStocked.Enabled = false;
            textBoxUnitPrice.Enabled = false;
            textBoxSellPrice.Enabled = false;

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.Update();
            this.dataGridView2.Refresh();
            this.dataGridView2.Show();
        }

        private void btnAny_Click(object sender, EventArgs e)
        {
            if (btnAny.Text == "Insert")
            {
                _product.name = textBoxName.Text;
                _product.catagory = textBoxCatagory.Text;
                _product.quantities = Convert.ToInt32(textBoxStocked.Text);
                _product.sell_price = Convert.ToDouble(textBoxUnitPrice.Text);
                _product.totalprice = Convert.ToDouble(textBoxSellPrice.Text);

                _inventoryBusiness.Insert(_product);
            }
            else if (btnAny.Text == "Update")
            {
                _product.id = textBoxId.Text;
                _product.name = textBoxName.Text;
                _product.catagory = textBoxCatagory.Text;
                _product.quantities = Convert.ToInt32(textBoxStocked.Text);
                _product.sell_price = Convert.ToDouble(textBoxUnitPrice.Text);
                _product.totalprice = Convert.ToDouble(textBoxSellPrice.Text);

                _inventoryBusiness.Update(_product);
            }
            else if (btnAny.Text == "Remove")
            {
                _product.id = textBoxId.Text;
                _inventoryBusiness.Delete(_product);
            }
        }

    }
}
