namespace TheCursedBadlands
{
    public static class Saloon
    {
        public static void WesternSaloon(Player player)
        {
            Console.Clear();
            Methods.GameTitel();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n        ======  Saloon ======");
            Console.ResetColor();
            var p = player;
            Console.WriteLine($"\n-- HP: {p.CurrentHP}/{p.MaxHP} | Damage: {p.Damage}  | Gold: {p.Gold} --\n");
            Console.WriteLine("[1] Moonshine  (Full HP) - 13 gold");
            Console.WriteLine("[2] Whiskey shoot (+ 15 HP) - 5 gold");
            Console.WriteLine("[3] Leave Western Saloon.");
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Items(player, 13, 0, "Moonshine", true);
                    break;
                case 2:
                    Items(player, 5, 15, "Whiskey shot");
                    break;
                case 3:
                    Console.WriteLine("Returning to the game. ");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("\nPress any key to return to game");
            Console.ReadKey();

        }
        public static void Items(Player player, int price, int healAmount, string itemName, bool fullyHeal = false)
        {

            if (player.Gold < price)
            {
                Console.WriteLine($"❌ Not enogh gold to but this item.");
                Methods.Pause();
                return;
            }
            if (player.CurrentHP >= player.MaxHP)
            {
                Console.WriteLine($"\nYou already have full HP: {player.CurrentHP}/{player.MaxHP}");
                Methods.Pause();
                return;
            }

            player.Gold -= price;
            if (fullyHeal)
            {
                player.CurrentHP = player.MaxHP;
                Console.WriteLine($"\n{itemName} was bought and used. You are fully healed {player.CurrentHP}/{player.MaxHP}");
                Methods.Pause();
            }
            else
            {
                player.CurrentHP += healAmount;
            }

            if (player.CurrentHP > player.MaxHP)
            {
                player.CurrentHP = player.MaxHP;
            }
            Console.WriteLine($"\n{itemName} was used. + {healAmount}. HP: {player.CurrentHP}/{player.MaxHP}. Gold left: {player.Gold}");
            Methods.Pause();
        }
    }
}
