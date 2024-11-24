using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace Infrastructure.EventInfra
{
    public class EventPublisher<T> where T:EventArgs {
        public event EventHandler<T> _eventHandlers;
        private readonly EventQueue<T> _eventQ;

        public EventPublisher(EventQueue<T> eventQ)
        {
            _eventQ = eventQ;

        }

        public void Invoke(T eventToProcess)
        {
            _eventHandlers?.Invoke(this, eventToProcess);

        }
        public void Publish(T eventInstance)
        {
            //so that consequent requests can be made as soon as possible.
            _eventQ.Enqueue(eventInstance);
        }

        public void Subscribe(EventHandler<T> handler)
        {
            _eventHandlers+=handler;
        }

}
}
