using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_Program.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public int CarNumber { get; set; }
        public bool RepairStatus { get; set; }
    }
}