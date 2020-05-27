using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternalAssessment
{   //Protecting Shared Resources
    class LockMonitor
    {
        int total = 0;  //Total field is a shared resources here being used by all 3 threads, so need to be protected for concurrent access.
                        // else all the three threads will return different Sum value in the end
        public void NoMain()
        {
            Thread thread1 = new Thread(new ThreadStart(AddOneMethod));
            Thread thread2 = new Thread(new ThreadStart(AddOneMethod));
            Thread thread3 = new Thread(new ThreadStart(AddOneMethod));
            thread1.Start();
            thread1.Start();
            thread1.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
        }
        //public void AddOneMethod()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        total++;
        //    }
        //}

        //public void AddOneMethod()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Interlocked.Increment(ref total);
        //    }
        //}

        static object _lock = new object();
        public void AddOneMethod()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (_lock)
                {
                    total++;
                }
            }
        }
        //Interlocking is better when we use Sysytem.Diagnostic, we can use stopwatch we can see Interlocking one completes early
        public void AddOne1Method()
        {
            for (int i = 1; i <= 10000; i++)
            {
                // Acquires the exclusive lock
                Monitor.Enter(_lock);
                try
                {
                    total++;
                }
                finally
                {
                    // Releases the exclusive lock
                    Monitor.Exit(_lock);
                }
            }
        }
    }
}
