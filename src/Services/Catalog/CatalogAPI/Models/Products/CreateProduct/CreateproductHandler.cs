﻿using MediatR;

namespace CatalogAPI.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
            :IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateproductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Business logic to create a product

            throw new NotImplementedException();
        }
    }
}