using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public class PaymentModel
    {
        public int value { get; set; }
        public string currency { get; set; }
        public string stripeId { get; set; }

    }
}
