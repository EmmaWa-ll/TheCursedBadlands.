using NAudio.Wave;

namespace TheCursedBadlands
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;


            using var audioFile = new AudioFileReader("westernmusic.wav");
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            GameHelper.GameStoryChoice();
            GameHelper.GameTitel();
            Console.Write("\nWrite your username: ");
            string username = Console.ReadLine().Trim();



            Player currentPlayer = null;
            while (currentPlayer == null)
            {

                Console.Clear();
                GameHelper.GameTitel();
                Console.WriteLine("\n       =============================");
                Console.WriteLine("                  MENU ");
                Console.WriteLine("       =============================");
                Console.WriteLine("Aviable characters: ");
                Console.WriteLine("Sheriff | ❤️HP: 110 | ⚔️Damage: 7  | 💰Gold: 5 ");
                Console.WriteLine("Cowboy  | ❤️HP: 95  | ⚔️Damage: 12 | 💰Gold: 10");
                Console.WriteLine("Indian  | ❤️HP: 100 | ⚔️Damage: 10 | 💰Gold: 7 ");
                Console.WriteLine("\n[S]heriff | [C]owboy | [I]ndian |  [Q]uit");
                Console.Write("Your choice: ");
                string menuChoice = Console.ReadLine();




                switch (menuChoice.ToLower())
                {
                    case "s":
                        currentPlayer = new Player("Sheriff ", username, 110, 110, 7, 5, "Revolver");
                        Console.WriteLine($"\n{currentPlayer.CharacterClass} {currentPlayer.Name} is ready to fight.!");
                        currentPlayer.Stats();
                        break;
                    case "c":
                        currentPlayer = new Player("Cowboy", username, 95, 95, 12, 10, "Lasso");
                        Console.WriteLine($"\n{currentPlayer.CharacterClass} {currentPlayer.Name} is ready to fight.!");
                        currentPlayer.Stats();
                        break;
                    case "i":
                        currentPlayer = new Player("Indian", username, 100, 100, 10, 7, "Knife");
                        Console.WriteLine($"\n{currentPlayer.CharacterClass} {currentPlayer.Name} is ready to fight.!");
                        currentPlayer.Stats();
                        break;
                    case "q":
                        Console.WriteLine("The program quits.");
                        return;
                    default:
                        Console.WriteLine("What's that? Check again.");
                        break;
                }
                Console.Write("\nPress any key to start your adventure ");
                Console.ReadKey();
                Console.Clear();
            }


            Enemy[] enemies =
            {
                new Enemy("🧟 Zombie Cowboy", 60, 60, 5, 7, "Claws"),
                new Enemy("🐎 Ghost Rider", 100, 100, 7, 11, "Chains" ),
                new Enemy("🩻 Undead Gunslinger", 120, 120, 9, 14, "Broken revolver")
            };
            Random randomEnemy = new Random();



            while (currentPlayer.CurrentHP > 0)
            {
                Console.Clear();
                GameHelper.GameTitel();
                Console.WriteLine("\n              ====== Game Menu ======\n");
                Console.WriteLine("[A]dventure  |  [R]est  | [S]tats, | [G]unsmith  | [W]estern Saloon  |   [Q]uit ");
                Console.Write("\nYour choice: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "a":

                        Random randomEvent = new Random();
                        if (randomEvent.Next(100) < 40)
                        {
                            EventManager.StartEvent(currentPlayer);
                            Console.Clear();
                        }
                        Enemy choosenEnemy = enemies[randomEnemy.Next(enemies.Length)];
                        GameHelper.Adventure(currentPlayer, choosenEnemy);
                        break;

                    case "r":
                        GameHelper.Rest(currentPlayer);
                        break;

                    case "s":
                        currentPlayer.Stats();
                        break;
                    case "g":
                        Gunsmith.GunsmithShop(currentPlayer);
                        break;
                    case "w":
                        Saloon.WesternSaloon(currentPlayer);
                        break;
                    case "q":
                        Console.WriteLine("The program quits.");
                        return;
                    default:
                        Console.WriteLine("Invalid coice. Try again.");
                        break;


                }

            }


        }
    }
}
