using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Engine.Items.Potions
{
    internal class ProtectionPotion : IPotion
    {
        public Item Name => Item.ProtectionPotion;

        public int Effect { get; }

        public ProtectionPotion(int protectionEffect)
        {
            Effect = protectionEffect;
        }
    }
}
