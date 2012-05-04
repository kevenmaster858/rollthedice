using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class ChuckNorris : Roll
    {
        public override string Name
        {
            get
            {
                return "Chuck Norris";
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
                return "Chuck Norris doesn't need a single roll. Chuck Norris has all rolls.";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doChuck(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Owner.iPrintLnBold("^5Chuck Norris ACTIVATED!", client);
            Core.DoPhone(client, true);
            Roll cur;
            while (IsThreadRunning)
            {
                List<Roll> GoodRolls = new List<Roll>();
                foreach (Roll a in RollManager.Rolls)
                {
                    if (a.Good) GoodRolls.Add(a);
                }

                cur = GoodRolls[Core.randomFix().Next(0, GoodRolls.Count)];
                Owner.iPrintLnBold("^7Your ^2CHUCK NORRIS ^7powers provided you with ^2" + cur.Name, client);
                cur.Owner = Owner;
                cur.onInit(client);
                Core.SafeSleep(30, this);
                cur.onRemove(client);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doChuck), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
