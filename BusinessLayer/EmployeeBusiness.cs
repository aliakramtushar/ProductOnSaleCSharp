using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;


namespace BusinessLayer
{
    public class EmployeeBusiness
    {
        EmployeeData _data = new EmployeeData();
        public DataTable GetEmployeeName()
        {
            return _data.GetEmployee();
        }
        public DataTable GetEmployeeDetail(string name)
        {
            return _data.GetEmployeeData(name);
        }
    }
}
