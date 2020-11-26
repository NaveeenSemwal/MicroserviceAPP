using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{

    /// <summary>
    /// 
    /// https://stackoverflow.com/questions/29761872/microservices-and-database-joins  :  Get data from multiple microservices
    /// 
    /// TODO :  https://www.youtube.com/watch?v=m7E5itCkCuA&t=11s
    ///    Authetication :     https://www.youtube.com/watch?v=jt1VWlmK8po
    ///    
    ///   https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
    ///   
    ///   https://docs.microsoft.com/en-us/dotnet/architecture/microservices/
    ///   
    /// https://www.youtube.com/watch?v=m7E5itCkCuA&t=323s  : LOGS
    /// 
    /// https://www.youtube.com/watch?v=A0jAeGf2zUQ&t=1849s : LOGS
    /// https://www.youtube.com/watch?v=rsNd2NkYeBQ
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType( typeof(IEnumerable<OrderResponse>),(int)HttpStatusCode.OK)]
        public async Task<IEnumerable<OrderResponse>> GetOrdersByUserName(string userName)
        {
            var request = new GetOrderByUserNameQuery(userName);

            return await _mediator.Send(request);
        }


        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<OrderResponse> CheckoutOrder([FromBody] CheckoutOrderCommand checkoutOrder)
        {
            return await _mediator.Send(checkoutOrder);
        }
    }
}
