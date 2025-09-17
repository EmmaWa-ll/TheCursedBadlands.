namespace TheCursedBadlands
{
    public class Player
    {
        public string Name;
        public string CharacterClass;
        public int MaxHP;
        public int CurrentHP;
        public int Damage;
        public int Gold;
        public string WeaponName;

        public Player(string characterclass, string username, int maxhp, int currenthp, int damage, int gold, string weaponName)
        {
            CharacterClass = characterclass;
            Name = username;
            MaxHP = maxhp;
            CurrentHP = maxhp;
            Damage = damage;
            Gold = gold;
            WeaponName = weaponName;
        }
        public void Stats()
        {
            Console.WriteLine($"\nHP:{CurrentHP} / {MaxHP} | Damage: {Damage} | Gold: {Gold} | Weapon: {WeaponName} ");
            Console.ReadKey();
        }

        public void PlayersTurn(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine($"⨠  {CharacterClass} {Name} attacks {enemy.Name} with {WeaponName}!");

            enemy.CurrentHP -= Damage;
            if (enemy.CurrentHP <= 0)
            {
                enemy.CurrentHP = 0;
                Console.Clear();
                Console.WriteLine($"{enemy.Name} is defeated! ");
                Gold += enemy.Gold;
                Console.WriteLine($"You loot {enemy.Gold} gold. You have {Gold} gold!");
                GameHelper.Pause();
                return;
            }
            Console.WriteLine($"    {enemy.Name} takes {Damage} damage  |  HP left: {enemy.CurrentHP}/{enemy.MaxHP}");

        }
    }
}
