using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class UberHardcore : Roll
    {
        public override string Name
        {
            get
            {
                return "Uber Hardcore";
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
                return "^1Extra Hardcore ^3+ 1 HP and 1 Ammo";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void threadthread(object arg)
        {
            ServerClient client = (ServerClient)arg;
            Thread.Sleep(2000);
            Owner.SetClientDvar(client.ClientNum, "cg_draw2d \"0\"");
            client.Ammo.PrimaryAmmo = 1;
            client.Ammo.OffhandAmmo = 0;
            client.Ammo.SecondaryAmmo = 0;
            client.Ammo.SecondaryAmmoClip = 0;
            client.Ammo.EquipmentAmmo = 0;
            client.Ammo.PrimaryAmmoClip = 1;
            Core.OHKs.Add(client.XUID);
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(threadthread), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
            Owner.SetClientDvar(Client.ClientNum, "cg_draw2d \"1\"");
            Core.OHKs.Remove(Client.XUID);
        }
    }
}
