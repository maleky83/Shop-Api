using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Categories.Dtos;
using ShopManagementSystem.Application.Categories.Queries.GetAllCategories;
using ShopManagementSystem.Application.Categories.Queries.GetCategoryById;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("api/Categories")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        IEnumerable<CategoryDto> categories = await mediator.Send(new GetAllCategoriesQuery());

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] Guid id)
    {
        CategoryDto category = await mediator.Send(new GetCategoryByIdQuery(id));

        return Ok(category);
    }
}
