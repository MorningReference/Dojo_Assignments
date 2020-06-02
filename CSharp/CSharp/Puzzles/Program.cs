using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            Console.WriteLine(TossMultipleCoins(10));
            List<string> names =  Names();
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static int[] RandomArray()
        {
            int[] randArr = new int[10];
            Random rand = new Random();
            for (int i = 0; i < randArr.Length; i++)
            {
                randArr[i] = rand.Next(5,25);
            }
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < randArr.Length; i++)
            {
                if(randArr[i] < min)
                {
                    min = randArr[i];
                }
                if(randArr[i] > max)
                {
                    max = randArr[i];
                }
                sum += randArr[i];
            }
            Console.WriteLine($"The min is: {min}. The max is: {max}. The sum is: {sum}");
            return randArr;
        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int result = rand.Next(2);
            if(result == 0)
            {
                Console.WriteLine("Heads!");
                return "Heads";
            }
            else if(result == 1)
            {
                Console.WriteLine("Tails!");
                return "Tails";
            }
            return "Nothing?";
        }

        public static Double TossMultipleCoins(int num)
        {
            Random rand = new Random();
            int result = 0;
            double countHeads = 0;
            double countTails = 0;
            for (int i = 0; i < num; i++)
            {
                result = rand.Next(2);
                if(result == 0)
                {
                    Console.WriteLine("Heads!");
                    countHeads++;
                }
                else if(result == 1)
                {
                    Console.WriteLine("Tails!");
                    countTails++;
                }
            }
            double ratio = countHeads/countTails;
            return ratio;
        }

        public static List<string> Names()
        {
            List<string> names = new List<string> {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            int n = names.Count;
            string temp = "";

            while(n > 1)
            {
                n--;
                int i = rand.Next(n+1);
                temp = names[i];
                names[i] = names[n];
                names[n] = temp;
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            for (int i = 0; i < names.Count; i++)
            {
                if(names[i].Length < 5)
                {
                    names.Remove(names[i]);
                }
            }
            return names;
        }

    }
}
