using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Sharpshooter : Roll
    {
        public override string Name
        {
            get
            {
                return "Sharpshooter";
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
                return "!!!!!OPA¡¡¡¡¡¡¡";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doSharpShooter(object arg)
        {
            Thread.Sleep(500);
            ServerClient Client = (ServerClient)arg;
            Core.Ammoz(Client);
            IsThreadRunning = true;
            while (IsThreadRunning)
            {
                Core.RemoveAllBut(true, Client);
                Client.Other.PrimaryWeapon = Owner.GetWeapon("deployable_vest_marker_mp");
                Client.Other.CurrentWeapon = Owner.GetWeapon("deployable_vest_marker_mp");
                Owner.iPrintLnBold("^2Switching....", Client);
                Thread.Sleep(1000);
                Core.RemoveAllBut(true, Client);
                int newweapon = Owner.GetWeapon(Core.RandomWeapon(Core.AllWeapons));
                Client.Other.PrimaryWeapon = newweapon;
                Client.Other.CurrentWeapon = newweapon;
                Client.Other.ClearPerks();
                Client.Other.SetPerk(Owner.GetPerk(Core.getRandom(Core.AllPerks)));
                Core.Ammoz(Client);
                Owner.iPrintLnBold("^1Done!", Client);
                Core.SafeSleep(10, this);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doSharpShooter), Client);

        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
