using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Property
    {
        public Property()
        {
            BookingDetails = new HashSet<BookingDetail>();
            BookmarkTimeShares = new HashSet<BookmarkTimeShare>();
        }

        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Images { get; set; }
        public int? OwnerId { get; set; }

        public virtual Investor Owner { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<BookmarkTimeShare> BookmarkTimeShares { get; set; }
    }
}
