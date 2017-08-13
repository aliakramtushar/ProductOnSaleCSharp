using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entities;


namespace BusinessLayer
{
    
    public class PosBusiness
    {
        PosSystemData _data = new PosSystemData();
        
        public bool CheckLogin(Login _log)
        {
            
            return _data.checklog(_log);
        }

        public string GetTitle(Login _login)
        {
            return _data.checkTitle(_login);
        } 

        public DataTable GetProductDetail()
        {
            
            return _data.GetAllData();
        }
        public Product GetProduct(string id, Product product)
        {
            return _data.getDetail(id,product);
        }
        public DataTable GetProductCatagoryColumn()
        {
            return _data.GetCatagory();
        }

        public DataTable GetProductDataTable(string tableName)
        {
            return _data.GetTableData(tableName);
        }

        public int GetQuantity(int id)
        {
            return _data.GetQuantityData(id);
        }

        public void UpdateStocked(int id,int quantity)
        {
            _data.UpdateQuery(id, quantity);
        }
    }
}
