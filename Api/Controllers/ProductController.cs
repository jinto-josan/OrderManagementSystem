using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {       

        private readonly ILogger<ProductController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, HttpClient httpClient, IProductService productService)
        {
            _logger = logger;
            _httpClient=httpClient;
            _productService=productService;
        }

        [HttpPost(Name = "PopulateProducts")]
        //[Route("post")]
        public async Task<IActionResult> PopulateProducts()
        {
            await _productService.PopulateProductFromFakeStore();
            return Created();            
        }

        [HttpGet("listAllProducts")]
        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            List<string> arr=new List<string>();
            foreach(var param in Request.Query)
            {
               arr.Add($"{param.Key} eq {param.Value}");
                arr.Add("and");
            }
            arr.RemoveAt(arr.Count-1);

                return await _productService.GetAllProductAsync(arr.ToArray());
        }




        [HttpDelete(Name = "DeleteAllProducts")]
        //[Route("delete")]
        public async Task<IActionResult> DeleteAllProducts()
        {
            await _productService.DeleteAllProductAsync();
            return Created();
        }
    }
}
