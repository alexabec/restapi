using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public string ItemSize { get; set; }
        public string ItemPrice { get; set; }
        public bool? Refund { get; set; }
    }
}
