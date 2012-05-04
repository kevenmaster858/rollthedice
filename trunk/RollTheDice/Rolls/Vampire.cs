using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Vampire : Roll
    {
        public override string Name
        {
            get
            {
                return "Vampire";
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
                return "Kill other players to keep your health up high";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doVampire(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Core.DoPhone(client, true);
            int ind = 0;
            int kills = client.Stats.Kills;
            int hp = client.Other.Health;
            bool notified = false;
            while (IsThreadRunning)
            {
                ind++;
                if (ind == 5) // 1 second
                {
                    ind = 0;
                    if (hp <= 2 && !notified)
                    {
                        notified = true;
                        Owner.iPrintLnBold("--- ^1YOU'VE BECOME A ONE-HIT-KILL ^7---", client);
                    }
                    else
                    {
                        hp = hp - 2;
                        client.Other.Health = hp;
                        Owner.iPrintLnBold(string.Format("^1You've got ^2{0} ^1health remaining", hp), client);
                    }
                }

                if (client.Stats.Kills > kills) client.Other.Health = client.Other.Health + 50;
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doVampire), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
