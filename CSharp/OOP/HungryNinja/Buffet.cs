using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Buffet
    {
        public List<Food> Menu;
        
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Burgers", 1000, false, false),
                new Food("Fried Rice", 500, true, false),
                new Food("Pizza", 1200, false, false),
                new Food("Chocolate Fondue", 700, false, true),
                new Food("Short Ribs", 600, false, true),
                new Food("Blazin' Wings", 300, true, false),
                new Food("Corn Chowder", 350, false, false)
            };
        }
        public Food Serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(8)];
        }
    }
}