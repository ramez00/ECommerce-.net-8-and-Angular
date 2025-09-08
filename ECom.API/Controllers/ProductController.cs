using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(IUnitOfWork unitOfWork,IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> Getall()
    {
        var allProducts = await _unitOfWork.ProductRepositry.GetAllAsync(p => p.Category);

        if (allProducts is null)
            return NotFound();

        var productDto = _mapper.Map<List<ProductDto>>(allProducts);

        return Ok(productDto);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.ProductRepositry.GetByIdAsync(id, p => p.Category);

        if (product is null)
            return NotFound();
        
       var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ProductDto productDto)
    {
        if (productDto is null)
            return BadRequest();

        var product = _mapper.Map<Product>(productDto);

        await _unitOfWork.ProductRepositry.AddAsync(product);
        await _unitOfWork.ProductRepositry.SaveChangesAsync();
        return Created();
    }

    [HttpPatch("change-Avliablity")]
    public async Task<IActionResult> UpdateAsync(int id)
    {

        var product = await _unitOfWork.ProductRepositry.GetByIdAsync(id);

        if (product is null)
            return NotFound();

        product.IsAvaliable = !product.IsAvaliable;

        await _unitOfWork.ProductRepositry.UpdateAsync(product);
        //await _unitOfWork.ProductRepositry.SaveChangesAsync();
        return NoContent();
    }

    [HttpPatch("change-category")]
    public async Task<IActionResult> ChangeCategoryAsync(int productId, int newCategoryId)
    {
        var product = await _unitOfWork.ProductRepositry.GetByIdAsync(productId);

        if (product is null)
            return NotFound();

        product.CategoryId = newCategoryId;
        await _unitOfWork.ProductRepositry.UpdateAsync(product);
        //await _unitOfWork.ProductRepositry.SaveChangesAsync();
        return NoContent();
    }

    [HttpPatch("Chaneg-Stock-quantity")]
    public async Task<IActionResult> ChangeProductStock(int productId,int Stock)
    {
        var product = await _unitOfWork.ProductRepositry.GetByIdAsync(productId);

        if (product is null)
            return NotFound();

        product.StockQuantity = Stock;

        await _unitOfWork.ProductRepositry.UpdateAsync(product);
        //await _unitOfWork.ProductRepositry.SaveChangesAsync();
        return NoContent();
    }

}