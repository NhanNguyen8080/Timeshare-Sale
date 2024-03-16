using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.IServices
{
    public interface IPropertyService
    {
        int GetNumberOfProperties();
        double PercentOfAvailableProperty(int month);
        double PercentOfBookingProperty(int bookingDate);
    }
}
