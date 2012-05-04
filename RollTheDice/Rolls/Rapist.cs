using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Rapist : Roll
    {
        public override string Name
        {
            get
            {
                return "Rapist";
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
                return "All people who get close to you loose health, however, you've got no weapons";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doRape(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Owner.iPrintLnBold("^2Rapist ACTIVATED!", client);
            Core.DoPhone(client, true);
            Core.TakeAll(client);
            while (IsThreadRunning)
            {
                foreach (ServerClient otherclient in Owner.GetClients())
                {
                    if ((Core.Difference(client.OriginY, otherclient.OriginY) <= 200) && (Core.Difference(client.OriginX, otherclient.OriginX) <= 200) && otherclient.Team == Core.CalculateOtherTeam(client))
                    {
                        int removehp = 20;
                        if (otherclient.Other.Health <= 20)
                        {
                            removehp = 0;
                        }
                        Owner.iPrintLnBold("^3" + client.Name + " ^1removed " + removehp + " HP from you!", otherclient);
                        Owner.iPrintLnBold("^2You took away ^1" + removehp + " HP^2 from " + otherclient.Name + "!", client);
                        otherclient.Other.Health = otherclient.Other.Health - removehp;
                    }
                }

                Core.SafeSleep(2, this);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doRape), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
