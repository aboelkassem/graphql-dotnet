using GraphQL.API.GraphQL.Enums;
using GraphQL.API.Models;
using GraphQL.API.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Types
{
    public class ProductType : ObjectGraphType<ProductEntity>
    {
        public ProductType(
            IProductReviewRepository reviewRepository,
            IDataLoaderContextAccessor dataLoaderAccessor
            )
        {
            Field(x => x.Id).Description("The Id of the product");
            Field(x => x.Name).Description("The name of the product");
            Field(x => x.Description).Description("The description of the product");
            Field(x => x.IntroducedAt).Description("When the product was first introduced");
            Field(x => x.PhotoFileName).Description("The Photo File Name of the product");
            Field(x => x.Price).Description("The Price of the product");
            Field(x => x.Rating).Description("The Rating of the product");
            Field(x => x.Stock).Description("The Stock of the product");

            Field<ProductTypeEnumType>("Type").Description("The type of product"); // Custom Enum type scalar

            Field<ListGraphType<ProductReviewType>>("Reviews")
                .ResolveAsync(async context =>
                {
                    var loader = dataLoaderAccessor.Context!
                    .GetOrAddCollectionBatchLoader<int, ProductReviewEntity>("GetReviewsByProductIds", reviewRepository.GetReviewsByProductId);
                    return loader.LoadAsync(context.Source.Id);
                }).Description("The reviews of the product");
        }
    }
}
