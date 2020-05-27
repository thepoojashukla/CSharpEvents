using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace InternalAssessment
{            //Parameterised Thread Start
    class LearnMultiT
    {
        public void PrintNumbers(object target) //non static
        {
            if (int.TryParse(target.ToString(), out int number))
            {
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    class ParameterisedDel
    {
        public void NoMain()
        {
            Console.WriteLine("Please enter the value");
            object target = Console.Read();
            LearnMultiT pmNum = new LearnMultiT();
            //ParameterizedThreadStart pmStart = new ParameterizedThreadStart(pmNum.PrintNumbers);
            //Thread childThread = new Thread(pmStart);

            Thread childThread = new Thread(pmNum.PrintNumbers);//compiler does it behind scene
            childThread.Start(target);
        }

    }
}