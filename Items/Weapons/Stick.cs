using RPG_Engine.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Engine.Items.Weapons
{
    internal class Stick : IWeapon
    {
        public Item Name => Item.Stick;

        public int CalculateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(5, 10);
        }
    }
}
