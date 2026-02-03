using RPG_Engine.Core;

namespace RPG_Engine.Characters.Enemies
{
    internal class Dragon : Enemy
    {
        public Dragon() : base("Ancient Dragon", 200, 25, 10, 100) { }

        public override void Attack(GameCharacter target)
        {
            Console.WriteLine($"{Name} breathes fire!");
            base.Attack(target);
        }
    }
}
