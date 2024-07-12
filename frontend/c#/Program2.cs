using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
             // Parallel arrays for room names and prices
            string[] roomNames = { "Single", "Double", "Luxury", "Penthouse" };
            double[] roomPrices = { 45.50, 99.99, 165.25, 1095.50 };

            // Display available rooms and prices
            Console.WriteLine("Available Rooms:");
            for (int i = 0; i < roomNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {roomNames[i]} - ${roomPrices[i]} per night");
            }

            // Prompt user to select a room
            Console.Write("\nEnter the number corresponding to the room type: ");
            int roomChoice = Convert.ToInt32(Console.ReadLine());

            // Prompt user for number of nights
            Console.Write("Enter the number of nights: ");
            int numberOfNights = Convert.ToInt32(Console.ReadLine());

            // Calculate the total cost
            int index = roomChoice - 1; // adjusting for 0-based index
            double totalPrice = roomPrices[index] * numberOfNights;

            // Display the booking details
            Console.WriteLine($"\nFigure {roomNames[index]} room for {numberOfNights} nights - ${roomPrices[index]} * {numberOfNights} = ${totalPrice}");

            // Optional: Pause to see the result
            Console.ReadLine();
        }
    }
}
