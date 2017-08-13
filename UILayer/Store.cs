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

namespace UILayer
{
    public partial class Store : Form
    {
        DataTable dt = new DataTable();
        PosBusiness _posBusiness = new PosBusiness();
        public Store()
        {
            InitializeComponent();
        }

        public void setGridData(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
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

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dt = _posBusiness.GetProductDataTable(comboBox1.Text);
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = dt;
        }
    }
}
