using RPG_Engine.Characters;
using RPG_Engine.Core;
using RPG_Engine.Items.Decorator;
using RPG_Engine.Items.Potions;
using RPG_Engine.Items.Weapons;
using RPG_Engine.Services;

namespace RPG_Engine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fs = new FileIOServices($"{Environment.CurrentDirectory}\\game_save.json");

            var hero = fs.Load();

            var enemy = EnemyFactory.CreateRandomEnemy();

            var gm = new GameManager(hero);
            hero.OnDied += gm.HandleHeroDie;

            bool gameIsOver = false;
            while (!gameIsOver)
            {
                if (hero.Health <= 0)
                {
                    gameIsOver = true;
                    break;
                }

                if (enemy.Health < 0)
                {
                    enemy = EnemyFactory.CreateRandomEnemy();
                }
                Console.WriteLine(enemy);

                PrintMenu(hero);
                Console.Write("> ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    hero.Attack(enemy);
                }
                else if (choice == 2)
                {
                    Random rnd = new Random();

                    if (rnd.Next(1, 3) == 1)
                    {
                        Console.WriteLine("You ran away! Game is over!");
                        gameIsOver = true;
                    }
                    else
                    {
                        Console.WriteLine("You cant run away!");
                        int damage = rnd.Next(70, 100);
                        hero.TakeDamage(damage);
                    }
                }
                else if (choice < 0 || choice >= hero.Items.GetAllItems().Count())
                {
                    Console.WriteLine("Incorrect choice. Try again");
                }
                else
                {
                    int index = choice - 3;
                    hero.UseItem(hero.Items.GetItemByIndex(index));
                }

                if (!gameIsOver)
                    enemy.Attack(hero);
            }
        }

        static public void PrintMenu(Hero hero)
        {
            Console.WriteLine($"Your turn! {hero}");

            if (hero.IsWeaponEquiped)
                Console.WriteLine($"1. Attack with {hero.Weapon.Name}");
            else
                Console.WriteLine($"1. Attack without weapon");

            Console.WriteLine($"2. Try to run away");
            PrintInventory(hero);
        }

        static public void PrintInventory(Hero hero)
        {
            int i = 0;
            foreach (var item in hero.Items.GetAllItems())
            {
                if (item is IWeapon && item is not IDecorator)
                {
                    Console.WriteLine($"{i + 3}. Equip {item.Name}");
                }
                else if (item is IDecorator decorator)
                {
                    Console.WriteLine($"{i + 3}. Equip {decorator.Weapon.Name} with {decorator.Name} (+{decorator.Effect} damage)");
                }
                else if (item is HealingPotion healing)
                {
                    Console.WriteLine($"{i + 3}. Drink potion {item.Name} (+{healing.Effect} HP)");
                }
                else if (item is ProtectionPotion protection)
                {
                    Console.WriteLine($"{i + 3}. Drink potion {item.Name} (-{protection.Effect} taken damage)");
                }

                i++;
            }
        }
    }
}