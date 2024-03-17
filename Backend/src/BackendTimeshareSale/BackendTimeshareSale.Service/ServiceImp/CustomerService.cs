using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetCustomerCount()
        {
            var result1 = _unitOfWork.UserRepo.Get(_ => _.RoleId == 4).Count();
            var result2 = _unitOfWork.CustomerRepo.GetAll().Count();
            return result1 + result2;
        }
    }
}
