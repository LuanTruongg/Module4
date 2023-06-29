using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Module4.Extensions;
using Module4.Filter;
using Module4.Models;
using Module4.Repositories;
using Module4.Resource;
using Module4.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module4.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Test2Filter("ProductController")]
    public class ProductsController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        // GET: api/<ProductsController>

        [HttpGet]
        
        [Test2Filter("Get All Products")]        
        //[TestAsyncFilter("Get All Async" , order:0)]
        [Test2AsyncFilter("Get All 2 Async")]
        [ShortCircuitingResourceFilter]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            Console.WriteLine("Hello from Controller Action");
            var products = await _productService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products); 
            return resource;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ProductResource> Get(int id)
        {
            var product = await _productService.GetById(id);
            var resource = _mapper.Map<Product,ProductResource>(product);
            return resource;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var category = await _categoryRepository.FindByIdAsync(resource.CategoryId);
            if (category == null)
            {
                return NotFound($"The Category with id: {resource.CategoryId} does not exist");
            }
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var productResource = _mapper.Map<Product, ProductResource>(result.product);
            return Ok(productResource);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState.GetErrorMessages());

            if (resource.UnitOfMeasurement > 0 || Convert.ToInt32(resource.UnitOfMeasurement) < 6)
                return BadRequest("UnitOfMeasurement has value from 1 to 6");

            var category = await _categoryRepository.FindByIdAsync(resource.CategoryId);

            if (category == null)            
                return NotFound($"The Category with id: {resource.CategoryId} does not exist");

            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound($"The Product with id: {id} does not exist");

            product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);
            if (!result.Success)            
                return BadRequest(result.Message);
            
            var productResource = _mapper.Map<Product, ProductResource>(result.product);
            return Ok(productResource);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if(!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.product);
            return Ok(productResource);
        }
    }
}
