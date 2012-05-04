using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class WatchAndLearn : Roll
    {
        public override string Name
        {
            get
            {
                return "Watch and Learn";
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
                return "Spectator for 1 minute";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doUfo(object arg)
        {
            Thread.Sleep(500);
            ServerClient client = (ServerClient)arg;
            int[] weapons = Core.GetWeaponArray(client);
            Core.TakeAll(client);
            client.Other.EnableNoclip(true);
            Core.RemoveHead(client);
            Core.RemoveModel(client);
            //Core.RemoveHead(client);
            int secsleft = 61;
            while (secsleft != 0 && IsThreadRunning)
            {
                secsleft--;
                if(secsleft == 5 || secsleft == 10 || secsleft == 15 || secsleft == 20 || secsleft == 25 || secsleft == 30 || secsleft == 35 || secsleft == 40 || secsleft == 45 || secsleft == 50 || secsleft == 55 || secsleft == 60)
                    Owner.iPrintLnBold("^1" + secsleft + " seconds ^7left until you switch to normal player again", client);
                Thread.Sleep(1000);
            }
            if (IsThreadRunning)
            {
                Owner.iPrintLnBold("^2Switching back to normal player", client);
                Core.RestoreWeaponArray(client, weapons);
                client.Other.EnableNoclip(false);
                client.Other.SetPlayerModel("mp_body_russian_military_assault_a");
                client.Other.SetPlayerHeadModel("head_russian_military_aa");
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doUfo), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
