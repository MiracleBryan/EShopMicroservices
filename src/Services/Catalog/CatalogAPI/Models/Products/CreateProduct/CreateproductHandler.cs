using BuildingBlocks.CQRS;

namespace CatalogAPI.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
            :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateproductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
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

            //Save to Database ---TODO

            //Return the result
            return new CreateProductResult(Guid.NewGuid());

            throw new NotImplementedException();
        }
    }
}
