using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Flashing : Roll
    {
        public override string Name
        {
            get
            {
                return "Flashing";
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
                return "WHAT ARE YOU?!";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doFlash(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Client.Other.SetPlayerHeadModel("sentry_minigun_weak_obj"); // mp_remote_turret_placement maybe ???
            ThreadPool.QueueUserWorkItem(new WaitCallback(Core.thirdPersonCamera), new object[] { Client, this });
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doFlash, Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}