using Basket.API.Data;
using Basket.API.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketDbContext _dbContext;

        public BasketRepository(IBasketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await _dbContext.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basketCart = await _dbContext.Redis.StringGetAsync(userName);

            if (basketCart.IsNullOrEmpty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<BasketCart>(basketCart);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            var updated = await _dbContext.Redis.StringSetAsync(basket.UserName, JsonSerializer.Serialize(basket));

            if (!updated)
            {
                return null;
            }
            return await GetBasket(basket.UserName);
        }
    }
}
