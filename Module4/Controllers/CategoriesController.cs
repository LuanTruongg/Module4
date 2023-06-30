using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Module4.Extensions;
using Module4.Models;
using Module4.Services;
using Module4.Resource;
using Module4.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        //[ServiceFilter(typeof(LoggingResponseHeaderFilterService))]
        //[TypeFilter(typeof(LoggingResponseHeaderFilterService), Arguments = new Object[] { "Filter-Header", "Filter-Value"})]
        //[TypeFilter(typeof(LoggingResponseHeaderFilterService))]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resource;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        [ResponseHeader("Another-Filter-Header", "Another Filter Value")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id,category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}
