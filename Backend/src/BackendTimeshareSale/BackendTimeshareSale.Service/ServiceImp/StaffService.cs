using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;

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
