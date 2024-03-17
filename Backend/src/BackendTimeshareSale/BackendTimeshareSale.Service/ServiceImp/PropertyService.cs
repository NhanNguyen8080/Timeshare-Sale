using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int GetAllOfProperties()
        {
            var result = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            return result;
        }

        public int NumberOfPropertiesAreAvailable(int month)
        {
            var available = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month > month || _.CheckOutDate.Value.Month < month).ToList().Count;

            return available;
        }

        public int NumberOfPropertiesAreBooking(int month)
        {
            var booking = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month <= month && _.CheckOutDate.Value.Month >= month).ToList().Count;
            return booking;
        }

        public double PercentOfAvailableProperty(int month)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var available = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month > month || _.CheckOutDate.Value.Month < month).ToList().Count;
            var percent = (double) available / total;

            return percent;
        }

        public double PercentOfBookingProperty(int month)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var booking = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month <= month && _.CheckOutDate.Value.Month >= month).ToList().Count;
            double percent = (double)booking / total;

            return percent * 100;
        }
    }
}
