using AutoMapper;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Ordering.Application.Commands;
using Ordering.Core.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Ordering.API.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection, IMediator mediator,
            IOrderRepository orderRepository, IMapper mapper)
        {
            _connection = connection;
            _mediator = mediator;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            var queue = channel.QueueDeclare(EventBusConstants.BasketCheckoutQueue, false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(queue: EventBusConstants.BasketCheckoutQueue, autoAck: true, consumer: consumer);

        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            string @event = Encoding.UTF8.GetString(e.Body.ToArray());

            var basketCheckoutEvent = JsonSerializer.Deserialize<BasketCheckoutEvent>(@event);

            CheckoutOrderCommand checkoutOrder = _mapper.Map<CheckoutOrderCommand>(basketCheckoutEvent);

            _mediator.Send(checkoutOrder);

        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
