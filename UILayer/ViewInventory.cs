using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;


namespace UILayer
{
    public partial class ViewInventory : Form
    {
        Product_Details _details =new Product_Details();
        PosBusiness _posBusiness = new PosBusiness();

        LoginForm log = new LoginForm();
        public ViewInventory()
        {
            InitializeComponent();
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            _details.Dock = DockStyle.Fill;
            _details.TopLevel = false;
            dt = _posBusiness.GetProductDetail();
            this.Controls.Add(_details);
            _details.setGridData(dt);
            _details.Show();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            log.Show();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewInventoryToolStripMenuItem.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POS SYSTEM \n Version: 1.0.5A2 \n ", "About POS SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
