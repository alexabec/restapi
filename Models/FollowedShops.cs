using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class FollowedShops
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ShopId { get; set; }
        public string ProfilePic { get; set; }
    }
}
