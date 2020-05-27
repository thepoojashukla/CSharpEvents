using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternalAssessment
{      //Type safe Parameterised Thread Start //Passing data to Thread Function
    class TypeSafeParam
    {
        private int _target;
        public TypeSafeParam(int target)
        {
            this._target = target;
        }
        public void PrintNumbers() //non static       //we don't need parameter to be passed here we can use target through ctor
        {
                for (int i = 0; i < _target; i++)
                {
                    Console.WriteLine(i);
                }
           
        }
    }

    class TypesafeParameterised
    {
        public void NoMain()
        {
            Console.WriteLine("Please enter the value");
            int target = Convert.ToInt32(Console.Read());

            TypeSafeParam tp = new TypeSafeParam(target);
                                
            Thread childThread = new Thread(tp.PrintNumbers);//compiler does it behind scene
            childThread.Start();
        }

    }
}
