using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class OPAGun : Roll
    {
        public override string Name
        {
            get
            {
                return "OPA Gun";
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
                return "Eat OPA, Bitch!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doOPA(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"0\"");
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("deployable_vest_marker_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            System.Threading.Thread.Sleep(500);
            WepID = Owner.GetWeapon("iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"1\"");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doOPA, Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}

//iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
//killstreak_emp_mp