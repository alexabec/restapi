using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class Shops
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ProfileAddress { get; set; }
        public string ProfileBio { get; set; }
        public string ProfileEmail { get; set; }
        public string Category { get; set; }
        public string ProfilePic { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
