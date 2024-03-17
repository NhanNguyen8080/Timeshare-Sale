using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public double GetRevenueByMonth(int month)
        {
            //unitOfWork.PaymentRepo.
            throw new NotImplementedException();
        }
    }
}
