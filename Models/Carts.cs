using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class Carts
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string CustomerUsername { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
