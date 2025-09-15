namespace TheCursedBadlands
{
    public class Enemy
    {
        public string Name;
        public int CurrentHP;
        public int MaxHP;
        public int Damage;
        public int Gold;


        public Enemy(string name, int maxhp, int currenthp, int damage, int gold)
        {
            Name = name;
            CurrentHP = currenthp; ;
            MaxHP = maxhp;
            Damage = damage;
            Gold = gold;
        }


        public void EnemyTurn(Player player)
        {


            Console.WriteLine($"\n{Name} attacks {player.CharacterClass} {player.Name}");
            player.CurrentHP -= Damage;
            Methods.ShowStatus(player.Name, player.CurrentHP, player.MaxHP);


        }
    }
}
