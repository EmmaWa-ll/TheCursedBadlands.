namespace TheCursedBadlands
{
    public class EventManager
    {

        static Random randomEvent = new Random();

        public static List<Action<Player>> events = new List<Action<Player>>() //Lista som kan spara logiken (metoden) i listan, 
        {                                                                      //som kan skriva text OCH ändra spelaren status direkt
            BanditAmbush,
            FindGold,
            SnakeBite

        };

        public static void StartEvent(Player player)
        {
            int i = randomEvent.Next(events.Count);
            events[i](player);
        }

        public static void BanditAmbush(Player p)
        {

            Console.WriteLine($"\n Bandits jump from behind the rock and open fire!  You manage to escape but not withouta few wounds. (-10 HP)");
            p.CurrentHP -= 10;
            GameHelper.Pause();
        }

        public static void FindGold(Player p)
        {

            int gold = randomEvent.Next(5, 16);
            p.Gold += gold;
            Console.WriteLine($"\nWhile digging through and abandoned camp you stuble upon a hidden pouch of coins. (+{gold} gold)");
            GameHelper.Pause();
        }

        public static void SnakeBite(Player p)
        {
            Console.WriteLine($"\nYou step too close to a cactus and a rattlesnake lunges ou! It's fangs pierce your boot. (-5 HP)");
            p.CurrentHP = Math.Max(0, p.CurrentHP - 5);
            GameHelper.Pause();
        }
    }
}
