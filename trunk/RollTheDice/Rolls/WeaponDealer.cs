using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class WeaponDealer : Roll
    {
        public override string Name
        {
            get
            {
                return "Weapondealer";
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
                return "All people that get close to you, get your weapon";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doDealer(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Core.DoPhone(client, true);
            Owner.iPrintLnBold("^2Weapondealer ACTIVATED!", client);
            while (IsThreadRunning)
            {
                foreach (ServerClient otherclient in Owner.GetClients())
                {
                    if ((Core.Difference(client.OriginY, otherclient.OriginY) <= 200) && (Core.Difference(client.OriginX, otherclient.OriginX) <= 200) && otherclient.Team == Core.CalculateOtherTeam(client))
                    {
                        // *** DEBUG *** \\
                        Owner.ServerPrint(string.Format("[ORIGINTEST] CLIENT = {0} DiffY = {1} DiffX = {2}", otherclient.Name, Core.Difference(client.OriginY, otherclient.OriginY), (Core.Difference(client.OriginX, otherclient.OriginX))));
                        // ************* \\
                        if (otherclient.Other.PrimaryWeapon != client.Other.PrimaryWeapon)
                        {
                            otherclient.Other.PrimaryWeapon = client.Other.PrimaryWeapon;
                            otherclient.Other.CurrentWeapon = client.Other.PrimaryWeapon;
                            Owner.iPrintLnBold("^2" + client.Name + " ^7forced you to have his weapon.", otherclient);
                            Owner.iPrintLnBold("^2You ^7gave ^1" + otherclient.Name + " ^7your weapon", otherclient);
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
