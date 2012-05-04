using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class OverkillHeartbeat : Roll
    {
        public override string Name
        {
            get
            {
                return "Overkill Heartbeat Sensor";
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
                return "";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void heartbeat(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Core.RemoveAllBut(true, Client);
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

            Core.Ammoz(Client);
            int WepID = Owner.GetWeapon(Core.getRandom(weapons) + "_heartbeat");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Owner.SetClientDvar(Client.ClientNum, "motionTrackerSweepSpeed \"0.01\"");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(heartbeat), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "motionTrackerSweepSpeed \"1\"");
        }
    }
}
