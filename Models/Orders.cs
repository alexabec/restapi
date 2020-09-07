using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string CustomerUsername { get; set; }
        public string FullName { get; set; }
        public string ShippingAddress { get; set; }
        public string Total { get; set; }
        public string PaymentConfirmation { get; set; }
        public bool? Shipped { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string Refunded { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
