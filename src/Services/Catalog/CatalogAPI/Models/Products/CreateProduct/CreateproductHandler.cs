namespace CatalogAPI.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
            :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateproductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _session;

        // Constructor to inject the session
        public CreateproductCommandHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create Product entity
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //Save to Database
            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);

            //Return the result
            return new CreateProductResult(product.Id);
        }
    }
}
