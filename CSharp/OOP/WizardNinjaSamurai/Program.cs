using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard harry = new Wizard("Harry");
            Ninja naruto = new Ninja("Naruto");
            Samurai musashi = new Samurai("Musashi");
            harry.DisplayStats();
            naruto.DisplayStats();
            musashi.DisplayStats();
            
            musashi.Attack(naruto);
            naruto.DisplayStats();
            musashi.Attack(naruto);
            naruto.DisplayStats();

            harry.Heal(naruto);
            harry.Heal(naruto);
            harry.Heal(naruto);
            
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Attack(musashi);
            naruto.Steal(musashi);
            musashi.Meditate();
            musashi.DisplayStats();
            naruto.DisplayStats();
        }
    }
}
