using HtmlAgilityPack;
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
        }
    }
}
