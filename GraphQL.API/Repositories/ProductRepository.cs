using GraphQL.API.Data;
using GraphQL.API.Models;

namespace GraphQL.API.Repositories
{
    public class ProductRepository : Repository<ProductEntity, int>, IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<ILookup<int, ProductEntity>> GetAllAsync()
        {
            return Task.FromResult(_context.Products
                .ToLookup(x => x.Id));
        }
    }
}
