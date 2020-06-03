using System;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet bacchanal = new Buffet();
            SweetTooth toothy = new SweetTooth();
            SpiceHound houndy = new SpiceHound();

            while (toothy.IsFull == false)
            {
                toothy.Consume(bacchanal.Serve());
            }
            while (houndy.IsFull == false)
            {
                houndy.Consume(bacchanal.Serve());
            }

            if (toothy.ConsumptionHistory.Count > houndy.ConsumptionHistory.Count)
            {
                Console.WriteLine($"SweetTooth has eaten more! Total consumed items: {toothy.ConsumptionHistory.Count}!");
            }
            else if (toothy.ConsumptionHistory.Count < houndy.ConsumptionHistory.Count)
            {
                Console.WriteLine($"SpiceHound has eaten more! Total consumed items: {houndy.ConsumptionHistory.Count}!");
            }
            else
            {
                Console.WriteLine("It's a tie! SweetTooth and SpiceHound has eaten the same amount.");
            }
        }
    }
}
