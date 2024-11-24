using Domain.Entities;
using Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventInfra
{
    public class EventProcessor<T> : IHostedService, IDisposable where T : EventArgs
    {
        EventWaitHandle _eventWaitHandle = new AutoResetEvent(true);
        private Timer _timer;
        protected  EventQueue<T> _eventQ { get; set; }
        protected EventPublisher<T> _publisher { get; set; }



        //public EventProcessor(IServiceProvider sp)
        //{
        //    _eventQ = sp.GetRequiredService<EventQueue<T>>();
        //    _publisher = sp.GetRequiredService<EventPublisher<T>>();


        //}


        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Will process the task every 10 seconds
            _timer = new Timer(ProcessEvents, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;

        }

        private void ProcessEvents(object state)
        {
            
            try
            {
                _eventWaitHandle.WaitOne();
                var eventToProcess = _eventQ.Dequeue();
                if (eventToProcess != null)
                {
                    _publisher.Invoke(eventToProcess);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally
            {
                _eventWaitHandle.Set();
            }
        }
        public void Dispose()
        {
            // Dispose the timer and event wait handle
            _timer?.Dispose();
            _eventWaitHandle?.Dispose();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }


    }
}
