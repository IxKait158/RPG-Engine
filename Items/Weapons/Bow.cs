namespace RPG_Engine.Items.Weapons
{
    internal class Bow : IWeapon
    {
        public Item Name => Item.Bow;

        public int CalculateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(10, 20);
        }
    }
}
