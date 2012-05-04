using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Seizure : Roll
    {
        public override string Name
        {
            get
            {
                return "Seizure";
            }
        }
        public override string Version
        {
            get
            {
                return "1.2";
            }
        }
        public override string Description
        {
            get
            {
                return "If you got epilepsy, and you're reading this, you're dead.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void addSeizure(ServerClient Client)
        {
        
            int rand = Core.randomFix().Next(0, 7);
            if (rand == 1)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_showFbColorDebug \"1\"");
            }
            else if(rand == 0)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_showFloatZDebug \"1\"");
            }
            else if (rand == 2)
            {
                Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"1\"");
            }
            else if (rand == 3)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_colorMap \""+Core.randomFix().Next(0, 4)+"\"");
            }
            else if(rand == 4)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"0\"");
            }
            else if (rand == 5)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_lightMap \"" + Core.randomFix().Next(0, 4) + "\"");
            }
            else if (rand == 6)
            {
                Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"1\"");
            }
        }

        void seizure(ServerClient Client)
        {
            int i = 0;
            while (i != 3)
            {
                i++;
                addSeizure(Client);
            }
        }

        void Normal(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_colorMap \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_showFloatZDebug \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_showFbColorDebug \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"0\"");
        }

        void tthread(object arg)
        {
            try
            {
                ServerClient client = (ServerClient)arg;
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    Thread.Sleep(100);
                    seizure(client);
                    Thread.Sleep(100);
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
