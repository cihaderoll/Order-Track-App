using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product
    {
        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public double UnitPrice { get; set; }
    }
}
