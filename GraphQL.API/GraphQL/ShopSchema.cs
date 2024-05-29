using GraphQL.Types;
using Microsoft.Extensions.DependencyModel;

namespace GraphQL.API.GraphQL
{
    public class ShopSchema : Schema
    {
        public ShopSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<ShopQuery>(); // This API Supports Data retrieval
            //Mutation = provider.GetRequiredService<ShopMutation>();
            //Subscription = provider.GetRequiredService<ShopSubscription>();
        }
    }
}
