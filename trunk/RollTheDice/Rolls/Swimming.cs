using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Swimming: Roll
    {
        public override string Name
        {
            get
            {
                return "Swimming";
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
                return "";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void th(object arg)
        {
            Thread.Sleep(200);
            ServerClient Client = (ServerClient)arg;
            /*Core.setGlowTweaks(Client, "1", "0.65", "0.65", "0.45", "6.07651");
            Core.setFilmTweaks(Client, "1", "0", "0.0", "0.7 0.3 0.2", "1 0.969 0.9", "0.05", "1.1");*/
            Core.TakeAll(Client);
            Core.setFilmTweaks(Client, "1", "0", "0.7", "0.07 0.7 1.4", "1 1 1.15", "0.145338", "1.15595");
            Core.setGlowTweaks(Client, "1", "0.439157", "0", "1.5", "8.28152");
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"2\"");
            old = Client.Other.SpeedScale;
            while (IsThreadRunning)
            {
                Client.Other.SpeedScale = old / 2;
                Thread.Sleep(200);
            }
            //Owner.iPrintLnBold("Done", Client);
        }

        float old;

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(th), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Core.setGlowTweaks(Client, "0", "0.65", "0.65", "0.45", "6.07651");
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"15\"");
            Client.Other.SpeedScale = old;
            Core.setFilmTweaks(Client, "0", "0", "0.0", "0.7 0.3 0.2", "1 0.969 0.9", "0.05", "1.1");
        }
    }
}
