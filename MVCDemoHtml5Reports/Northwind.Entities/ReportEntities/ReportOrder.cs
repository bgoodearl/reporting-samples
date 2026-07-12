using System;

namespace Northwind.Entities2.ReportEntities
{
    public class ReportOrder
    {
        public string CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
    }
}
