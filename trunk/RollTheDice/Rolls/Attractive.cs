using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Attractive : Roll
    {
        public override string Name
        {
            get
            {
                return "Attractive";
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
                return "Try to lure people to you, and then kill them!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void DoAttractive(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);

            Core.RemoveHead(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"-500\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"1\"");
            Client.Other.SetPlayerModel("com_plasticcase_friendly");                   // TO DO : REPLACE WITH REAL AIRDROP MODEL

            // mp_supplydrop_ally ??
            // mp_airdrop_ally
            // airdrop_ally ???
            // airdrop_ally_mp
            // supplydrop_ally ???????????????????????///
            
            // TEST TEST TEST
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoAttractive, Client);
        }

        public override void onRemove(ServerClient Client)
        {

            Core.Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"0\"");
            IsThreadRunning = false;
        }
    }
}
