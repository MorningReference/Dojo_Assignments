using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Bob = new Human("Bob");
            Human George = new Human("George", 10,10,10,200);
            Bob.Attack(George);
            Console.WriteLine(George.Health);
        }
    }
}
