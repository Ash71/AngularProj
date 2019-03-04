using System.Collections.Generic;
using System.Threading.Tasks;
using AngularProj.ViewModels;

namespace AngularProj.Services
{
    public interface IProductsService
    {
        Task<List<ProductVM>> FetchProducts();
    }
}