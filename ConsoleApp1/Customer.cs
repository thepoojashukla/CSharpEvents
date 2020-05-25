using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InternalAssessment
{
    class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public void LearnLambda()
        {
            //Use of Collections
            var customer = new List<Customer>
            {
                new Customer{ID = 1000,FirstName = "Pooja", LastName = "Shukla", City="New Delhi"  },
                new Customer{ID = 1001,FirstName = "Abhinav", LastName = "Tiwari", City="Seattle"  },
                new Customer{ID = 1002,FirstName = "Mayra", LastName = "Mehta", City="Mumbai"  },
                new Customer{ID = 1003,FirstName = "Shilpa", LastName = "reddy", City="Mumbai"  },
            };

            //Use of Linq Query
            var cCity = customer.Where(c => c.City == "Mumbai" && ID <1003);
            //where is for Applying Filteron customer List
            var cCustName = customer.Where(c => c.City == "Mumbai").OrderBy(c => c.FirstName);
            foreach (var cust in cCustName)
            {
                //Prints two 
                Console.WriteLine(cust);
            }

        }
    }
}
