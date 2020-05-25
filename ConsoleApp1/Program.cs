
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace InternalAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            Employee e2 = new Employee();
            Employee e3 = new Employee();

            int result = e2 + e1;
            Console.WriteLine("Employee Count" +result);

            Worker worker = new Worker();
            //worker.workPerformedeve += new EventHandler<WorkPerformedEventArgs>(Worker_workPerformedeve);// evenhandler is assigned to method handler
            //dirctly assign a method without dynamic type assignment

            worker.workPerformedeve += Worker_workPerformedeve;
            worker.DoWork(8, WorkType.Gamer);// calling a function which further will invoke this delegate
            Console.ReadLine();

            worker.workCompleted += new EventHandler(Worker_workCompleted);

            //List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var xyz = myList.Where(x => x > 3).ToList();
        }

        private static void Worker_workCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker's Day job is done");
        }

        private static void Worker_workPerformedeve(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked" + e.Hours +" " + e.Work);
        }
    }
}
