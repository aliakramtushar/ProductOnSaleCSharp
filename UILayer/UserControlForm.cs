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
    public partial class UserControlForm : Form
    {
        DataTable dt = new DataTable();
        EmployeeBusiness _employeeBusiness = new EmployeeBusiness();
        string name;
        public UserControlForm(string tabName)
        {
            InitializeComponent();
            this.name = tabName;
        }

        private void UserControlForm_Load(object sender, EventArgs e)
        {
            dt = _employeeBusiness.GetEmployeeDetail(name);
            textBox1.Text = dt.Rows[0]["Employee_Name"].ToString();
            textBox2.Text = dt.Rows[0]["Employee_AGe"].ToString();
            textBox3.Text = dt.Rows[0]["Employee_Gender"].ToString();
            textBox4.Text = dt.Rows[0]["Employee_MaritalStatus"].ToString();
            textBox5.Text = dt.Rows[0]["Employee_NID"].ToString();
            textBox6.Text = dt.Rows[0]["Employee_JobPosition"].ToString();
            textBox7.Text = dt.Rows[0]["Employee_StartDate"].ToString();
            textBox8.Text = dt.Rows[0]["Employee_EndDate"].ToString();
            textBox9.Text = dt.Rows[0]["Employee_JobDuration"].ToString();
            richTextBox1.Text = dt.Rows[0]["Employee_Address"].ToString();

        }
    }
}
