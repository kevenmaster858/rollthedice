using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Ghost : Roll
    {
        public override string Name
        {
            get
            {
                return "Ghost";
            }
        }
        public override string Version
        {
            get
            {
                return "1.5";
            }
        }
        public override string Description
        {
            get
            {
                return "You're invisible for 20 seconds";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void DoGhost(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(2000);
            Owner.iPrintLnBold("^2Ghost ACTIVATED!", Client);
            Core.DoPhone(Client, true);
            Core.RemoveHead(Client);
            Core.RemoveModel(Client);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Core.thirdPersonCamera), new object[] { Client, this });
            int seconds = 20;
            while (seconds != 0)
            {
                seconds--;
                Owner.iPrintLnBold("You've got ^4" + seconds + " remaining!", Client);
            }

            // we're just going to assume that everyone's a sniper.
            // fuck you if you think otherwise

            Client.Other.SetPlayerHeadModel("head_ally_delta_sniper");
            if (Client.Team == Teams.Allies)
                Client.Other.SetPlayerModel("mp_body_ally_ghillie_urban_sniper");
            else
                Client.Other.SetPlayerModel("mp_body_opforce_ghillie_urban_sniper");

            Owner.iPrintLnBold("^1You're not invisible anymore!", Client);

        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoGhost, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
