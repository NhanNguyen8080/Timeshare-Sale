﻿using BackendshareSale.Repo.Interfaces;
using BackendTimeshareSale.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork unitOfWork;
        public ContractService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int GetContractsAreCompleted()
        {
            var result = unitOfWork.ContractRepo.Get(_ => _.ContractStatus.ToUpper().Equals("DA KY")).ToList();
            return result.Count;
        }

        public decimal GetRevenueByMonth(int month)
        {
            var list = unitOfWork.ContractRepo.Get(_ => _.ContractStatus.ToUpper().Equals("DA KY") && _.ContractDate.Value.Month == month).ToList();
            decimal? total = 0;
            foreach(var money in list)
            {
                total += money.Price;
            }
            return (decimal)total;
        }
    }
}
