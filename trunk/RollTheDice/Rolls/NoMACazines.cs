using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class NoMACazines : Roll
    {
        public override string Name
        {
            get
            {
                return "No MACazines";
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
                return false;
            }
        }

        void thread(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Client.Ammo.PrimaryAmmoClip = 0;
            Client.Ammo.SecondaryAmmoClip = 0;
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new System.Threading.WaitCallback(thread), Client);
        }

        public override void onRemove(ServerClient Client)
        {

        }
    }
}
