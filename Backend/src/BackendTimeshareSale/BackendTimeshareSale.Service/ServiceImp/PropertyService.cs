using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int GetNumberOfProperties()
        {
            var result = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            return result;
        }

        public double PercentOfAvailableProperty(int date)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var available = _unitOfWork.PropertyRepo.Get(_ => _.IsAvailable == true).ToList().Count;
            var percent = (double) available / total;

            return percent;
        }

       /* public double PercentOfBookingProperty(int bookingDate)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var booking = _unitOfWork.BookingRepo.Get(_ => _.BookingDateTime.Value.Month.Equals(bookingDate)).ToList().Count;
            double percent = (double)booking / total;

            return percent;
        }*/
    }
}
