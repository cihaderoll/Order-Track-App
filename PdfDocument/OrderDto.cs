using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocument
{
    public class OrderDto
    {
        public string OrderName { get; set; }
        public string OrderWeight { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
    }
}
