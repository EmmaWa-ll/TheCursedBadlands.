namespace TheCursedBadlands
{
    public class Gunsmith
    {
        public static void GunsmithShop(Player player)
        {



            while (true)
            {
                Console.Clear();
                Methods.GameTitel();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n            ======  Gunsmith ======");
                Console.ResetColor();
                var p = player;
                Console.WriteLine($"\n-- HP: {p.CurrentHP}/{p.MaxHP} | Damage: {p.Damage}  | Gold: {p.Gold} --\n");
                Console.WriteLine("[1] Cattleman revolver  (+3 Damage) - 8 gold.");
                Console.WriteLine("[2] Repeater Carbine    (+5 Damage) - 15 gold");
                Console.WriteLine("[3] Indian Hornbow      (+7 Damage) - 20 gold");
                Console.WriteLine("[4] Leave gunsmith");
                Console.Write("\nYour choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BuyWeapon(player, 8, 3, "Cattleman revolver");
                        break;

                    case 2:
                        BuyWeapon(player, 15, 5, "Repeater carbine");
                        break;

                    case 3:
                        BuyWeapon(player, 20, 7, "Indian Hornbow");
                        break;

                    case 4:
                        Console.WriteLine("Returning to the game.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. ");
                        break;
                }

            }
        }

        public static void BuyWeapon(Player player, int price, int damageBoost, string weaponName)
        {
            if (player.Gold < price)
            {
                Console.WriteLine($"❌ Not enought gold to buy {weaponName}. You have {player.Gold} gold");
                Methods.Pause();
                return;
            }
            player.Gold -= price;
            player.Damage = damageBoost;
            player.WeaponName = weaponName;

            Console.WriteLine($"You bought {weaponName} for {price} gold. You have {player.Gold} gold left. ");
            Console.WriteLine($"Damage is now {player.Damage}");
            Methods.Pause();
        }
    }
}
