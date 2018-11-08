using System;
using System.Collections.Generic;

namespace TestWebApi
{
    public partial class Purchases
    {
        public int PurchaseId { get; set; }
        public string CustomerName { get; set; }
        public int? ProductId { get; set; }

        public Products Purchase { get; set; }
    }
}
