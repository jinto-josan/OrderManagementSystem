using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventInfra
{
    public class EventQueue<T> where T: EventArgs
    {
        private readonly Queue<T> _eventQueue = new Queue<T>();
        private readonly object _lock = new object();

        public void Enqueue(T eventItem)
        {
            lock (_lock)
            {
                _eventQueue.Enqueue(eventItem);
            }
        }
        public T Dequeue()
        {
            lock (_lock)
            {
                return _eventQueue.Count > 0 ? _eventQueue.Dequeue() : null;
            }
        }

    }
}
