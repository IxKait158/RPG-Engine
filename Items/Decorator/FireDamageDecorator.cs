using System;
using System.Collections.Generic;
using System.Text;
using RPG_Engine.Items;
using RPG_Engine.Items.Weapons;

namespace RPG_Engine.Items.Decorator
{
    internal class FireDamageDecorator : IDecorator
    {
        public Item Name => Item.FireEffect;

        public IWeapon Weapon { get; }

        public int Effect { get; }

        public FireDamageDecorator(IWeapon weapon)
        {
            Weapon = weapon;
            Effect = 10;
        }

        public int CalculateDamage()
        {
            return Weapon.CalculateDamage() + Effect;
        }
    }
}
