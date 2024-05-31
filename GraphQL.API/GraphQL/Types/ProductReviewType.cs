using GraphQL.API.GraphQL.Enums;
using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReviewEntity>
    {
        public ProductReviewType()
        {
            Field(x => x.Id).Description("The Id of the review");
            Field(x => x.Title).Description("The review title");
            Field(x => x.Review).Description("The review content");
        }
    }
}
