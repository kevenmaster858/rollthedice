using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Lag : Roll
    {
        public override string Name
        {
            get
            {
                return "Lag";
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
                return "Well... The name says it.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        

        void doLag(object arg)
        {
            try
            {
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    ServerClient client = (ServerClient)arg;
                    if (!IsThreadRunning) break;
                    Random a = new Random();
                    float x = client.OriginX;
                    float y = client.OriginY;
                    float z = client.OriginZ;
                    Thread.Sleep(a.Next(500, 3000));
                    client.OriginX = x;
                    client.OriginY = y;
                    client.OriginZ = z;
                    Core.SafeSleep(a.Next(1, 11), this);
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doLag - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doLag), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
