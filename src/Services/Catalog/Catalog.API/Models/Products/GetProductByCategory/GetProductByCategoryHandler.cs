
namespace CatalogAPI.Models.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    
    internal class GetProductByCategoryQueryHandler
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        private readonly IDocumentSession _session;


        public GetProductByCategoryQueryHandler(IDocumentSession session) 
        {
            _session = session;
        }

        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
           
            var products = await _session.Query<Product>()
                .Where(p => p.Category.Contains(query.Category))
                .ToListAsync();

            if (products is null) 
            {
                throw new ProductNotFoundException(query.Category);
            }
            return new GetProductByCategoryResult(products);
        }
    }
}
