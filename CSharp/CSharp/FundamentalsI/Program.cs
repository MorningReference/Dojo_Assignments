using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            // // Prints 1-255
            for(int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            // // Prints values from 1-100 that are divisible by 3 or 5, but not both
            for(int i = 1; i <= 100; i++)
            {
                if(!(i%3 == 0 && i%5 == 0))
                {
                    if(i%3 == 0 || i%5 == 0 )
                    {
                        Console.WriteLine(i);
                    }
                }
            }

            // // Prints Fizz for multiples of 3 and Buzz for multiples of 5, and FizzBuzz for numbers that are both multiples of 3 and 5
            for(int i = 1; i <= 100; i++)
            {
                if(i%3 == 0 && i%5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i%5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
            }

            // While loop versions
            int i = 1;
            while(i <= 255)
            {
                Console.WriteLine(i);
                i++;
            }

            while(i <= 100)
            {
                if(!(i%3 == 0 && i%5 == 0))
                {
                    if(i%3 == 0 || i%5 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
                i++;
            }

            while(i <= 100)
            {
                if(i%3 == 0 && i%5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i%5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                i++;
            }
        }
    }
}
