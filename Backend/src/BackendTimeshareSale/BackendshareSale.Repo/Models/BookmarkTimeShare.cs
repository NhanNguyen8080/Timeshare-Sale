using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class BookmarkTimeShare
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public bool? Status { get; set; }

        public virtual Property Property { get; set; }
        public virtual User User { get; set; }
    }
}
