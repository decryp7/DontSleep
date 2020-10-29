using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DontSleep
{
    class Program
    {
        private static readonly ManualResetEvent waitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            NativeMethods.PreventSleep();
            //wait forever
            waitEvent.WaitOne();
        }
    }
}
