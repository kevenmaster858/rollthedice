using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Smack : Roll
    {
        public override string Name
        {
            get
            {
                return "Smack!";
            }
        }
        public override string Version
        {
            get
            {
                return "1.7";
            }
        }
        public override string Description
        {
            get
            {
                return "Average MW3 Chaos match";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doSmack(object arg)
        {
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    ServerClient client = (ServerClient)arg;
                    Random a = new Random();
                    client.OriginZ = client.OriginZ + a.Next(25, 50);
                    Core.SafeSleep(a.Next(1,6), this);
                }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doSmack), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
