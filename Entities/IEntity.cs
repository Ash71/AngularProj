using System;
using MongoDB.Bson;

namespace AngularProj.Entities
{
    public interface IEntity
    {
        string Id { get; set; }

        DateTime? Created { get; set; }

        DateTime? Modified { get; set; }
    }
}