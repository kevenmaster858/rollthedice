using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice.Rolls
{
    class UAV : Roll
    {
        public override string Name
        {
            get
            {
                return "UAV";
            }
        }

        public override string Description
        {
            get
            {
                return "UAV all the time until you die";
            }
        }

        public override string Version
        {
            get
            {
                return "1.0";
            }
        }

        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void uav(object arg)
        {
            Addon.ServerClient player = (Addon.ServerClient)arg;
            while (IsThreadRunning)
            {
                player.Other.UAVEnabled = true;
                System.Threading.Thread.Sleep(200);
            }
            player.Other.UAVEnabled = true;
        }

        public override void onInit(Addon.ServerClient player)
        {
            ThreadHandler.AddThread(new System.Threading.WaitCallback(uav), player);
        }

        public override void onRemove(Addon.ServerClient player)
        {
            IsThreadRunning = false;
        }
    }
}
