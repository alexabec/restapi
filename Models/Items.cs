using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public string ShopName { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Hashtags { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Sale { get; set; }
        public string Image { get; set; }
        public bool? Featured { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
