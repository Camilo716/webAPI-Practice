using Microsoft.AspNetCore.Mvc;
using webAPI.Services;
using webAPI.Models;

namespace webAPI.Controllers;

[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoryService.GetCategories());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CategoryModel category)
    {
        _categoryService.SaveCategoryAsync(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CategoryModel category)
    {
        _categoryService.UpdateCategoryAsync(id, category);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoryService.DeleteCategoryAsync(id);
        return Ok();
    }
}
