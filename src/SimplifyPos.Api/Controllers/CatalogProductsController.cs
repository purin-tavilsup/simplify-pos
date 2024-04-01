using System.Net;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplifyPos.Application.CatalogProducts;
using SimplifyPos.Application.CatalogProducts.Add;
using SimplifyPos.Application.CatalogProducts.List;

namespace SimplifyPos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogProductsController : ControllerBase
{
    private readonly ILogger<CatalogProductsController> _logger;
    private readonly IMediator _mediator;
    
    public CatalogProductsController(ILogger<CatalogProductsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType<IEnumerable<CatalogProductDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCatalogProductsByIdAsync([FromRoute] string id)
    {
        var result = await _mediator.Send(new ListCatalogProductsByIdQuery(id));

        if (result.IsFailed)
        {
            return CreateErrorResponse(result.Errors.First());
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType<CatalogProductDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCatalogProduct([FromBody] AddCatalogProductCommand request)
    {
        var result = await _mediator.Send(request);

        if (result.IsFailed)
        {
            return CreateErrorResponse(result.Errors.First());
        }

        var uri = HttpContext.Request.Path.Value;
        return Created(uri, result.Value);
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