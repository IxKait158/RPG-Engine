using System;
using System.Collections.Generic;
using System.Text;
using RPG_Engine.Items.Weapons;

namespace RPG_Engine.Items.Decorator
{
    internal interface IDecorator : IWeapon
    {
        public IWeapon Weapon { get; }
        public int Effect { get; }

    }
}
