using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_external_cs.Hacks
{
    public class ClantagChanger : HackBase
    {
        public static ClantagChanger Instance = new ClantagChanger();

        public ClantagChanger()
        {
            Name = "Clantag Changer";
        }

        public override bool Initialize()
        {
            return false;
        }
     }
}
