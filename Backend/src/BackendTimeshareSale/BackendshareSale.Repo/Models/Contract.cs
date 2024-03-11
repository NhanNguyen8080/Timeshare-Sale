using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Payments = new HashSet<Payment>();
        }

        public int ContractId { get; set; }
        public string ContractDetails { get; set; }
        public int? BookingId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractStatus { get; set; }
        public DateTime? ContractExpirationDate { get; set; }
        public string ContractTerms { get; set; }
        public string Signature { get; set; }
        public string OtherContractDetails { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
