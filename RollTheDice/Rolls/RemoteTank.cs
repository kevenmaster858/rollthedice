using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class RemoteTank : Roll
    {
        public override string Name
        {
            get
            {
                return "Remote Tank";
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
                return "Or EOD-Bot, whatever, FUCK YOU!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void DoTank(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.TakeAll(Client);
            int l33t = Owner.GetWeapon("iw5_scar_mp");
            Client.Other.CurrentWeapon = l33t;
            Client.Other.SecondaryWeapon = l33t;
            Core.Ammoz(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"-500\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"1\"");
            Client.Other.SetPlayerModel("vehicle_ugv_talon_mp"); // vehicle_ugv_talon_obj
            Client.Other.SetPlayerHeadModel("vehicle_ugv_talon_gun_mp");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoTank, Client);
        }

        public override void onRemove(ServerClient Client)
        {

            Core.Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"0\"");
            IsThreadRunning = false;
        }
    }
}
