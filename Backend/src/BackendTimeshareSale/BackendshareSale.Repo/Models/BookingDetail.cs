using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Deposits { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string Note { get; set; }
        public int? BookingId { get; set; }
        public int? StaffId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Property Property { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
