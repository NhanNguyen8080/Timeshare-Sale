using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class CardTransaction
    {
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public string CardType { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public string TransferAmount { get; set; }
        public string TransferDateTime { get; set; }
        public string TransferStatus { get; set; }
        public string OtherTransferDetails { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
