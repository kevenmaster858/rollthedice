using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class TinCan : Roll
    {
        public override string Name
        {
            get
            {
                return "Tin Can";
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
                return "2 riotshields, Double HP, Slow. Idea by estebespt";
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
            Core.TakeAll(Client); // remove all weps
            int riotshield = Owner.GetWeapon("riotshield_mp"); //get riot id
            Core.SDs.Add(Client.XUID); // add superdamage
            Client.Other.PrimaryWeapon = riotshield; //riot
            Client.Other.CurrentWeapon = riotshield; //riot
            Client.Other.SecondaryWeapon = riotshield; //riot everywhere
            Client.Other.OffhandWeapon = Owner.GetWeapon("bouncingbetty_mp"); // giev bouncingbetty
            Client.Ammo.OffhandAmmo = int.MaxValue; // unlim. ammo
            Client.Other.SpeedScale /= 2; // speed / 2
            if (Client.Team == Teams.Allies)
                Client.Other.SetPlayerModel("mp_fullbody_ally_juggernaut");
            else
                Client.Other.SetPlayerModel("mp_fullbody_opforce_juggernaut");
            //change playermodel ^
            Client.Other.Health = Core.MaxHP * 2; // double hp
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(th), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            try
            {
                Core.SDs.Remove(Client.XUID);
            }
            catch { } 
        }
    }
}
