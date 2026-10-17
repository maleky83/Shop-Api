using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Dtos;
using Shop.Application.Products.Queries.GetAllProducts;
using Shop.Application.Products.Queries.GetProductById;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(
    IMediator mediator
    ) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        IEnumerable<ProductDto> products = await mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
    {
        ProductDto product = await mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
       CreateProductCommand command)
    {
        int productId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateProduct(
        [FromRoute] int id,
        [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] int id)
    {
        await mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
