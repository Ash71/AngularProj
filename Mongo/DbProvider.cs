using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AngularProj.Mongo
{
    public class DbProvider : IDbProvider
    {
        public IMongoDatabase _database { get; private set; }

        // private IOptions<Settings> _settings { get; set; }

        // public DbProvider(IOptions<Settings> settings)
        // {
        //     _settings = settings;
        // }

        public IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    
                    var client = new MongoClient("mongodb://localhost:27017");
                    _database = client.GetDatabase("TestApplication");
                }
                return _database;
            }
        }
    }
}