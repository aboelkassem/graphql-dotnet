using GraphQL.API.GraphQL.Queries;
using GraphQL.API.Models;
using GraphQL.API.Repositories;
using GraphQL.Types;

namespace GraphQL.API.GraphQL
{
    public class ShopQuery : ObjectGraphType
    {
        public ShopQuery(IRepository<ProductEntity, int> productRepository)
        {
            // GraphGL take care of the serializing of ProductEntity to ProductType automatically

            this.AddProductQuery(productRepository);
        }
    }
}
