using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EventHandler
{
    //This is a marker interface to load singletons eagerly when they are not used anywhereelse
    public interface IEagerSingleton
    {
    }
}
