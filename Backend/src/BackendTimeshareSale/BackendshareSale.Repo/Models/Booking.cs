using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Contracts = new HashSet<Contract>();
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public DateTime? BookingDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
