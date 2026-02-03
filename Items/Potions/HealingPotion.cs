namespace RPG_Engine.Items.Potions
{
    internal class HealingPotion : IPotion
    {
        public Item Name => Item.HealingPotion;

        public int Effect { get; }

        public HealingPotion(int healing)
        {
            Effect = healing;
        }
    }
}
