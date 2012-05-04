using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class JamesBond : Roll
    {
        public override string Name
        {
            get
            {
                return "Bond. James Bond";
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
                return true;
            }
        }

        void ac130(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            //Core.DoLaptop(Client, true);
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("iw5_usp45_mp_silencer02");
            Core.Ammoz(Client);
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(ac130), Client);
        }

        public override void onRemove(ServerClient Client)
        {

        }
    }
}
