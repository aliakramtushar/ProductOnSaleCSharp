using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Framework;
using Entities;
namespace DataLayer
{
    public class PosSystemData
    {
        DataAccess _da = new DataAccess();
        public bool checklog(Login _log)
        {
            int count = 0;
            string insertCommand = "select count(*) from Login where Id= '"+_log.Id+ "' and Password = '"+_log.Password+"'";
            SqlCommand command = new SqlCommand(insertCommand);

            count = _da.ExecuteLogin(command);
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string checkTitle(Login _log)
        {
            string insertCommand = "select EmployeeTitle from Login where Id= '" + _log.Id + "' and Password = '" + _log.Password + "'";
            SqlCommand command = new SqlCommand(insertCommand);
            return _da.Execute(command);
        }

        public Product getDetail(string id, Product product)
        {
            DataTable ds = new DataTable();
            string insertCommand = "select Product_Name,Sell_price from Product_Details where Product_Id=" +"'"+id+"'";
            SqlCommand command = new SqlCommand(insertCommand);

            ds=_da.ExecuteInsert(command);
            product.name = ds.Rows[0][0].ToString();
            product.sell_price = Convert.ToDouble(ds.Rows[0][1]);

            return product;
        }

        public DataTable GetCatagory()
        {
            string insertCommand = "select distinct Catagory from Product_Details";
            SqlCommand command = new SqlCommand(insertCommand);
            return _da.ExecuteInsert(command);
        }
        public DataTable GetAllData()
        {
            string insertCommand = "select * from Product_Details";
            SqlCommand command = new SqlCommand(insertCommand);
            return _da.ExecuteInsert(command);
        }
        public DataTable GetTableData(string catagory)
        {
            string insertCommand = "select * from Product_Details where Catagory= '"+catagory+"' order by Product_Id";
            SqlCommand command = new SqlCommand(insertCommand);

            return _da.Query(command);
        }

        public int GetQuantityData(int id)
        {
            string quantityCommand = "select Stocked from Product_Details where Product_Id='"+id+"'";
            SqlCommand command = new SqlCommand(quantityCommand);
            return _da.QuantityQuery(command);
        }

        public void UpdateQuery(int id, int quantity)
        {
            string stockedCommand = "UPDATE Product_Details SET Stocked = "+quantity+" WHERE Product_Id = '"+id+"'";
            SqlCommand command = new SqlCommand(stockedCommand);
            _da.InventoryExecute(command);
        }
    }
}
