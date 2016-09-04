using DataAccessLayer.IRapository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQLRepository
{
    public class MSSQLOrderDetailRepository : IOrderDetailRepository
    {
        NorthwindEntities db;

        public MSSQLOrderDetailRepository()
        {
            db = new NorthwindEntities();

        }

        public List<Report> GetOrderDetailByPeriod(DateTime startDate, DateTime finishDate)
        {
            return (from orderDetail in db.OrderDetail
                     join order in db.Order
                         on orderDetail.OrderID equals order.ID
                     join product in db.Product
                         on orderDetail.ProductID equals product.ID
                    where order.OrderDate >= startDate && order.OrderDate <= finishDate
                    select new Report()
                    { 
                        orderID = (int)orderDetail.OrderID,
                        orderDate = (DateTime)order.OrderDate,
                        productID = (int)orderDetail.ProductID,
                        Name = (string)product.Name,
                        Quantity = (short)orderDetail.Quantity,
                        UnitPrice = (decimal)product.UnitPrice
                     }).ToList();
        }

        public List<Report> GetOrderDetail()
        {
            return (from orderDetail in db.OrderDetail
                     join order in db.Order
                         on orderDetail.OrderID equals order.ID
                     join product in db.Product
                         on orderDetail.ProductID equals product.ID
                    select new Report()
                    { 
                        orderID = (int)orderDetail.OrderID,
                        orderDate = (DateTime)order.OrderDate,
                        productID = (int)orderDetail.ProductID,
                        Name = (string)product.Name,
                        Quantity = (short)orderDetail.Quantity,
                        UnitPrice = (decimal)product.UnitPrice
                     }).ToList();
        }
    }
}
