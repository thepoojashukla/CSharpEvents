using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace InternalAssessment
{
    class LearnThreadPool
    {
        static void NoMain(string[] args)
        {


            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");

            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();


            Console.WriteLine("Thread Execution");

            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();

            //ThreadPool is faster than thread
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Process));
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void Process(object callback)
        {

        }


    }
}

