using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.IServices
{
    public interface IPaymentService
    {
        double GetRevenueByMonth(int month);
    }
}
