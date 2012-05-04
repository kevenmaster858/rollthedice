using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class SniperGunGame : Roll
    {
        public override string Name
        {
            get
            {
                return "Sniper Gungame";
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
            string[] weapons = {"iw5_barrett_mp",
                                "iw5_rsass_mp",
                                "iw5_dragunov_mp",
                                "iw5_msr_mp",
                                "iw5_l96a1_mp",
                                "iw5_as50_mp"};

            ThreadHandler.AddThread(new WaitCallback(doGun), new object[] { weapons, Client });

        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
