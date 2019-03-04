using System.Threading.Tasks;
using AngularProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularProj.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult>  Greetings() {
            var products = await _productsService.FetchProducts();
            return Ok(products);
             
        }

        [Route("allproducts"), HttpGet]
        public async Task<IActionResult> FetchProducts() {
            var products = await _productsService.FetchProducts();
            return Ok(products);
        }
    }
}