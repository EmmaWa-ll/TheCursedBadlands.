namespace TheCursedBadlands
{
    public class Enemy
    {
        public string Name;
        public int CurrentHP;
        public int MaxHP;
        public int Damage;
        public int Gold;
        public string WeaponName;


        public Enemy(string name, int maxhp, int currenthp, int damage, int gold, string weaponName)
        {
            Name = name;
            CurrentHP = currenthp; ;
            MaxHP = maxhp;
            Damage = damage;
            Gold = gold;
            WeaponName = weaponName;
        }


        public void EnemyTurn(Player player)
        {

            Console.WriteLine($"\n⨠ {Name} strikes back at {player.CharacterClass} {player.Name} with {WeaponName}");
            player.CurrentHP -= Damage;
            Console.WriteLine($"    {player.CharacterClass} {player.Name} takes {Damage} damage.  |  HP left: {player.CurrentHP}/{player.MaxHP}");
            Console.WriteLine("===============================================");



        }
    }
}
