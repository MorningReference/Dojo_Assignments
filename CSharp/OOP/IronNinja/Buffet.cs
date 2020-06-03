using System;
using System.Collections.Generic;

namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;

        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Burgers", 1000, false, false),
                new Food("Fried Rice", 500, true, false),
                new Food("Pizza", 1200, false, false),
                new Food("Chocolate Fondue", 700, false, true),
                new Food("Short Ribs", 600, false, true),
                new Food("Blazin' Wings", 300, true, false),
                new Food("Corn Chowder", 350, false, false),
                new Drink("Sprite", 200, false, true),
                new Drink("Powerade", 150, false, true),
                new Drink ("Spiced Chai", 10, true, false)
            };
        }
        public IConsumable Serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(10)];
        }
    }
}