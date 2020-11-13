using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    public class BasketDbContext
    {
        private readonly ConnectionMultiplexer _connection;

        public BasketDbContext(ConnectionMultiplexer connection)
        {
            _connection = connection;
            Redis = connection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
