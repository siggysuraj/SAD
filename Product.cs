using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Rate { get; set; }
        public int Qty { get; set; }
    }
}
