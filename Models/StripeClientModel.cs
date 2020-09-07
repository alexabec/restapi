using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public class StripeClientModel
    {
        public string email { get; set; }
        public string name { get; set; }
        public string cardNumber { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string cvv { get; set; }
    }
}
