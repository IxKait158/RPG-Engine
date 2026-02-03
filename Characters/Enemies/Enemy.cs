using RPG_Engine.Core;
using RPG_Engine.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace RPG_Engine.Characters.Enemies
{
    internal class Enemy : GameCharacter
    {
        private int Damage { get; }
        public int ExperienceReward { get; }

        protected Enemy(string name, int health, int damage, int level, int experienceReward) : base(name)
        {
            Health = health;
            Damage = damage;
            Level = level;
            ExperienceReward = experienceReward;
        }

        public override void Attack(GameCharacter target)
        {
            Random rnd = new Random();
            int calculatedDamage = Damage + rnd.Next(-4, 5);

            Console.WriteLine($"{Name} attacks {target.Name} for {calculatedDamage} damage!");
            target.TakeDamage(calculatedDamage);
        }
    }
}
