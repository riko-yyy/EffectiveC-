using System;
using System.Linq;

namespace effectiveCSharp.Util
{
    public class DbMock
    {
        public IQueryable<Customer> Customers;

        public DbMock()
        {
            Customers = new[] {
                new Customer { ContactName = "a" },
                new Customer { ContactName = "b" },
                new Customer { ContactName = "c" },
                new Customer { ContactName = "d" },
            }.AsQueryable();
        }


    }

    public class Customer
    {
        public string ContactName;
    }
}
