using Domain.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order: EntityBase
    {
        public ObjectId _id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerFullName { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
