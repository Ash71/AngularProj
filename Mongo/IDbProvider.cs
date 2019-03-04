using MongoDB.Driver;

namespace AngularProj.Mongo
{
    public interface IDbProvider
    {
        IMongoDatabase Database { get; }
    }
}