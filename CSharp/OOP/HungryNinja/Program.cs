using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet WickedSpoon = new Buffet();
            Ninja JohnWick = new Ninja();

            while(!JohnWick.IsFull)
            {
                JohnWick.Eat(WickedSpoon.Serve());
                Console.WriteLine($"John ate: {WickedSpoon.Serve().Name}.");
                Console.WriteLine($"Is John full yet? {JohnWick.IsFull}");
            }
            Console.WriteLine("Buffet Success!");
        }
    }
}
