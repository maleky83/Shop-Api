using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Products.Commands.CreateProduct;
using ShopManagementSystem.Application.Products.Commands.DeleteProduct;
using ShopManagementSystem.Application.Products.Commands.UpdateProduct;
using ShopManagementSystem.Application.Products.Dtos;
using ShopManagementSystem.Application.Products.Queries.GetAllProducts;
using ShopManagementSystem.Application.Products.Queries.GetProductById;

namespace ShopManagementSystem.Api.Controllers;

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
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] Guid id)
    {
        ProductDto product = await mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
       CreateProductCommand command)
    {
        Guid productId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateProduct(
        [FromRoute] Guid id,
        [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
