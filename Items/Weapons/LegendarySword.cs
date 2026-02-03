namespace RPG_Engine.Items.Weapons
{
    internal class LegendarySword : IWeapon
    {
        public Item Name => Item.LegendarySword;

        public int CalculateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(35, 50);
        }
    }
}
