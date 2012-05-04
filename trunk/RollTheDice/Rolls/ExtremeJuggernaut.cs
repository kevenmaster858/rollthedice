using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class ExtremeJuggernaut : Roll
    {
        public override string Name
        {
            get
            {
                return "Extreme Juggernaut";
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
                return "Two handed weapons are for pussies";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doJug(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"0\"");
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("iw5_m60jugg_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            System.Threading.Thread.Sleep(500);
            WepID = Owner.GetWeapon("iw5_g18_mp_shotgun_zoomscope_camo10_scope5");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            if (Client.Team == Teams.Allies)
                Client.Other.SetPlayerModel("mp_fullbody_ally_juggernaut");
            else
                Client.Other.SetPlayerModel("mp_fullbody_opforce_juggernaut");
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_drawgun \"1\"");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doJug, Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}

//iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
//killstreak_emp_mp