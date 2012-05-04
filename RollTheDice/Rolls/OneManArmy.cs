using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class OneManArmy : Roll
    {
        public override string Name
        {
            get
            {
                return "One Man Army";
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
                return "Gives you a random generated class";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doOMA(object arg)
        {
            Thread.Sleep(1500);
            ServerClient Client = (ServerClient)arg;
            Core.Ammoz(Client);
            //Core.RemoveAllBut(true, Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("deployable_vest_marker_mp");
            Client.Other.CurrentWeapon = Owner.GetWeapon("deployable_vest_marker_mp");
            Owner.iPrintLnBold("^1Switching....", Client);
            if (!IsThreadRunning) return;
            Thread.Sleep(1000);
            Owner.iPrintLnBold("^2Switching....", Client);
            if (!IsThreadRunning) return;
            Thread.Sleep(1000);
            Owner.iPrintLnBold("^3Switching....", Client);
            if (!IsThreadRunning) return;
            Thread.Sleep(1000);
            Owner.iPrintLnBold("^4Switching....", Client);
            if (!IsThreadRunning) return;
            Thread.Sleep(1000);
            if (!IsThreadRunning) return; //oh dear god this + the above lines are so nooby but fuck you. i'm lazy
            //Core.RemoveAllBut(true, Client);
            int newweapon = Owner.GetWeapon(Core.RandomWeapon(Core.AllWeapons));
            Client.Other.PrimaryWeapon = newweapon;
            Client.Other.CurrentWeapon = newweapon;
            Client.Other.SecondaryWeapon = Owner.GetWeapon(Core.RandomWeapon(Core.AllWeapons));
            Client.Other.Equipment = Owner.GetWeapon(Core.getRandom(Core.AllEquipment));
            Client.Other.OffhandWeapon = Owner.GetWeapon(Core.getRandom(Core.AllOffhand));
            Client.Other.ClearPerks();
            Client.Other.SetPerk(Owner.GetPerk(Core.getRandom(Core.AllPerks)));
            int x = 0;
            while (x != 20 && IsThreadRunning)
            {
                x++;
                int B = Core.randomFix().Next(0, 3);
                string spam = "";
                switch(B)
                {
                    case 0:
                        spam = "OMA";
                        break;
                    case 1:
                        spam = "OMA OMA OMA";
                        break;
                    case 2:
                        spam = "OMA OMA";
                        break;
                }
                Owner.iPrintLnBold(Core.getRandom(Core.AllColors) + spam, Client);
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doOMA), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
