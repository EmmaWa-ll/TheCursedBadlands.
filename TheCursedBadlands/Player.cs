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
            Console.WriteLine($"\n{CharacterClass} {Name} is ready to fight.!");
            Console.WriteLine($"HP:{CurrentHP} / {MaxHP} | Damage: {Damage} | Gold: {Gold} ");
        }

        public void PlayersTurn(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine($"⨠ {CharacterClass} {Name} attacks {enemy.Name} with {WeaponName}!");
            Console.WriteLine($"   ⌊ HP left: {CurrentHP}/{MaxHP}");

            enemy.CurrentHP -= Damage;
            if (enemy.CurrentHP <= 0)
            {
                Console.Clear();
                Console.WriteLine($"{enemy.Name} is defeated!!!!! ");
                return;
            }


            //Methods.ShowStatus(enemy.Name, enemy.CurrentHP, enemy.MaxHP);
        }
    }
}
