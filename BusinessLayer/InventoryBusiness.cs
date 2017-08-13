using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class InventoryBusiness
    {
        InventoryData _data = new InventoryData();
        public void Insert(Product _product)
        {
            _data.Insert(_product);
        }
        public void Delete(Product _product)
        {

            _data.Delete(_product);
        }

        public void Update(Product _product)
        {
            _data.Update(_product);
        }

        

    }
}
