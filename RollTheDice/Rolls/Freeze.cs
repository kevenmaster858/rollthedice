using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Freeze : Roll
    {
        public override string Name
        {
            get
            {
                return "Freeze";
            }
        }
        public override string Version
        {
            get
            {
                return "2.0";
            }
        }
        public override string Description
        {
            get
            {
                return "You can't move at random moments";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doFreeze(object arg)
        {
            try
            {
                IsThreadRunning = true; while(IsThreadRunning)
                {

                    Random a = new Random();
                    Core.SafeSleep(a.Next(1, 4), this);
                    ServerClient client = (ServerClient)arg;
                    Owner.iPrintLnBold("^3STOP. ^5HAMMERTIME!", client);
                        client.Other.FreezeControls(true);
                        Core.SafeSleep(Core.randomFix().Next(1,3), this);
                    Owner.iPrintLnBold("^3Freeze deactivated", client);
                    client.Other.FreezeControls(false);
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doFreeze - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doFreeze), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
            //just to be sure
            Client.Other.FreezeControls(false);
        }
    }
}
