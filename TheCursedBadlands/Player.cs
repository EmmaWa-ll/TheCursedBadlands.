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

        public Player(string characterclass, string username, int maxhp, int currenthp, int damage, int gold)
        {
            CharacterClass = characterclass;
            Name = username;
            MaxHP = maxhp;
            CurrentHP = maxhp;
            Damage = damage;
            Gold = gold;
        }
        public void Stats()
        {
            Console.WriteLine($"\n{CharacterClass} {Name} is ready for a fight.!");
            Console.WriteLine($"HP:{CurrentHP} / {MaxHP} | Damage: {Damage} | Gold: {Gold} ");
        }

        public void PlayersTurn(Enemy enemy)
        {

            Console.WriteLine($"{CharacterClass} {Name} attacks {enemy.Name}");


            enemy.CurrentHP -= Damage;
            if (enemy.CurrentHP <= 0)
            {
                Console.WriteLine($"{enemy.Name} is defeated! ");
                return;
            }
            Methods.ShowStatus(enemy.Name, enemy.CurrentHP, enemy.MaxHP);


        }



    }
}
