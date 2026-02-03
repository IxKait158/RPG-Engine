using RPG_Engine.Core;
using RPG_Engine.Items;
using RPG_Engine.Items.Decorator;
using RPG_Engine.Items.Potions;
using RPG_Engine.Items.Weapons;

namespace RPG_Engine.Characters
{
    internal class Hero : GameCharacter
    {
        private int _protection;

        public bool IsWeaponEquiped { get; private set; }
        public IWeapon Weapon { get; private set; }

        public int Experience { get; private set; } = 0;

        public Inventory<IItem> Items { get; set; } = new();

        public Hero(string name) : base(name)
        {
            Health = 100;
            Level = 0;
        }

        public void UseItem(IItem item)
        {
            if (item == null)
                throw new NullReferenceException();

            if (item is IPotion potion) 
                UsePositon(potion);
            else if (item is IWeapon weapon)
                EquipWeapon(weapon);
        }

        private void UsePositon(IPotion potion)
        {
            if (potion is HealingPotion healing)
            {
                Health += healing.Effect;
                Console.WriteLine($"{Name} used healing potion!");
            }
            else if (potion is ProtectionPotion protection)
            {
                _protection = protection.Effect;
                Console.WriteLine($"{Name} used protection potion!");
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private void EquipWeapon(IWeapon weapon)
        {
            Weapon = weapon;
            IsWeaponEquiped = true;
            if (weapon is IDecorator decorator)
                Console.WriteLine($"{Name} equiped weapon {decorator.Weapon.Name} with {decorator.Name}!");
            else
                Console.WriteLine($"{Name} equiped weapon {weapon.Name}!");
        }

        public void AddExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} XP!");

            if (Experience >= 100)
            {
                Experience -= 100;
                Level++;
                Console.WriteLine($"{Name} LEVE UP! Now level {Level}");
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage - _protection);
        }

        public override void Attack(GameCharacter target)
        {
            int damage = 5;
            if (IsWeaponEquiped)
                damage = Weapon.CalculateDamage();

            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }

        public override string ToString() => $"{Name} status: Health {Health}, Level {Level}, Experience {Experience}\n";
    }
}
