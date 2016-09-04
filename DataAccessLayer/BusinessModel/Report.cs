using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Report
    {
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public int productID { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}