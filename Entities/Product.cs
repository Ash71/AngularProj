using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AngularProj.Entities
{
    [BsonIgnoreExtraElements]
    public class Product : Entity, IEntity
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("slug")]
        public string Slug { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("condition")]
        public string Condition { get; set; }

        [BsonElement("quantity")]
        public string Quantity { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }


        [BsonElement("deleted")]
        public bool Deleted { get; set; }

        [BsonElement("is_active")]
        public bool IsActive { get; set; }
    }
 
}