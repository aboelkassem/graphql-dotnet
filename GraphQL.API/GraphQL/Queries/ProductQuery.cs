using GraphQL.API.Models;
using GraphQL.API.Repositories;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Queries
{
    public static class ProductQuery
    {
        public static void AddProductQuery(this ShopQuery This, IRepository<ProductEntity, int> productRepository)
        {
            // GraphGL take care of the serializing of ProductEntity to ProductType automatically
            This.Field<ListGraphType<GraphQL.Types.ProductType>>(name: "products")
                .ResolveAsync(async context => await productRepository.GetAllAsync())
                .Description("Get all available products");
        }
    }
}
