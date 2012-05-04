using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class SubmachineGunGame : Roll
    {
        public override string Name
        {
            get
            {
                return "Submachine Gungame";
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
            string[] weapons = { 
            "iw5_mp5_mp",
            "iw5_mp7_mp",
            "iw5_m9_mp",
            "iw5_p90_mp",
            "iw5_pp90m1_mp",
            "iw5_ump45_mp" };

            ThreadHandler.AddThread(new WaitCallback(doGun), new object[] { weapons, Client });

        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
