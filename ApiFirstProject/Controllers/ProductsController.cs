using ApiFirstProject.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProject.Controllers
{
    [Route("api/rest/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductManager _productManager;

        public ProductsController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet] //Veri Getirme İşlemleri İçin Kullanulan HTTP Metodu.
        public IActionResult GetAllProducts()
        {
            var result = _productManager.GetAllProducts();
            return Ok(result);
        }
        [HttpGet("{id}")] //Bir Controllerde birden fazla aynı tipte HTTP metodu olması için parametre almalıdır.
        public IActionResult GetProduct([FromRoute] int id)
        {
            var result = _productManager.GetProductById(id);
            return Ok(result);
        }
        [HttpPost] //Kaynak Oluşturma için kullanılan HTTP metodu.
        public IActionResult AddProduct([FromBody] CreateProductDto product)
        {
            var result =  _productManager.AddProduct(product);
            return Ok(result);
        }
        [HttpDelete("{id}")] //Kaynak silmek için kullanılan HTTP metodu.
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var result = _productManager.RemoveProduct(id);
            return Ok(result);
        }
        [HttpPut("{id}")] //Kaynak güncelleme için kullanılan HTTP metodu.
        //localhost:2020/products/5 => PUT
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto product)
        {
            var result = _productManager.UpdateProduct(id, product);
            return Ok(result);
        }
        [HttpGet("ProductInfoWithStore/{productId}")]
        public IActionResult ProductInfoWithStore([FromRoute] int productId)
        {
            var result = _productManager.ProductInfoWithStore(productId);
            return Ok(result);
        }

    }
}
