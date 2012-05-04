using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Grenade : Roll
    {
        public override string Name
        {
            get
            {
                return "Master Cook";
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
                return "Unlimited Grenades!";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void doGrenade(object arg)
        {
            try
            {
                ServerClient client = (ServerClient)arg;
                Core.TakeAll(client);
                client.Other.OffhandWeapon = Owner.GetWeapon(Core.AllOffhand[0]);
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    if (client.Ammo.OffhandAmmo != 5) client.Ammo.OffhandAmmo = 5;
                    if (client.Ammo.PrimaryAmmo != 0) client.Ammo.PrimaryAmmo = 0;
                    if (client.Ammo.PrimaryAmmoClip != 0) client.Ammo.PrimaryAmmoClip = 0;
                    if (client.Ammo.SecondaryAmmo != 0) client.Ammo.SecondaryAmmo = 0;
                    if (client.Ammo.SecondaryAmmoClip != 0) client.Ammo.SecondaryAmmoClip = 0;
                    if (client.Ammo.EquipmentAmmo != 0) client.Ammo.EquipmentAmmo = 0;
                    Thread.Sleep(200);
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doGrenade - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doGrenade), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
