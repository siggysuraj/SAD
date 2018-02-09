using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public partial class Booked
    {
        public long Id { get; set; }
        public string CusFirstName { get; set; }
        public string CusLastName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarHireDate { get; set; }
        public string DueDate { get; set; }
        public double Rate { get; set; }
        public int Qty { get; set; }
    }
}
