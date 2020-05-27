using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternalAssessment
{
    public delegate void SumOfNumbersCallBack(int sumOfnum);

    class CallBack
    {
        public void SumOfNumbers(int sumNum)
        {
            Console.WriteLine("Sum of Numbers " +sumNum );
        }
        public void NoMain()
        {
            Console.WriteLine("Please enter the Target");
            int target = Convert.ToInt32(Console.ReadLine());
            SumOfNumbersCallBack sumOfdel = SumOfNumbers;//del is assigned to call back funct Sumofnum
            RetrieveDataThread rtd = new RetrieveDataThread(target , sumOfdel);
            Thread childThread = new Thread(new ThreadStart(rtd.ComputeSum));//this thread will return the value of sum to callback func
            childThread.Start();

        }
    }
    class RetrieveDataThread
    {
        private int _target;
        SumOfNumbersCallBack _sumdel;

        public RetrieveDataThread(int target, SumOfNumbersCallBack sumDel)
        {
            this._target = target;
            _sumdel = sumDel;
        }
        public void ComputeSum()
        {
            int sum = 0;
            for (int i = 0; i < _target; i++)
            {
                sum += i ;
            }
            _sumdel?.Invoke(sum);//if del is not null//if it is assigned to someone//Invoke the delegate passing interger value sum
        }
        //Thread is calling a Function which is indirectly invoking delegate with passing parameter.
    }

       
}
