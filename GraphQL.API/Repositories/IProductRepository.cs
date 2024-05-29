using GraphQL.API.Models;

namespace GraphQL.API.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity, int>
    {
        Task<ILookup<int, ProductEntity>> GetAllAsync();
    }
}
