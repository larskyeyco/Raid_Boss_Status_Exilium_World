using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raid_Boss_Status
{
    public class RaidStatus
    {
        public static void RaidBossList()
        {
            var raidBossList = new List<RaidBossModel>();
            HtmlWeb web = new HtmlWeb();
            var websiteBossList = "https://www.exiliumworld.com/servers/faris/boss";
            HtmlDocument document = web.Load(websiteBossList);
            var raids = document.DocumentNode.SelectNodes("//table//tbody").Skip(1).First();
            foreach (var raid in raids.SelectNodes(".//tr"))
            {
                raidBossList.AddRange(new List<RaidBossModel>()
                {
                    new RaidBossModel
                    {
                    Name = raid.SelectNodes(".//td")[0].InnerText.Replace("\n", "").Trim().Replace("\t", "").ToString(),
                    Level = Int32.Parse(raid.SelectNodes(".//td")[1].InnerText.Replace("\n", "").Trim().Replace("\t", "").ToString()),
                    Status = raid.SelectNodes(".//td")[2].InnerText.Replace("\n", "").Trim().Replace("\t", "").ToString(),
                    Spawn_Date = raid.SelectNodes(".//td")[3].InnerText.Replace("\n", "").Trim().Replace("\t", "").ToString()
                    }
                });
            }
            var raidBossListOrderBySpawnDate = raidBossList.OrderBy(x=>x.Spawn_Date);
            var raidBossListByLevel80Plus = raidBossListOrderBySpawnDate.Where(x => x.Level >= 80);
            foreach (var raidboss in raidBossListByLevel80Plus)
                {
                if (raidboss.Spawn_Date == "Alive")
                {
                    Console.WriteLine(raidboss.Level + "\t" + raidboss.Status + "\t" + raidboss.Name);
                }
                else
                {
                    Console.WriteLine(raidboss.Spawn_Date + "\t" + raidboss.Level + "\t" + raidboss.Name);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tPress F10 to refresh!");
            Console.ResetColor();
        }
    }
}