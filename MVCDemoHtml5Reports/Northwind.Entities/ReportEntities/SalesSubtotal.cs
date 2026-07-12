using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Entities2.ReportEntities
{
    public class SalesSubtotal
    {
        public int OrderID { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        public decimal Subtotal { get; set; }
    }
}
