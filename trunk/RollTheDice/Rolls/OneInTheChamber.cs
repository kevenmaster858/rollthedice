using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class OneInTheChamber : Roll
    {
        public override string Name
        {
            get
            {
                return "One In The Chamber";
            }
        }
        public override string Version
        {
            get
            {
                return "1.3";
            }
        }
        public override string Description
        {
            get
            {
                return "For each kill you make, you get a bullet.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        int kills = 0;
        void doOneInTheChamber(object arg)
        {
                ServerClient client = (ServerClient)arg;
                Thread.Sleep(500);
                //Thread.Sleep(2000); //let user read the description first before showing 2nd hint
                //Owner.iPrintLnBold("^1SWITCH TO YOUR SECONDARY WEAPON!", client);
                client.Ammo.PrimaryAmmo = 3;
                Core.RemoveAllBut(true, client);
                client.Other.PrimaryWeapon = Owner.GetWeapon("iw5_44magnum_mp");
                client.Other.CurrentWeapon = Owner.GetWeapon("iw5_44magnum_mp");
                kills = client.Stats.Kills;
                bool r = false;
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    if (r != false)
                    {
                        if (client.Stats.Kills > kills) // User has more kills then last time
                        {
                            Owner.iPrintLnBold("^2YOU EARNED 2 BULLETS!", client);
                            client.Ammo.PrimaryAmmo = client.Ammo.PrimaryAmmo + 2;
                        }
                    }
                    else
                    {
                        r = true;
                    }
                    /*if (client.Ammo.SecondaryAmmoClip != 0) client.Ammo.SecondaryAmmoClip = 0;
                    if (client.Ammo.PrimaryAmmo != 0) client.Ammo.PrimaryAmmo = 0;
                    if (client.Ammo.PrimaryAmmoClip != 0) client.Ammo.PrimaryAmmoClip = 0;
                    if (client.Ammo.OffhandAmmo != 0) client.Ammo.OffhandAmmo = 0;
                    if (client.Ammo.EquipmentAmmo != 0) client.Ammo.EquipmentAmmo = 0;*/
                    kills = client.Stats.Kills;
                    Thread.Sleep(200);
                }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doOneInTheChamber), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
