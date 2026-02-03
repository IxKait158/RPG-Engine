using RPG_Engine.Characters;
using RPG_Engine.Characters.Enemies;

namespace RPG_Engine.Core
{
    internal class GameManager
    {
        private readonly Hero _hero;

        public GameManager(Hero hero)
        {
            _hero = hero;
        }

        public void HandleHeroDie(object? sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME IS OVER!");
            Console.ResetColor();
        }

        public void HandleEnemyDied(object? sender, EventArgs e)
        {
            if (sender is Enemy enemy)
            {
                Console.WriteLine($"You defeated {enemy.Name}!");
                _hero.AddExperience(enemy.ExperienceReward);
            }
        }
    }
}
