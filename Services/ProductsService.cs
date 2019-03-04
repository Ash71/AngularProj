using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProj.Mappers;
using AngularProj.Repositories;
using AngularProj.ViewModels;

namespace AngularProj.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productsRepo;

        public ProductsService(IProductRepository productRepo)
        {
            _productsRepo = productRepo;
        }
        public async Task<List<ProductVM>> FetchProducts()
        {   
            
            var products =  await _productsRepo.FetchProducts();
            return products.Select(ProductMapper.Map_Product_ProductVM).ToList();
        }
        
    }
}