using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcuRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.TitleScreen();
            g.Credits();
        }
    }

    public class Game
    {
        public string n;
        public string c;

        public void TitleScreen()
        {
            Console.WriteLine("            _                             ");
            Console.WriteLine("           | |                            ");
            Console.WriteLine("   ___ __ _| | ___ _   _ _ __ _ __   __ _ ");
            Console.WriteLine("  / __/ _` | |/ __| | | | '__| '_ \\ / _` |");
            Console.WriteLine(" | (_| (_| | | (__| |_| | |  | |_) | (_| |");
            Console.WriteLine("  \\___\\__,_|_|\\___|\\__,_|_|  | .__/ \\__, |");
            Console.WriteLine("                             | |     __/ |");
            Console.WriteLine("                             |_|    |___/ ");
            Console.WriteLine("(C) 2018 Oneware Studios, all rights reserved.");
            Console.WriteLine("");
            Console.Write("Press any key to begin! ");
            Console.ReadKey();
            CharacterCreation();
        }    
        
        public void CharacterCreation()
        {
            Start:
            Console.Clear();

            Name:
            Console.WriteLine("Enter character name.");
            Console.Write("Name: ");
            n = Console.ReadLine();
            if (n == "")
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("Error: Empty name.");
                goto Name;
            }
            Console.Clear();

            Class:
            List<string> classes = new List<string> { "warrior", "archer", "mage" };
            Console.WriteLine("Select a class.");
            Console.WriteLine("Available classes: Warrior, Archer, Mage");
            Console.Write("Class: ");
            c = Console.ReadLine().ToLower();
            if (!classes.Contains(c))
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("Error: Invalid class.");
                goto Class;
            }

            Overview:
            Console.Clear();
            Console.WriteLine("Name: " + n);
            Console.WriteLine("Class: " + c.Substring(0, 1).ToUpper() + c.Substring(1));
            Console.WriteLine("");
            Console.WriteLine("OK? Y/N");

            string confirm = Console.ReadLine();
            if (!confirm.ToLower().Equals("n") && !confirm.ToLower().Equals("y")) goto Overview;
            if (confirm.ToLower().Equals("n")) goto Start;

            Main();
        }

        public void Main()
        {
            Encounter("Wolf", 100);
        }

        public void Encounter(string animal, int health)
        {
            int h = health;
            int es = 0;
            int s = 0;
            Console.Clear();
            Prompt:
            if (h <= 0) goto Defeat;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   " + animal + ": " + h + "   ");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("   Special: " + s + "   " + Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine("A wild " + animal + " appeared!");

            if (c.Equals("warrior"))
            {
                Console.WriteLine(" 1 = Slash (14 damage)");
                if (s >= 2) Console.WriteLine(" 2 = Hammer (50 damage)");
                if (s == 3) Console.WriteLine(" 3 = Night Sky (100 damage)");
                int attack = 0;
                try { attack = int.Parse(Console.ReadLine()); }
                catch (FormatException e) { goto Prompt; }
                if (attack < 1 || attack > 3) goto Prompt;
                if (attack == 1)
                {
                    h -= 14;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Slash! " + animal + " took 14 damage!");
                    Console.WriteLine("");
                    s++;
                    goto EnemyAttack;
                }
                if (attack == 2 && s >= 2)
                {
                    h -= 50;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Hammer! " + animal + " took 50 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                if (attack == 3 && s == 3)
                {
                    h -= 100;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Night Sky! " + animal + " took 100 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                goto Prompt;
            }

            if (c.Equals("archer"))
            {
                Console.WriteLine(" 1 = Arrow (15 damage)");
                if (s >= 2) Console.WriteLine(" 2 = Multi Arrow (45 damage)");
                if (s == 3) Console.WriteLine(" 3 = Volley (150 damage)");
                int attack = 0;
                try { attack = int.Parse(Console.ReadLine()); }
                catch (FormatException e) { goto Prompt; }
                if (attack < 1 || attack > 3) goto Prompt;
                if (attack == 1)
                {
                    h -= 15;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Arrow! " + animal + " took 15 damage!");
                    Console.WriteLine("");
                    s++;
                    goto EnemyAttack;
                }
                if (attack == 2 && s >= 2)
                {
                    h -= 45;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Multi Arrow! " + animal + " took 45 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                if (attack == 3 && s == 3)
                {
                    h -= 100;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Volley! " + animal + " took 150 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                goto Prompt;
            }

            if (c.Equals("mage"))
            {
                Console.WriteLine(" 1 = Fireball (5 damage)");
                if (s >= 2) Console.WriteLine(" 2 = Tornado (60 damage)");
                if (s == 3) Console.WriteLine(" 3 = Meteor Rain (200 damage)");
                int attack = 0;
                try { attack = int.Parse(Console.ReadLine()); }
                catch (FormatException e) { goto Prompt; }
                if (attack < 1 || attack > 3) goto Prompt;
                if (attack == 1)
                {
                    h -= 5;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Arrow! " + animal + " took 5 damage!");
                    Console.WriteLine("");
                    s++;
                    goto EnemyAttack;
                }
                if (attack == 2 && s >= 2)
                {
                    h -= 60;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Multi Arrow! " + animal + " took 70 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                if (attack == 3 && s == 3)
                {
                    h -= 200;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("");
                    Console.WriteLine(n + " used Meteor Rain! " + animal + " took 200 damage!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    s = 0;
                    goto EnemyAttack;
                }
                goto Prompt;
            }

            EnemyAttack:
            if (h <= 0) goto Defeat;

            Console.WriteLine("");
            if (animal == "Wolf")
            {
                if (es < 3) Console.WriteLine("Wolf used Claw! " + n + " took 5 damage!");
                else Console.WriteLine("Wolf used Cursed Howl! " + n + " took 50 damage!");
            }
            Console.WriteLine("");
            es++;
            goto Prompt;

            Defeat:
            Console.WriteLine("You defeated the " + animal + "!");
            Console.Write("Press any key to continue! ");
            Console.ReadKey();
            return;
        }

        public void Credits()
        {
            Console.Clear();
            Console.WriteLine("            _                             ");
            Console.WriteLine("           | |                            ");
            Console.WriteLine("   ___ __ _| | ___ _   _ _ __ _ __   __ _ ");
            Console.WriteLine("  / __/ _` | |/ __| | | | '__| '_ \\ / _` |");
            Console.WriteLine(" | (_| (_| | | (__| |_| | |  | |_) | (_| |");
            Console.WriteLine("  \\___\\__,_|_|\\___|\\__,_|_|  | .__/ \\__, |");
            Console.WriteLine("                             | |     __/ |");
            Console.WriteLine("                             |_|    |___/ ");
            Console.WriteLine("");
            Console.WriteLine("Game Design: Morgan Hofmann");
            //Console.WriteLine("Special Thanks: Sergiu Bucur, Dario Alves");
            Console.WriteLine("");
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("(C) 2018 Oneware Studios, all rights reserved.");
            Console.WriteLine("");
            Console.Write("Press any key to close! ");
            Console.ReadKey();
        }
    }
}
