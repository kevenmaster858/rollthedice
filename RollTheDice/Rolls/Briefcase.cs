using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Briefcase : Roll
    {
        public override string Name
        {
            get
            {
                return "Briefcase";
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
                return "War? What war? I'm way to busy with my briefcase!";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void briefcase(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            Core.RemoveAllBut(true, Client);
            while (IsThreadRunning)
            {
                Client.Other.PrimaryWeapon = Owner.GetWeapon("briefcase_bomb_mp");
                Client.Other.CurrentWeapon = Owner.GetWeapon("briefcase_bomb_mp");
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(briefcase), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
