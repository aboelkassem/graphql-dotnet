using GraphQL.API.GraphQL.Types;
using GraphQL.API.Repositories;
using GraphQL.Types;

namespace GraphQL.API.GraphQL
{
    public class ShopQuery : ObjectGraphType
    {
        public ShopQuery(IProductRepository productRepository)
        {
            // GraphGL take care of the conversion of ProductEntity to ProductType
            Field<ListGraphType<ProductType>>(name: "products")
                .ResolveAsync(async context => await productRepository.GetAllAsync()); // how data is resolved
        }
    }
}
