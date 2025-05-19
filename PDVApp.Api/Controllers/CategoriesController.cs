using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PDVApp.Api.DTOs;
using PDVApp.Api.Services;

namespace PDVApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if(categoriesDto == null) 
                return NotFound("No categories found.");
            return Ok(categoriesDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto == null)
                return NotFound("No categories found.");
            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoriesDto = await _categoryService.GetCategoryById(id);
            if (categoriesDto == null)
                return NotFound("No categories found.");
            return Ok(categoriesDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {

            //if (categoryDto is null)
            //    return BadRequest("Invalid Data");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.AddCategory(categoryDto);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            //if (id != categoryDto.Id)
            //    return BadRequest("The ID in the URL does not match the ID in the body.");
            //if (categoryDto is null)
            //    return BadRequest("The category cannot be null.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.UpdateCategory(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto == null)
                return NotFound("No categories found.");
            await _categoryService.RemoveCategory(id);
            return Ok(categoryDto);
        }

    }
}
