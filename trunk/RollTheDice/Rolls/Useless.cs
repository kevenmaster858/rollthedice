using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Useless : Roll
    {
        public override string Name
        {
            get
            {
                return "Useless";
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
                return "The 2 most useless weapons in the game";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void th(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            Core.Ammoz(Client);
            Core.TakeAll(Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("riotshield_mp");
            Client.Other.CurrentWeapon = Owner.GetWeapon("riotshield_mp");
            Client.Other.SecondaryWeapon = Owner.GetWeapon("javelin_mp");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(th), Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}
