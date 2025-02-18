using NUnit_Api_Testing.Model;

namespace NUnit_Api_Testing.Service
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product {Title ="P1" }
            };
        }
    }
}
