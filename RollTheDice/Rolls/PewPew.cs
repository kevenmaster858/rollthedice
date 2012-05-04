using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class PewPew : Roll
    {
        public override string Name
        {
            get
            {
                return "Zombie";
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
                return "BRAINZZZZZ";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void pewpew(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            Core.RemoveAllBut(true, Client);
            Core.Ammoz(Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("defaultweapon_mp");
            Client.Other.CurrentWeapon = Owner.GetWeapon("defaultweapon_mp");
        }

        public override void onInit(ServerClient Client)
        {
            Core.setGlowTweaks(Client, "1", "0.65", "0.65", "0.45", "6.07651");
            Core.setFilmTweaks(Client, "1", "0", "0.0", "0.7 0.3 0.2", "1 0.969 0.9", "0.05", "1.1");
            ThreadHandler.AddThread(new WaitCallback(pewpew), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Core.setGlowTweaks(Client, "0", "0.65", "0.65", "0.45", "6.07651");
            Core.setFilmTweaks(Client, "0", "0", "0.0", "0.7 0.3 0.2", "1 0.969 0.9", "0.05", "1.1");
        }
    }
}
