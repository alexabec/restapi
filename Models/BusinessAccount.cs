using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class BusinessAccount
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessAddress { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
