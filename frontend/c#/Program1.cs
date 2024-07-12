using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Enter the first integer value:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the operator (-, +, *, /):");
            char op = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter the second integer value:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = 0;
            string operationWord = "";

            // Perform the calculation based on the operator
            switch (op)
            {
                case '-':
                    result = num1 - num2;
                    operationWord = "minus";
                    break;
                case '+':
                    result = num1 + num2;
                    operationWord = "plus";
                    break;
                case '*':
                    result = num1 * num2;
                    operationWord = "multiplied by";
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operationWord = "divided by";
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero");
                        return; // Exit the program if division by zero
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator entered.");
                    return; // Exit the program for invalid operator
            }

            // Display the result in words
            Console.WriteLine($"The result of {num1} {operationWord} {num2} is {result}.");

            // Pause to see the result (optional)
            Console.ReadLine();
        }
    }
}
