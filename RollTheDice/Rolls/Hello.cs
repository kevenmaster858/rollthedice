using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Hello : Roll
    {
        public override string Name
        {
            get
            {
                return "HELLO";
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
                return "YES, THIS IS DOG";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doDog(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.Ammoz(Client);
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("killstreak_emp_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"0\"");
            System.Threading.Thread.Sleep(500);
            WepID = Owner.GetWeapon("iw5_g18_mp_shotgun_zoomscope_camo10_scope5");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"0\"");
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"1\"");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doDog, Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}

    //iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
    //killstreak_emp_mp