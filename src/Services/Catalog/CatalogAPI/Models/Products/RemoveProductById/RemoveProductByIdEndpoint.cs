
using CatalogAPI.Models.Products.UpdateProductById;

namespace CatalogAPI.Models.Products.RemoveProductById
{
    //public record RemoveProductByIdRequest(Guid id);
    public record RemoveProductByIdResponse(bool IsSuccess);
    public class RemoveProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("products/{id}", async (Guid id, ISender sender) => 
            {
                var result = await sender.Send(new RemoveProductByIdCommand(id));
                var response = result.Adapt<RemoveProductByIdResponse>();
                return Results.Ok(response);

            })
                .WithName("RemoveProductById")
                .Produces<RemoveProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Remove Product by Id")
                .WithDescription("Remove Product By Id");
        }
    }
}
