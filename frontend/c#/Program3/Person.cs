using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Person
    {
        protected string _name;

        // Constructor
        public Person(string name)
        {
            _name = name;
        }

        // Abstract method (to be overridden in derived classes)
        public abstract void PrintDetails();
    }
}