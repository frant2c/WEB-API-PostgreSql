using System;
using System.Collections.Generic;

namespace TestWebApi
{
    public partial class Products 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public float? Size { get; set; }

        public Purchases Purchases { get; set; }
    }
}
