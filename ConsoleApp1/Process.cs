using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InternalAssessment
{
    class Process
    {
        public void ProcessData(int x, int y, RulesDel rules)
        {
            var result = rules(x, y);
            Console.WriteLine(result);
        }

        public void ProcessActionData(int x,int y, Action<int,int> actDel)
        {
            actDel(x, y); //doesnot return it is void by default;
            Console.WriteLine("Action Works");
        }
        public void ProcessFuncData(int x, int y, Func<int, int,int> funcDel)
        {
            int result = funcDel(x, y);
            Console.WriteLine(result);
        }


    }
}
