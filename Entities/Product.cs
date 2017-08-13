using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string catagory { get; set; }
        public int quantities { get; set; }
        public double sell_price { get; set; }
        public double discount { get; set; }
        public double totalprice { get; set; }
    }
}
