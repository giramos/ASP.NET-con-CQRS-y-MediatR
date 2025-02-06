using Features.Products.Commands;
using Features.Products.Queries;
using Features.Products.Queries.GetProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_con_CQRS_y_MediatR.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<GetProductsQueryResponse>> GetProducts() => _mediator.Send(new GetProductsQuery());

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet("{ProductId}")]
    public Task<GetProductQueryResponse> GetProductById([FromRoute] GetProductQuery query)
    {
        return _mediator.Send(query); // 
    }
}
