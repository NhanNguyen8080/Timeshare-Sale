using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class InvestorService : IInvestorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvestorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int GetInvestorCount()
        {
            var result1 = _unitOfWork.InvestorRepo.GetAll().Count();
            var result2 = _unitOfWork.UserRepo.Get(_ => _.RoleId == 3).Count();
            return result1 + result2;
        }
    }
}
