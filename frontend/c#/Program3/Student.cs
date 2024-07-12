using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Student : Person
    {
        private string[] _subjects;

        // Constructor
        public Student(string name, string[] subjects) : base(name)
        {
            _subjects = subjects;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Student Name: {_name}");
            Console.WriteLine("Subjects:");
            foreach (var subject in _subjects)
            {
                Console.WriteLine($"- {subject}");
            }
        }
    }
}