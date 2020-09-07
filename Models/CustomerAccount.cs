using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class CustomerAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StripeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
