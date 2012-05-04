using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class ExplosiveGunGame : Roll
    {
        public override string Name
        {
            get
            {
                return "Explosive Gungame";
            }
        }
        public override string Version
        {
            get
            {
                return "1.0";
            }
        }
        public override string Description
        {
            get
            {
                return "With a special reward at the end";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void doGun(object arg)
        {
            object[] arr = (object[])arg;
            string[] weapons = (string[])arr[0];
            ServerClient client = (ServerClient)arr[1];
            Core.GunGame(weapons, client, this);
        }

        public override void onInit(ServerClient Client)
        {
            string[] weapons = { "m320_mp",
                                "rpg_mp",
                                "iw5_smaw_mp",
                                "xm25_mp",
                                "frag_grenade_mp",
                                "semtex_mp"};

            ThreadHandler.AddThread(new WaitCallback(doGun), new object[] { weapons, Client });

        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
