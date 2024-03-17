using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Payment
    {
        public Payment()
        {
            BankTransferTransactions = new HashSet<BankTransferTransaction>();
            CardTransactions = new HashSet<CardTransaction>();
        }

        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string OrtherPaymentDetails { get; set; }
        public int? ContractId { get; set; }
        public string PaymentStatus { get; set; }
        public int? BookingId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<BankTransferTransaction> BankTransferTransactions { get; set; }
        public virtual ICollection<CardTransaction> CardTransactions { get; set; }
    }
}
