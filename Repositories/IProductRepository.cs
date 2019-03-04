using System.Collections.Generic;
using System.Threading.Tasks;
using AngularProj.Entities;

namespace AngularProj.Repositories
{
public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> FetchProducts();

    }
}