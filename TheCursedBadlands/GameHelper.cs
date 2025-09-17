namespace TheCursedBadlands
{
    internal class GameHelper
    {

        public static void GameTitel()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("             🌵 The Cursed Badlands 🌵");
            Console.ResetColor();
        }

        public static void GameStoryChoice()
        {

            GameTitel();
            Console.WriteLine("\nPress [S] to hear the story   ||   Press[G] to start the game imidietly");
            string choice = Console.ReadLine().Trim().ToLower();

            switch (choice)
            {
                case "s":
                    ShowGameIntro();
                    break;

                case "g":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid choice.try again.");
                    return;

            }
        }

        public static void ShowGameIntro()
        {


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("           🌵 The Cursed Badlands 🌵\n");
            Console.ResetColor();

            Console.WriteLine("The frontier is not what is used to be...");
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("\nWhere once cowboys and indians rode free and sheriffs upheld the law");
            Console.WriteLine("dark forces now rule.");
            System.Threading.Thread.Sleep(4000);

            Console.WriteLine("\nFew dare to set foot in these lands... but you are not like the others.");
            Console.WriteLine("Armed with courage, steel and a handful of bullets you ride off into the Badlands");
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("\nWill you claim gold or glory. ");
            Console.WriteLine("or become just another tale in the legend of The Cursed Badlands? ");

            Console.WriteLine("\nPress any key to start your adventure.");
            Console.ReadKey();
            Console.Clear();
        }


        public static void Adventure(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("================================================\n");
            Console.WriteLine($"The {enemy.Name} has arrived!");
            var e = enemy;
            Console.WriteLine($"HP: {e.CurrentHP} | Damage: {e.Damage} | Gold: {e.Gold}");
            Console.WriteLine("\n================================================");

            Fight(player, enemy);
        }


        public static void ShowStatus(string name, int hp, int maxhp)
        {
            Console.WriteLine($"{name}: {hp} / {maxhp} HP");
        }


        public static void Pause()
        {
            Console.WriteLine("\npress any key to continue.");
            Console.ReadKey();
        }


        public static void Fight(Player player, Enemy enemy)
        {

            while (player.CurrentHP > 0 && enemy.CurrentHP > 0)
            {

                Console.WriteLine("\nYour turn. ");
                Console.WriteLine("[A]ttack  |  [H]eal  | [R]un ");
                Console.Write("Choose your next move: ");
                string playersTurn = Console.ReadLine().ToLower();

                Console.Clear();

                switch (playersTurn)
                {
                    case "a":

                        player.PlayersTurn(enemy);

                        enemy.EnemyTurn(player);

                        break;


                    case "h":

                        Console.Clear();
                        int healPrice = 5;
                        int healAmount = 10;

                        if (player.Gold < healPrice)
                        {
                            Console.WriteLine($"\n❌ You don't have enoght gold to heal! | Current gold: {player.Gold} ");
                            Pause();
                            return;
                        }


                        player.Gold -= healPrice;
                        player.CurrentHP += healAmount;
                        Console.WriteLine($"{player.Name} healed + 15 HP/{player.MaxHP}   |   - 5 gold / {player.Gold} gold left");
                        Pause();


                        if (player.CurrentHP > player.MaxHP)
                        {
                            player.CurrentHP = player.MaxHP;
                        }

                        Pause();
                        break;

                    case "r":

                        Console.WriteLine($"{player.CharacterClass} {player.Name} runs away!!! ");
                        Pause();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Pause();
                        break;
                }

            }
        }


        public static void Rest(Player player)
        {

            int rest = 10;
            int halfHP = player.MaxHP / 2;
            if (player.CurrentHP >= halfHP)
            {
                Console.WriteLine("\nYou can't rest over half your HP.");

            }

            if (player.CurrentHP <= halfHP)
            {
                player.CurrentHP += rest;
                Console.WriteLine($"{player.Name} rested by the bonfire and gained {rest} HP / {player.MaxHP}");

                if (player.CurrentHP > halfHP)
                {
                    player.CurrentHP = halfHP;

                }
            }
            Console.WriteLine($"Current HP: {player.CurrentHP}/{player.MaxHP}");
            Console.WriteLine("\nPress any key to continue your adventure.");
            Console.ReadKey();
        }

    }
}
