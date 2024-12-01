using Domain.Events;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.EventInfra;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly EventPublisher<OrderStatusEvent> _command;
        public OrderController(EventPublisher<OrderStatusEvent> command) {
            _command=command;
        }

        [HttpGet]
        







        [HttpPut]
        public IActionResult PutCommand()
        {
            Order o = new Order(Domain.Entities.Enums.OrderStatus.Pending)
            {
                Id=Guid.NewGuid()
            };
            OrderStatusEvent e = new OrderStatusEvent { OrderId=o.Id, OrderStatus=o.Status };
            _command.Publish(e);

            return Ok();
        }
    }
}
