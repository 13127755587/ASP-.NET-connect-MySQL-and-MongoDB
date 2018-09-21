using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace APResearch2.Models
{
    public class Customer
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public string id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("customer_1")]
        public customerInfo customer_1 { get; set; }

        [BsonElement("customer_2")]
        public customerInfo customer_2 { get; set; }
    }

    public class customerInfo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("first_name")]
        public string first_name { get; set; }

        [BsonElement("last_name")]
        public string last_name { get; set; }

        [BsonElement("e_mail")]
        public string e_mail { get; set; }
    }
}