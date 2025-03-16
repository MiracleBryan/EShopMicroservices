
namespace CatalogAPI.Models.Products.UpdateProductById
{
    public record UpdateProductByIdCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductByIdResult>;
    public record UpdateProductByIdResult(bool IsSuccess);
    public class UpdateProductByIdCommandValidator : AbstractValidator<UpdateProductByIdCommand> 
    {
        public UpdateProductByIdCommandValidator() 
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Product Id is required");
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2,150).WithMessage("Name must be between 2 and 150 characters");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        }
    }
    internal class UpdateProductByIdCommandHandler 
        : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        private readonly IDocumentSession _session;
        public UpdateProductByIdCommandHandler(IDocumentSession session, ILogger<UpdateProductByIdCommandHandler> logger)
        {
            _session = session;
        }
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {

            var product = await _session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null) 
            {
                throw new ProductNotFoundException(command.Id);
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
