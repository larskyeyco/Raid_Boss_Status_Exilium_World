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
            HtmlDocument document = web.Load("https://www.exiliumworld.com/servers/faris/boss");
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
            foreach (var item in raidBossList.OrderByDescending(x => x.Spawn_Date).Where(x => x.Level >= 80))
            {
                if (item.Spawn_Date == "Alive")
                {
                    Console.WriteLine(item.Level + "\t" + item.Status + "\t" + item.Name);
                }
                else
                {
                    Console.WriteLine(item.Spawn_Date + "\t" + item.Level + "\t" + item.Name);
                }
            }
        }
    }
}
