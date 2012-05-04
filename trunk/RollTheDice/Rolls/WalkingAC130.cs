using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class WalkingAC130 : Roll
    {
        public override string Name
        {
            get
            {
                return "Walking AC130";
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

        void ac130(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Core.DoLaptop(Client, true);
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("ac130_105mm_mp");
            Core.Ammoz(Client);
            while (IsThreadRunning)
            {
                Client.Ammo.PrimaryAmmo = 999;
                Client.Other.PrimaryWeapon = WepID;
                Client.Other.CurrentWeapon = WepID;
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(ac130), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
