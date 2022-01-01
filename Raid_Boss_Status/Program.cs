using System;

namespace Raid_Boss_Status
{
    public class Program
    {
        static void Main(string[] args)
        {
            RaidStatus.RaidBossList();
            while (true)
                if (Console.KeyAvailable)
                    if (Console.ReadKey(true).Key == ConsoleKey.F10)
                    {
                        Console.WriteLine("**********************REFRESHING**********************");
                        RaidStatus.RaidBossList();
                    }
        }
    }
}
