using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class GodMode : Roll
    {
        public override string Name
        {
            get
            {
                return "Lucky Player";
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
                return "Godmode for 15 secs!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doGod(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Core.DoPhone(client, true);
            int secsleft = 16;
            while (secsleft != 0 && IsThreadRunning)
            {
                secsleft--;
                client.Other.Health = int.MaxValue;
                Owner.iPrintLnBold("^2" + secsleft + " seconds ^7left until you lose your god powers", client);
                Thread.Sleep(1000);
            }
            if (IsThreadRunning)
            {
                client.Other.Health = Core.MaxHP;
                Owner.iPrintLnBold("^1Powers worn off. :(", client);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doGod), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
