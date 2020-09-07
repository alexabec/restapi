using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class SavedItems
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? CustomerId { get; set; }
        public int? ShopId { get; set; }
    }
}
