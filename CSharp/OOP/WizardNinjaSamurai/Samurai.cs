using System;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Strength = 25;
            health = 200;
        }

        public void Meditate()
        {
            health = 200;
            Console.WriteLine($"{Name} is at full health!");
        }

        public override int Attack(Human target)
        {
            Console.WriteLine($"Has {target.health} hp");
            if(target.health < 50)
            {
                Console.WriteLine($"Critical hit! {Name} attacked {target.Name} for {target.health} damage!");
                target.health = 0;
            }
            else
            {
                base.Attack(target);
            }
            return target.health;

        }
    }
}