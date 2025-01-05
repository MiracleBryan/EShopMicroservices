﻿using System.Security;

namespace Basket.API.Basket.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(SecureString userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    }
}
