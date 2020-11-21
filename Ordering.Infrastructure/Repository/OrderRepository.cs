using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repository
{
    public class OrderRepository 
    {
        //public OrderRepository(OrderContext dbContext) : base(dbContext)
        //{
        //}

        public Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
