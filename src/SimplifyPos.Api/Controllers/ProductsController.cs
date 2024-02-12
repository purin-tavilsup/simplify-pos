using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SimplifyPos.Application.Products;
using SimplifyPos.Application.Products.Create;
using SimplifyPos.Application.Products.Get;
using SimplifyPos.Application.Products.List;

namespace SimplifyPos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IMediator _mediator;

    public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<ProductDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProductAsync([FromBody]CreateProductCommand request)
    {
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            var createdProduct = result.Value;
            var uri = HttpContext.Request.Path.Value;
            return Created(uri, createdProduct);
        }
        
        return CreateErrorResponse(result.Errors.First());
    }

    [HttpGet("{id}")]
    [ProducesResponseType<ProductDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return CreateErrorResponse(result.Errors.First());
    }
    
    [HttpGet]
    [ProducesResponseType<IEnumerable<ProductDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListProductsAsync()
    {
        var result = await _mediator.Send(new ListProductsQuery());

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return CreateErrorResponse(result.Errors.First());
    }

    private ObjectResult CreateErrorResponse(IReason error)
    {
        var errorMessage = error.Message;
        var errorCode = error.Metadata.TryGetValue(nameof(HttpStatusCode), out var value) 
            ? (int)value 
            : (int)HttpStatusCode.BadRequest;
        
        return Problem(detail: errorMessage, statusCode: errorCode);
    }
}