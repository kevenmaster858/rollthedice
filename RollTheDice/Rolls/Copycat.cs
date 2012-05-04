using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class CopyCat : Roll
    {
        public override string Name
        {
            get
            {
                return "Copycat";
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
                return "You steal other people's classes";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doCopy(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Owner.iPrintLnBold("^2Copycat ACTIVATED!", client);
            Core.DoPhone(client, true);
            while (IsThreadRunning)
            {
                foreach (ServerClient otherclient in Owner.GetClients())
                {
                    if ((Core.Difference(client.OriginY, otherclient.OriginY) <= 200) && (Core.Difference(client.OriginX, otherclient.OriginX) <= 200) && otherclient.Team == Core.CalculateOtherTeam(client))
                    {
                        int r = -1;
                        int[] myweapons = Core.GetWeaponArray(client);
                        bool same = true;
                        foreach (int x in Core.GetWeaponArray(otherclient))
                        {
                            r++;
                            if (myweapons[r] != x) same = false;
                        }
                        if (!same)
                        {
                            Core.RestoreWeaponArray(client, Core.GetWeaponArray(otherclient));
                            Owner.iPrintLnBold("^7You copied ^1"+otherclient.Name +"'s ^7class!", client);
                            Owner.iPrintLnBold("^1" + client.Name + " ^7copied your class!", otherclient);
                        }
                    }
                }
                Core.SafeSleep(2, this);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doCopy), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
