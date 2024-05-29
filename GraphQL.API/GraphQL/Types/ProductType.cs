using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Types
{
    public class ProductType : ObjectGraphType<ProductEntity>
    {
        public ProductType()
        {
            Field(x => x.Id).Description("The Id of the product");
            Field(x => x.Name).Description("The name of the product");
            Field(x => x.Description).Description("The description of the product");
        }
    }
}
