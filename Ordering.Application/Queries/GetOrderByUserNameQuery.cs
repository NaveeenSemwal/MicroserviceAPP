using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Queries
{
    public class GetOrderByUserNameQuery
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
