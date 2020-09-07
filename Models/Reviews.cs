using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string ShopName { get; set; }
        public string CustomerUsername { get; set; }
        public int? Ranking { get; set; }
        public string Review { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
