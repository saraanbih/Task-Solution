using System;

namespace Problem
{
    class Program
    {
        static int IncrementDecrementOperations(List<string> operations) 
        {
            int result = 0;
            foreach (string operation in operations) 
            {
                if (operation == "++") result++;
                else if(operation == "--") result--;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter operations like (++,--) and" +
                " put a space between every operation like (++ --) to make sure that results are correct:");
            string op = Console.ReadLine();

            if(op == string.Empty)
                Console.WriteLine("You haven't entered anything");
            else
            {
                List<string> operations = new List<string>(op.Split(' '));

                int result = IncrementDecrementOperations(operations);

                Console.WriteLine($"Final Result is: {result}");
            }
        }
    }
}