using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Anticamp : Roll
    {
        public override string Name
        {
            get
            {
                return "Anticamp";
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
                return "This is actually how it goes on some servers";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void anticamp(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Core.DoPhone(client, true);
            int warn = 0;
            float oldX = client.OriginX;
            float oldY = client.OriginY;
            while (IsThreadRunning)
            {
                Thread.Sleep(2000);
                bool camp = false;
                if (Core.Difference(oldX, client.OriginX) <= 20 || Core.Difference(oldY, client.OriginY) <= 20) camp = true;
                Core.WriteDebug("[anticamp] diffX = " + Core.Difference(oldX, client.OriginX) + " diffY = " + Core.Difference(oldY, client.OriginY));
                if (!camp) Core.WriteDebug("[anticamp] No camp (diffs are below 20)");
                if (camp)
                {
                    Core.WriteDebug("[anticamp] CAMP DETECTED ["+warn+"/3]");
                    warn++;
                    if (warn == 4)
                    {
                        Owner.iPrintLnBold("^3Warnings exceeded! ^1DIE CAMPER!", client);
                        Core.Kill(client);
                        Core.WriteDebug("[anticamp] [end]");
                        Owner.ServerSay("^3RtD^7: ^2" + client.Name + " ^1got killed because of camping.", true);
                        break;
                    }
                    else
                    {
                        Owner.iPrintLnBold("^1Move your ass! Warning ^3"+warn+"/3", client);
                    }
                }
                oldX = client.OriginX;
                oldY = client.OriginY;
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(anticamp), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
