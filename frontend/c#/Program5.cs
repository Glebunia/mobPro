using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 50; i >= 25; i--)
            {
                string message = $"{i}";

                if (i % 3 == 0 && i % 5 == 0)
                {
                    message += " [3 & 5]";
                }
                else if (i % 3 == 0)
                {
                    message += " [3]";
                }
                else if (i % 5 == 0)
                {
                    message += " [5]";
                }

                Console.WriteLine(message);
            }

            Console.ReadKey();
        }
    }
}