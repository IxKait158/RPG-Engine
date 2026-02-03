using System;
using System.Collections.Generic;
using System.Text;
using RPG_Engine.Characters.Enemies;

namespace RPG_Engine.Core
{
    internal abstract class GameCharacter
    {
        public event EventHandler OnDied;

        public string Name { get; }
        public int Health { get; protected set; }
        protected int Level { get; set; }

        protected GameCharacter(string name) => Name = name;

        public abstract void Attack(GameCharacter target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} taken {damage} damage");

            if (Health <= 0)
            {
                Console.WriteLine($"{Name} died!");
                OnDied?.Invoke(this, EventArgs.Empty);
            }
        }

        public override string ToString() => $"{Name} status: Health {Health}, Level {Level}\n";
    }
}
