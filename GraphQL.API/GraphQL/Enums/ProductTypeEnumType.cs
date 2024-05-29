using GraphQL.Types;

namespace GraphQL.API.GraphQL.Enums
{
    // EnumerationGraphType is base for all scalar types like int, string
    public class ProductTypeEnumType : EnumerationGraphType<Models.ProductType>
    {
        public ProductTypeEnumType() 
        {
            Name = "Type";
            Description = "The type of product";
        }
    }
}
