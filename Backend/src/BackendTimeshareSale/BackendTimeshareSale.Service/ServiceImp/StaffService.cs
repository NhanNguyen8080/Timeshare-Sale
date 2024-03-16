using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetStaffCount()
        {
            return _unitOfWork.StaffRepo.GetAll().Count();
        }
    }
}
