//fuck this roll


/*using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class EMPGrenade : Roll
    {
        public override string Name
        {
            get
            {
                return "EMP Grenade";
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
                return "Useless roll number 2";
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
                client.Other.Equipment = Owner.GetWeapon(Core.AllEquipment[3]);
                IsThreadRunning = true; while (IsThreadRunning)
                {
                    if (client.Ammo.OffhandAmmo != 0) client.Ammo.OffhandAmmo = 0;
                    if (client.Ammo.PrimaryAmmo != 0) client.Ammo.PrimaryAmmo = 0;
                    if (client.Ammo.PrimaryAmmoClip != 0) client.Ammo.PrimaryAmmoClip = 0;
                    if (client.Ammo.SecondaryAmmo != 0) client.Ammo.SecondaryAmmo = 0;
                    if (client.Ammo.SecondaryAmmoClip != 0) client.Ammo.SecondaryAmmoClip = 0;
                    if (client.Ammo.EquipmentAmmo != 5) client.Ammo.EquipmentAmmo = 5;
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
*/