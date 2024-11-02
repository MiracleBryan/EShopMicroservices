using BuildingBlocks.Exceptions;

namespace CatalogAPI.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base("Product", Id)
        {
        }
        public ProductNotFoundException(string Property) : base("Product", Property)
        {
        }
    }
}
