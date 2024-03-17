using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Contracts = new HashSet<Contract>();
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public int? StaffId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Deposits { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string BookingDetails { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Property Property { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
