using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocument
{
    public class PreviousOrdersDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerFullName { get; set; }
    }
}
