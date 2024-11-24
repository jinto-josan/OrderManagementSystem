using Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventInfra
{
    public class OrderStatusEventProcessor:EventProcessor<OrderStatusEvent>
    {
        public OrderStatusEventProcessor(EventPublisher<OrderStatusEvent> ep,
            EventQueue<OrderStatusEvent> eq) {

            //This had to be done like this because injecting the dependency to base doesnt work.
            
            _eventQ=eq;
            _publisher=ep;
        }
    }
}
