using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using Entities;

namespace UILayer
{
    public partial class LoginForm : Form
    {
        PosBusiness posBusiness= new PosBusiness();
        Login _log = new Login();
         
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnLogin_Click_1(object sender, EventArgs e)
        {
            
            _log.Id = tbUserID.Text;
            _log.Password = tbPassword.Text;
            if (tbUserID.Text != "" && tbPassword.Text != "")
            {
                if (posBusiness.CheckLogin(_log))
                {
                    if (posBusiness.GetTitle(_log) == "PosEmployee")
                    {
                        this.Hide();
                        PosSystem _pos = new PosSystem();
                        _pos.Show();
                    }
                    else if (posBusiness.GetTitle(_log) == "Manager")
                    {
                        this.Hide();
                        ManagerForm _manager = new ManagerForm();
                        _manager.Show();
                    }
                    else if (posBusiness.GetTitle(_log) == "InventoryEmployee")
                    {
                        this.Hide();
                        ViewInventory _inventory = new ViewInventory();
                        _inventory.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Login Failed!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }

        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
