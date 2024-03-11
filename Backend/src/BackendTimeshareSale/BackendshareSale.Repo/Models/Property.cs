using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Property
    {
        public Property()
        {
            Bookings = new HashSet<Booking>();
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
        public byte[] Images { get; set; }
        public int? OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<BookmarkTimeShare> BookmarkTimeShares { get; set; }
    }
}
