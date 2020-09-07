using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class MyCart
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public string ItemSize { get; set; }
        public string ItemPrice { get; set; }
    }
}
