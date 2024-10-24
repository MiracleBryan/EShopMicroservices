﻿
namespace CatalogAPI.Models.Products.RemoveProductById
{
    public record RemoveProductByIdCommand(Guid Id) : ICommand<RemoveProductByIdCommandResult>;
    public record RemoveProductByIdCommandResult(bool IsSuccess);
    internal class RemoveProductByIdCommandHandler :
        ICommandHandler<RemoveProductByIdCommand, RemoveProductByIdCommandResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger _logger;

        public RemoveProductByIdCommandHandler(IDocumentSession session, ILogger logger) 
        {
            _session = session;
            _logger = logger;
        }
        public async Task<RemoveProductByIdCommandResult> Handle(RemoveProductByIdCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("RemoveProductByIdCommandHandler.Handle called with {@Command}", command);

            _session.Delete<Product>(command.Id);
            await _session.SaveChangesAsync(cancellationToken);

            return new RemoveProductByIdCommandResult(true);
        }
    }
}
