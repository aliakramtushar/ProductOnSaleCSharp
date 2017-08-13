using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Framework;

namespace DataLayer
{
    public class EmployeeData
    {
        DataAccess _da = new DataAccess();
        public DataTable GetEmployee()
        {
            string insertCommand = "select Employee_Name from Employee_Details";
            SqlCommand command = new SqlCommand(insertCommand);
            return _da.ExecuteInsert(command);
        }

        public DataTable GetEmployeeData(string name)
        {
            string insertCommand = "select * from Employee_Details where Employee_Name = '"+name+"'";
            SqlCommand command = new SqlCommand(insertCommand);
            return _da.ExecuteInsert(command);
        }
    }
}
