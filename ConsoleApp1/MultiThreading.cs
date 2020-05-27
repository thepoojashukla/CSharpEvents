using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternalAssessment
{
    class MultiThreading
    {
        public static void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            
        }
    }

    class LearnThread
    {
        public void NoMain()
        {
            //Framework behind the scene creates delegate
            //Some ways of creating Threads with different ways of assigning Delegates

            //Thread childThread = new Thread(MultiThreading.PrintNumbers);
             Thread childThread = new Thread(new ThreadStart(MultiThreading.PrintNumbers));
            //Thread childThread = new Thread(delegate () { MultiThreading.PrintNumbers();});
            //Thread childThread = new Thread(() => { MultiThreading.PrintNumbers(); });
            childThread.Start();
            //Thread Constructor() expexts Thread delegate in Parameter
        }
    }
}
