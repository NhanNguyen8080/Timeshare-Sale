using BackendshareSale.Repo.Models;
using BackendshareSale.Repo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.IServices
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyVM>> SearchProperties(string keyword);
        Task<bool> IndexData(IEnumerable<Property> entities);
        Task<IEnumerable<PropertyVM>> GetAllProperties();
        Task<PropertyVM> GetById(int id);
        void InsertDataToSQL();
        Task<string> CreateDocument(Property entity);
        int GetNumberOfProperties();
        double PercentOfAvailableProperty(int month);
        double PercentOfBookingProperty(int bookingDate);
    }
}
