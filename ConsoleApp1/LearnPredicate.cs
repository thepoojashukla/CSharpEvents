using System;
using System.Collections.Generic;
using System.Text;

namespace InternalAssessment
{
    delegate void TestDelegate(string s);
    delegate int TestDelegate1();
    class LearnPredicate
    {
        public void TestPredicate()
        {
            //Custom delegate can be written inside a method
            Predicate<int> testPredicate = IsEvenNumber;
            var result = testPredicate(15);
            Predicate<int> tPredicate = delegate (int x) { return x % 2 == 0; };
            //x => x % 2 == 0; 

            TestDelegate testDelB = delegate (string s) { Console.WriteLine(s); };
            testDelB += delegate (string str) { };
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };
            TestDelegate1 test = () => { return 5 * 5; };
        }
        public bool IsEvenNumber(int num)
        {
           return num % 2 == 0;
            
        }
    }
}
