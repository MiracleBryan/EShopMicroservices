
namespace CatalogAPI.Models.Products.UpdateProductById
{
    public record UpdateProductByIdCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductByIdResult>;
    public record UpdateProductByIdResult(bool IsSuccess);

    internal class UpdateProductByIdCommandHandler 
        : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger _logger;
        public UpdateProductByIdCommandHandler(IDocumentSession session, ILogger logger)
        {
            _session = session;
            _logger = logger;
        }
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateProductByIdCommandHandler.Handle called with {@Command}", command);

            var product = await _session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null) 
            {
                throw new ProductNotFoundException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            _session.Update(product);
            await _session.SaveChangesAsync(cancellationToken);

            return new UpdateProductByIdResult(true);
        }
    }
}
