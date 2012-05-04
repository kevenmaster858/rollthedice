using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Headless : Roll
    {
        public override string Name
        {
            get
            {
                return "Headless";
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

        void doHead(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.RemoveHead(Client);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Core.thirdPersonCamera), new object[] { Client, this });
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doHead, Client);
        }

        public override void onRemove(ServerClient Client)
        {
        }
    }
}

//iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
//killstreak_emp_mp