using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.IServices
{
    public interface IElasticsearchService<T>
    {
        Task<IEnumerable<T>> GetAllDocuments();
        Task<T> GetDocument(int id);
        Task<IEnumerable<T>> GetDocuments(string keyword);
        Task<bool> IndexData(IEnumerable<T> entities);
        Task<bool> CreateDocument(T entity);
    }
}
