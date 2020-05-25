using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel.Design;
using System.Transactions;

namespace InternalAssessment
{
    interface IEmployee
    {
        string Name
        {
            get;
            set;
        }
       
        int Emp_Id
        {
            get;
        }

        //delegate int Employee
    }

    //[AttributeUsage(AttributeTargets.All)] // can not be used here as it is inherting other class as well
    public class Employee : IEmployee
    {
        string empname = " ";
        int count = 10;
        public string Name    // when we implement Interface we need to make field methods public 
        {
            get
            {
                return empname;
            }

            set
            {
                empname = value;
            }
        }

        public int Emp_Id
        {
            get
            {
                return count;
            }
        }

        public static int operator+ (Employee emp, Employee emp1)
        {
            Employee emp2 = new Employee();
            emp2.count = emp.count + emp1.count;
            return emp2.count;
        }

        public double SalaryCalc( string deptname, int exp)
        {
            switch(exp)
            {
                case 1:
                        return (2 * empList[deptname]);
                default:
                    return (5 * empList[deptname]);
            }
        }

        SortedList<string, int> empList = new SortedList<string, int> { { "Grocery", 1000 }, { "IT", 2000 }, { "Cashier", 1200 } };


    }

    [AttributeUsage(AttributeTargets.All)]
    class Traderjoe : System.Attribute
    {
        int usBranch;
        int[] empArr = new int[] { 1, 2, 3, 4, 5 };
        Dictionary<string, int> empList = new Dictionary<string, int> { { "Grocery", 1200 }, { "IT", 2000 }, { "Cashier", 1300 } };

        int this[int val]
        {
            get { return empArr[val]; }
            set { empArr[val] = value; }

        }
        public Traderjoe()
        {

        }
        public Traderjoe(int branches)
        {
           
            usBranch = branches;
        }

        public double TraderEmpSalaryCal(string deptname, int exp)
        {
            return exp * empList[deptname];
        }

        
    }

    [Traderjoe(5)]
    class TraderEmp : System.Attribute//
    {
        delegate double Salarydelg(string curr,int num);
        delegate double DeltoDel(string curr, int num);
        public void FindSalary()
        {
            Employee emp = new Employee();
            Traderjoe tj = new Traderjoe();
            Salarydelg empSaldel = emp.SalaryCalc;
            Salarydelg empSaldel2 = emp.SalaryCalc;
            empSaldel += tj.TraderEmpSalaryCal;
            double result = empSaldel("Grocery", 1);

            DeltoDel del2 = new DeltoDel(emp.SalaryCalc);

            //Assign delegate to delegate of one delegate type
            empSaldel += empSaldel2;//+ empSaldel3 //Invoking follows sequence

            //If the functions are returning value 

            double result2 = empSaldel("Grocery", 1); // This will return value of the last delegate assigned in the list
             //bcz it's Pointer it is reference type
        }
    }
}
