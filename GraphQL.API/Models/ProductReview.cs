namespace GraphQL.API.Models;

public class ProductReview
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Review { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public Product Product { get; set; } = default!;
}