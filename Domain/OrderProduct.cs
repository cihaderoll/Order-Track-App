using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderProduct
    {
        public ObjectId _id { get; set; }
        public string OrderName { get; set; }
        public decimal Weight { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
