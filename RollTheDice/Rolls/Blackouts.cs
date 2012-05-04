using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Blackouts : Roll
    {
        public override string Name
        {
            get
            {
                return "Blackouts";
            }
        }
        public override string Version
        {
            get
            {
                return "2.2";
            }
        }
        public override string Description
        {
            get
            {
                return "You loose control every 10 seconds";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void White(ServerClient Client)
        {
            Owner.iPrintLnBold("^7BLACKOUT!", Client);
            /*Owner.SetClientDvar(Client.ClientNum, "r_filmtweakenable \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmUseTweaks \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakcontrast \"1.2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakbrightness \"2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdesaturation \"0.3\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweaklighttint \"2 2 2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdarktint \"0.6 0.7 0.9\"");*/
            Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"0\"");
        }

        void Normal(ServerClient Client)
        {
            /*Owner.SetClientDvar(Client.ClientNum, "r_filmUseTweaks \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakenable \"0\"");*/
            Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"1\"");
        }

        void tthread(object arg)
        {
            try
            {
                ServerClient client = (ServerClient)arg;
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    Core.SafeSleep(10, this);
                    White(client);
                    Core.SafeSleep(Core.randomFix().Next(1, 6), this);
                    Normal(client);
                }
            }
            catch (ThreadAbortException) { }
        }


        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(tthread), Client);
        }
        
        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
