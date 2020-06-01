using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            int[] intArrays = {0,1,2,3,4,5,6,7,8,9};
            string[] stringArrays = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boolArrays = {true, false, true, false, true, false, true, false, true, false};

            //List of Flavors
            List<string> iceCreamFlavors = new List<string>{"Vanilla", "Chocolate", "Chocolate Chip", "Cookies and Cream", "Strawberry"};
            Console.WriteLine(iceCreamFlavors.Count);
            Console.WriteLine(iceCreamFlavors[2]);
            iceCreamFlavors.RemoveAt(2);
            Console.WriteLine(iceCreamFlavors.Count);

            //User Info Dictionary
            Dictionary<string,string> userInfo = new Dictionary<string, string>{};
            for(int i = 0; i < stringArrays.Length; i++)
            {
                userInfo.Add(stringArrays[i],iceCreamFlavors[i]);
            }
            foreach(KeyValuePair<string,string> entry in userInfo)
            {
                Console.WriteLine($"{entry.Key}" + "'s favorite flavor is " + $"{entry.Value}");
            }
        }
    }
}
