using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class ItemImages
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? ShopId { get; set; }
        public string ItemImage { get; set; }
    }
}
