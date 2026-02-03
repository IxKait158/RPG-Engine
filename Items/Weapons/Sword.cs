namespace RPG_Engine.Items.Weapons
{
    internal class Sword : IWeapon
    {
        public Item Name => Item.Sword;

        public int CalculateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(20, 25);
        }
    }
}
