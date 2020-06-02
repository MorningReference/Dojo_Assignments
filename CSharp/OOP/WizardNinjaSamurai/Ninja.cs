using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        public Ninja(string name): base(name)
        {
            Dexterity = 175;
        }

        public void Steal(Human target)
        {
            target.health -= 5;
            health += 5;
            Console.WriteLine($"{Name} stole {target.Name}'s hit points for 5 damage!");
        }

        public override int Attack(Human target)
        {
            Random crit = new Random();
            int dmg = Dexterity * 5;
            if(crit.Next(6) == 1 )
            {
                dmg += 10;
            }
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }
}