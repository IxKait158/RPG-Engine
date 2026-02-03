using RPG_Engine.Characters.Enemies;

namespace RPG_Engine.Characters
{
    internal static class EnemyFactory
    {
        private static readonly Random _rnd = new Random();

        public static Enemy CreateRandomEnemy()
        {
            int value = _rnd.Next(1, 10);

            if (value >= 1 && value < 5)
                return new Goblin();
            else if (value >= 5 && value < 9)
                return new Skeleton();
            else if (value == 9)
                return new Dragon();

            return null;
        }
    }
}
