using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocument
{
    public class OrderInfoDto
    {
        public OrderInfoDto()
        {
            OrderList = new List<OrderDto>();
        }

        public string Title { get; set; }
        public string Address { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DeliverDate { get; set; }
        public bool IsPaid { get; set; }

        public List<OrderDto> OrderList { get; set; }
    }
}
