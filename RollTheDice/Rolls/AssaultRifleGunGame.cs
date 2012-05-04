using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class AssaultRifleGunGame : Roll
    {
        public override string Name
        {
            get
            {
                return "Assault Rifle Gungame";
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
            string[] weapons = {"iw5_m4_mp",
                                "iw5_ak47_mp",
                                "iw5_m16_mp",
                                "iw5_fad_mp",
                                "iw5_acr_mp",
                                "iw5_type95_mp",
                                "iw5_mk14_mp",
                                "iw5_scar_mp",
                                "iw5_g36c_mp",
                                "iw5_cm901_mp"};

            ThreadHandler.AddThread(new WaitCallback(doGun), new object[] { weapons, Client });

        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
