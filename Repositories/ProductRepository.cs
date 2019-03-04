
using System.Collections.Generic;
// using System.Linq;
using System.Threading.Tasks;
using AngularProj.Entities;
using AngularProj.Mongo;
using MongoDB.Driver;

namespace AngularProj.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDbProvider dbProvider) : base(dbProvider)
        {            
            _collection = _db.GetCollection<Product>("Products");
        }
        public async  Task<List<Product>> FetchProducts()
        {
            var result = await this.Where(r => r.IsActive == true).ToListAsync();
            return result;
        }
    }
}
