using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class BankTransferTransaction
    {
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string TransferReference { get; set; }
        public decimal? TransferAmount { get; set; }
        public DateTime? TransferDateTime { get; set; }
        public string TransferStatus { get; set; }
        public string OtherTransferDetails { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
