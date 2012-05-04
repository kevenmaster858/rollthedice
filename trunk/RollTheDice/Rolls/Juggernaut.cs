using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Juggernaut : Roll
    {
        public override string Name
        {
            get
            {
                return "Juggernaut";
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
                return "Slow but strong";
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
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("iw5_m60jugg_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Core.Ammoz(Client);
            if (Client.Team == Teams.Allies)
                Client.Other.SetPlayerModel("mp_fullbody_ally_juggernaut");
            else
                Client.Other.SetPlayerModel("mp_fullbody_opforce_juggernaut");

            Client.Other.Health = Core.MaxHP * 2;
            old = Client.Other.SpeedScale;
            Client.Other.SpeedScale = old / 2;
            ThreadPool.QueueUserWorkItem(new WaitCallback(Core.thirdPersonCamera), new object[] { Client, this });
        }

        float old;

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doJug, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Client.Other.SpeedScale = old;
        }
    }
}

//iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
//killstreak_emp_mp