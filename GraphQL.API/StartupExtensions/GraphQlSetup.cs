using GraphQL.API.GraphQL;
using GraphQL.API.Options;
using GraphQL.DataLoader;

namespace GraphQL.API.StartupExtensions
{
    public static class GraphQlSetup
    {
        public static IServiceCollection AddGraphQlAPI(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddScoped<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddScoped<DataLoaderDocumentListener>();
            services.AddGraphQL(builder => builder
                .ConfigureExecutionOptions(options =>
                {
                    options.ThrowOnUnhandledException = true;
                    options.EnableMetrics = true;
                })
                .AddSelfActivatingSchema<ShopSchema>(DI.ServiceLifetime.Scoped)
                .AddErrorInfoProvider()
                .AddAutoClrMappings()
                .AddSystemTextJson()
                .AddErrorInfoProvider(options =>
                {
                    options.ExposeExceptionDetails = true;
                    options.ExposeExtensions = true;
                    options.ExposeCode = true;
                    options.ExposeData = true;
                    options.ExposeCodes = true;
                })
                .AddDataLoader()
                .AddGraphTypes());
            return services;
        }

        public static IApplicationBuilder AddGraphQl(this IApplicationBuilder app, IConfiguration configuration)
        {
            GraphQlConfig config = configuration.GetSection("GraphQlConfig").Get<GraphQlConfig>()!;

            app.UseGraphQL<ShopSchema>(config.GraphQlApiEndpoint, config =>
            {
                config.AuthorizationRequired = false;
                config.HandlePost = true;
                config.HandleWebSockets = true;
                config.EnableBatchedRequests = true;
            });

            if (config.ShowUi)
            {
                app.UseGraphQLPlayground(config.UiEndpoint, new()
                {
                    GraphQLEndPoint = config.GraphQlApiEndpoint,
                });
            }

            if (config.ShowVisualNodes)
            {
                app.UseGraphQLVoyager(config.VisualNodesEndpoint, new()
                {
                    GraphQLEndPoint = config.GraphQlApiEndpoint,
                });
            }
            return app;
        }
    }
}
