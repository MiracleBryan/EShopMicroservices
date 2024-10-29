

namespace CatalogAPI.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
            :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    internal class CreateproductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _session;
            private readonly IValidator<CreateProductCommand> _validator;

        // Constructor to inject the session
        public CreateproductCommandHandler(IDocumentSession session, IValidator<CreateProductCommand> validator)
        {
            _session = session;
            _validator = validator;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(command, cancellationToken);
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            if (errors.Any()) 
            {
                    throw new ValidationException(errors.FirstOrDefault());
            }

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
