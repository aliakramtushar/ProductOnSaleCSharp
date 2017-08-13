using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UILayer
{
    public partial class ProfileTab : UserControl
    {
        public ProfileTab()
        {
            InitializeComponent();
        }

        public void openTab(TabPage tb,int count,string name)
        {
            this.tabControl1.TabPages.Add(tb);
            UserControlForm _userControlForm = new UserControlForm(name);
            _userControlForm.Dock = DockStyle.Fill;
            _userControlForm.TopLevel = false;
            tb.Controls.Add(_userControlForm);
            _userControlForm.Show();
        }
    }
}
