using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternalAssessment
{
    class JoinAlive
    {
        //join lets main thread to wait for child thread to finish
        public void NoMain()
        {
            Console.WriteLine("CallingFunction started");
            Thread child1 = new Thread(new ThreadStart(Thread1Function));
            child1.Start();
            
            Thread child2 = new Thread(new ThreadStart(Thread2Function));
            child2.Start();

            if (child1.Join(1000))//main thread will wait for 1sec for child thread to finish
            {
                Console.WriteLine("thread1 is completed");//handled by main thread
            }
            else
            {
                Console.WriteLine("thread1 is not completed in 1 sec");
            }
            child2.Join(); //here main thread will wait untill child thread is completed
            Console.WriteLine("thread2 is completed");//handled by main thread

            if(child1.IsAlive)//returns bool
            {
                Console.WriteLine("Thread1 function is still doing it's job");
            }
            else
            {
                Console.WriteLine("thread1 is done");
            }
            Console.WriteLine("Calling Function completed");
        }
        public void Thread1Function()
        {
            Console.WriteLine("Thead1 started");
            Thread.Sleep(6000);
        }
        public void Thread2Function()
        {
            Console.WriteLine("Thead2 started");
        }
    }


}
