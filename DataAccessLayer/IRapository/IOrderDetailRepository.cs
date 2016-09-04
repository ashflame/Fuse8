using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRapository
{
    public interface IOrderDetailRepository
    {
        List<Report> GetOrderDetailByPeriod(DateTime startDate, DateTime finishDate);
        List<Report> GetOrderDetail();
    }
}
