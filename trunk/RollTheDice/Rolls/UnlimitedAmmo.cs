using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class UnlimitedAmmo : Roll
    {
        public override string Name
        {
            get
            {
                return "Unlimited Ammo";
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
                return "QUICK, GRAB YOUR NOOB TUBE!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void doUnlimAmmo(object arg)
        {
            try
            {
                ServerClient client = (ServerClient)arg;
                int primary = client.Ammo.PrimaryAmmo;
                int primaryclip = client.Ammo.PrimaryAmmoClip;
                int secondary = client.Ammo.SecondaryAmmo;
                int secondaryclip = client.Ammo.SecondaryAmmoClip;
                int offhand = client.Ammo.OffhandAmmo;
                int equipment = client.Ammo.EquipmentAmmo;

                IsThreadRunning = true; while(IsThreadRunning)
                {
                    client.Ammo.EquipmentAmmo = equipment;
                    client.Ammo.PrimaryAmmoClip = primaryclip;
                    client.Ammo.PrimaryAmmo = primary;
                    client.Ammo.OffhandAmmo = offhand;
                    client.Ammo.SecondaryAmmo = secondary;
                    client.Ammo.SecondaryAmmoClip = secondary;

                    Thread.Sleep(200);
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doUnlimAmmo - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doUnlimAmmo), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
