using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Task<bool> DeleteBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketCart> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            throw new NotImplementedException();
        }
    }
}
