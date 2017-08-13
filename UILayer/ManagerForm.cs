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
    public partial class ManagerForm : Form
    {
        int count = 0;
        ProfileTab tab = new ProfileTab();
        Employee em = new Employee();
        LoginForm log = new LoginForm();
        Store _store = new Store();
        PosBusiness _posBusiness = new PosBusiness();
        DataTable dt = new DataTable();
        EmployeeBusiness _employee = new EmployeeBusiness();
        public ManagerForm()
        {
            InitializeComponent();
            tab.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(tab);
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POS SYSTEM \n Version: 1.0.5A2 \n ", "About POS SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            TabPage tb = new TabPage();
            if (e.RowIndex >= 0)
            {

                tb.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                tab.openTab(tb, count,name);
            }
            count++;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            log.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._store.Visible = false;
            splitContainer1.Visible = true;
            dt = _employee.GetEmployeeName();
            dataGridView1.DataSource = dt;
        }

        private int getProductCount(DataTable dt)
        {
            int sum=0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dt.Rows[i]["Stocked"]);
            }

            return sum;
        }
        private void currentDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
            _store.Dock = DockStyle.Fill;
            _store.TopLevel = false;
            dt = _posBusiness.GetProductDetail();
            this.Controls.Add(_store);
            _store.setGridData(dt);
            toolStripStatusLabel1.Text = "Total Product: "+getProductCount(dt);
            _store.Show();
        }
    }
}
