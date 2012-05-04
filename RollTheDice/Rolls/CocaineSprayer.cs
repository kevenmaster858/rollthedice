using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class CocaineSprayer : Roll
    {
        public override string Name
        {
            get
            {
                return "Go get 'em Makarov";
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
                return "ITOTALLYPWNEDTHATGUYARETHEREANYOTHERGUYSINEEDTOPWN";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        float old;

        void spray(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Core.DoLaptop(Client, true);
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("iw5_pecheneg_mp_heartbeat_xmags_camo11"); // i don't even
            Core.Ammoz(Client);

            old = Client.Other.SpeedScale;
            while (IsThreadRunning)
            {

                Client.Other.SpeedScale = 4.0f;
                Client.Ammo.PrimaryAmmo = 999;
                Client.Other.PrimaryWeapon = WepID;
                Client.Other.CurrentWeapon = WepID;
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(spray), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;

            Client.Other.SpeedScale = old;
        }
    }
}
