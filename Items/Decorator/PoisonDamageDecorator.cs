using RPG_Engine.Items;
using RPG_Engine.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Engine.Items.Decorator
{
    internal class PoisonDamageDecorator : IDecorator
    {
        public Item Name => Item.PoisonEffect;
        public IWeapon Weapon { get; }

        public int Effect { get; }

        public PoisonDamageDecorator(IWeapon weapon)
        {
            Weapon = weapon;
            Effect = 4;
        }

        public int CalculateDamage()
        {
            return Weapon.CalculateDamage() + Effect;
        }
    }
}
