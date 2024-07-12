using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // File paths
            string inputFile = "characters.txt";
            string outputFile = "character-count.txt";

            // Read content from characters.txt
            string content = File.ReadAllText(inputFile);

            // Dictionary to store character counts
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            // Initialize counts for A-Z
            for (char c = 'A'; c <= 'Z'; c++)
            {
                charCount[c] = 0;
            }

            // Count occurrences of each character
            foreach (char c in content)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
            }

            // Write results to character-count.txt
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var kvp in charCount)
                {
                    writer.WriteLine($"{kvp.Key} {kvp.Value}");
                }
            }

            Console.WriteLine("Character counts have been written to character-count.txt.");

            Console.ReadKey();
        }
    }
}