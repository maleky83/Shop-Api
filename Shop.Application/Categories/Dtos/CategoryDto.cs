namespace Shop.Application.Categories.Dtos;

public class CategoryDto
{
    public int CategoryId { get; set; } = default!;
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
}
