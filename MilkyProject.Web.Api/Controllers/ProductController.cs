using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
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
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.TInsert(product);
            return Ok("urun basarı ile eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("urun basarı ile silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi");
        }
        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var values = _productService.TGetProductsWithCategory();
            return Ok(values);
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var contex = new MilkyContext();
            var count = contex.Products.Count();
            return Ok(count);
        }
        [HttpGet("GetProductAvg")]
        public IActionResult GetProductAvg()
        {
            var contex = new MilkyContext();
            var avg = contex.Products.Average(p => p.NewPrice);
            return Ok(avg);
        }

    }
}
