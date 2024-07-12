using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            string[] subjects = { "Math", "Science", "English" };
            string studentName = "Sue";

            // Instantiate student and add to people collection
            Student student = new Student(studentName, subjects);
            people.Add(student);

            string faculty = "Computer Science";
            string teacherName = "Tim";

            // Instantiate teacher and add to people collection
            Teacher teacher = new Teacher(teacherName, faculty);
            people.Add(teacher);

            // Iterate through people collection and invoke PrintDetails for each element
            foreach (Person person in people)
            {
                person.PrintDetails();
                Console.WriteLine(); // Add a blank line for separation
            }

            Console.ReadKey();
        }
    }
}
