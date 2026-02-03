using System;
using System.Collections.Generic;
using System.Text;
using RPG_Engine.Items;

namespace RPG_Engine.Items.Weapons
{
    internal interface IWeapon : IItem
    {
        int CalculateDamage();
    }
}
