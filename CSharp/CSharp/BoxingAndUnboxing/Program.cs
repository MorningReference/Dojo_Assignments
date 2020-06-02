using System;
using System.Collections.Generic;

namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxedData = new List<object>();
            boxedData.Add(7);
            boxedData.Add(28);
            boxedData.Add(-1);
            boxedData.Add(true);
            boxedData.Add("chair");
            int sum = 0;
            foreach (var entry in boxedData)
            {
                Console.WriteLine(entry);
                if(entry is int)
                {
                    sum += (int)entry;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
