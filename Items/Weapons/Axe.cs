namespace RPG_Engine.Items.Weapons
{
    internal class Axe : IWeapon
    {
        public Item Name => Item.Axe;

        public int CalculateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(10, 15);
        }
    }
}
