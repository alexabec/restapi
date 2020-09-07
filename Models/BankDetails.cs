using System;
using System.Collections.Generic;

namespace kwiqstage.Models
{
    public partial class BankDetails
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public string AccountNumberIban { get; set; }
        public string BankName { get; set; }
        public string BicSwift { get; set; }
    }
}
