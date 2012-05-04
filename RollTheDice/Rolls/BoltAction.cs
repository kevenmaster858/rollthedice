using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class BoltAction : Roll
    {
        public override string Name
        {
            get
            {
                return "Bolt Action";
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
                return "Your primary weapon only has 1 bullet.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doBolt(object arg)
        {
                ServerClient client = (ServerClient)arg;
                Thread.Sleep(500);
                Core.RemoveAllBut(true, client);
                client.Other.PrimaryWeapon = Owner.GetWeapon("iw5_mk14_mp");
                client.Other.CurrentWeapon = Owner.GetWeapon("iw5_mk14_mp");
                
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    
                    if(client.Ammo.PrimaryAmmo > 1) client.Ammo.PrimaryAmmo = 0;
                    if (client.Ammo.PrimaryAmmoClip > 1) client.Ammo.PrimaryAmmoClip = 0;
                    if(client.Ammo.PrimaryAmmo == 0 && client.Ammo.PrimaryAmmoClip == 0) client.Ammo.PrimaryAmmoClip = 1;
                    Thread.Sleep(200);
                }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doBolt), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
