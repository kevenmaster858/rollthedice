using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Kamikaze : Roll
    {
        public override string Name
        {
            get
            {
                return "KAMIKAZAAAAH";
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
                return "You will die in 30 seconds. Enemies in close range will also die";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doKamikaze(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Owner.iPrintLnBold("^1KAMIKAZAAAH Activated!", client);
            Core.DoPhone(client, true);
            int secsleft = 16;
            while (secsleft != 0 && IsThreadRunning)
            {
                secsleft--;
                //client.Other.Health = int.MaxValue;
                Owner.iPrintLnBold("^1" + secsleft + " seconds ^7left until you ^1DIE", client);
                Thread.Sleep(1000);
            }
            if (IsThreadRunning)
            {
                Core.Kill(client);
                Core.RangeKill(client, "^3RtD^7: ^1{0} ^7was kamikaze'd by ^1{1}");
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doKamikaze), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
