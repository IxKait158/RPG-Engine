using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Engine.Items.Potions
{
    internal interface IPotion : IItem
    {
        public int Effect { get; }
    }
}
