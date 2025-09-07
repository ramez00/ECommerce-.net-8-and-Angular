using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(IUnitOfWork unitOfWork,IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetallAsync()
    {
        var allCategories = await _unitOfWork.CategoryRepositry.GetAllAsync();

        if(allCategories is null)
            return NotFound();

        return Ok(allCategories);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepositry.GetByIdAsync(id);
        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryDto categoryDto)
    {
        if (categoryDto is null)
            return BadRequest();

        var category = _mapper.Map<Category>(categoryDto);

        await _unitOfWork.CategoryRepositry.AddAsync(category);
        await _unitOfWork.CategoryRepositry.SaveChangesAsync();

        return Created();
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateAsync(int id, CategoryDto categoryDto)
    {
        if (categoryDto is null)
            return BadRequest();

        var category = await _unitOfWork.CategoryRepositry.GetByIdAsync(id);

        if (category is null)
            return NotFound();
         
        _mapper.Map(categoryDto,category);

        await _unitOfWork.CategoryRepositry.UpdateAsync(category);
        await _unitOfWork.CategoryRepositry.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepositry.GetByIdAsync(id);

        if (category is null)
            return NotFound();

        await _unitOfWork.CategoryRepositry.DeleteAsync(id);
        await _unitOfWork.CategoryRepositry.SaveChangesAsync();
        return NoContent();
    }
}