using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AngularProj.Entities
{
    public abstract class Entity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }

        [BsonElement("created")]
        public DateTime? Created { get; set; }

        [BsonElement("modified")]
        public DateTime? Modified { get; set; }
    }
}