using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Customer
    {
        public ObjectId _id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
