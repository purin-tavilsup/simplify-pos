using Microsoft.AspNetCore.Mvc;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;
using SimplifyPos.Application.Products;

namespace SimplifyPos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }
    
    [HttpGet]
    [ProducesResponseType<IEnumerable<ProductDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListProducts()
    {
        var results = await _productRepository.ListProductsAsync();

        return Ok(results.ToDto());
    }
}