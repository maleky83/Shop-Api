using MediatR;
using Shop.Application.Categories.Dtos;

namespace Shop.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<CategoryDto>
{
    public Guid Id { get; } = id;
}
