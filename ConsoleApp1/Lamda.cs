using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InternalAssessment
{
    //Custom Delegate
    public delegate int RulesDel(int x, int y);
    class Lamda
    {
        public delegate int AddNumbers(int x, int x2);
        public delegate bool LogDelegate();
        
        public static void NoMain()
        {
            //a)Anonymous Method

            Worker worker = new Worker();
            worker.workPerformedeve += delegate (object sender, WorkPerformedEventArgs e) { Console.WriteLine("Hours worked in a day" + e.Hours + " " + e.Work); };

            AddNumbers addDel = (x, y) => x + y; //Anonymous method's data type will be figured out by compiler depending on type of delegate it is assigned to
            int result = addDel(1, 1); //this is assumed to return value though return keyword not used as our delegate return int


            //b)If a Delegate is without Parameter, How to Use Lamda there
            LogDelegate log = () => { return true; };


            //c) Using Worker Class //No need of Anonymous method
            worker.workPerformedeve += (s, e) => { Console.WriteLine("Hours worked" + e.Hours + " " + e.Work); }; // With { } we can write multiple lines of code.

            //d) Following business rule, not hardcoging the handler method
            RulesDel adddel = (x, y) => x + y;
            RulesDel muldel = (x, y) => x * y;

            Process pc = new Process();
            pc.ProcessData(2,3,adddel);//Call a method which invokes RulesDel delegate

            //e) Inbuilt Action Delegate

            Action<int, int> actAdd = (x, y) => Console.WriteLine(x + y);
            Action<int, int> multAct =(x, y) => Console.WriteLine(x* y);
            pc.ProcessActionData(2, 3, multAct);

            //f) Func delegate(last T is out type)

            Func<int, int, int> addFuc = (x, y) => x + y;
            Func<int, int, int> mulFunc = (x, y) => x * y;
            pc.ProcessFuncData(2, 3, mulFunc);

            //Other way to understand Func
            string[] strArr = new string[10];
            Func<string, bool> funcDel;
            if (strArr.Length > 5)
            {
                funcDel = LogToEvent;
            }
            else funcDel = LogToFile; ;
                                   
        }

        public static bool LogToEvent(string message) { return true; }
        public static bool LogToFile(string message) { return true; }

    }
}
