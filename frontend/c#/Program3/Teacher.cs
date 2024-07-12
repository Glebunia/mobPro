using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Teacher : Person
    {
        private string _faculty;

        // Constructor
        public Teacher(string name, string faculty) : base(name)
        {
            _faculty = faculty;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Teacher Name: {_name}");
            Console.WriteLine($"Faculty: {_faculty}");
        }
    }
}