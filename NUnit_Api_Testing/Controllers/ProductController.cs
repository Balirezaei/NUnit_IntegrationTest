using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit_Api_Testing.Model;
using NUnit_Api_Testing.Service;

namespace NUnit_Api_Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

    }

}
