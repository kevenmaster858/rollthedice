using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;
using System.Collections;

namespace RollTheDice.Rolls
{
    class SantaClaus : Roll
    {
        public override string Name
        {
            get
            {
                return "^5Santaclaus";
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
                return "Freeze all people around you";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doFreeze(object arg)
        {
            ServerClient client = (ServerClient)arg;
            client.Other.FreezeControls(true);
            Thread.Sleep(1000);
            client.Other.FreezeControls(false);
            FrozenClients.Remove(client.XUID);
        }
        Hashtable FrozenClients = new Hashtable();

        void doDealer(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Owner.iPrintLnBold("^5Santaclaus ACTIVATED!", client);
            Core.DoPhone(client, true);
            while (IsThreadRunning)
            {
                foreach (ServerClient otherclient in Owner.GetClients())
                {
                    if ((Core.Difference(client.OriginY, otherclient.OriginY) <= 200) && (Core.Difference(client.OriginX, otherclient.OriginX) <= 200) && otherclient.Team == Core.CalculateOtherTeam(client))
                        //Is the client within a 200 range AND is he a enemy?
                    {
                        if (FrozenClients[otherclient.XUID] == null)
                        {
                            FrozenClients.Add(otherclient.XUID, null);
                            ThreadHandler.AddThread(new WaitCallback(doFreeze), otherclient);
                            Owner.iPrintLnBold("^2" + client.Name + " ^5FROZE YOU.", otherclient);
                            Owner.iPrintLnBold("^2You ^5froze ^2" + client.Name, client);
                        }
                    }
                }
                Core.SafeSleep(2, this);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doDealer), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
