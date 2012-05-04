using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class TrueCamper : Roll
    {
        public override string Name
        {
            get
            {
                return "True Camper";
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
                return "No weapons only when camping. Idea by G-Man";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void camper(object arg)
        {
            try
            {
                ServerClient Client = (ServerClient)arg;
                Thread.Sleep(500);
                Core.TakeAll(Client);
                IsThreadRunning = true;
                Core.TakeAll(Client);
                int Sniper = Owner.GetWeapon("iw5_msr_mp_msrscopevz_camo11");
                float[] oldOrigin = { Client.OriginX, Client.OriginY, Client.OriginZ };
                while (IsThreadRunning)
                {
                    // blabla if orgin == old origin give weapon
                    // if origin != old origin take weapon
                    Core.SafeSleep(2, this);
                    if (!IsThreadRunning) break;
                    float[] currOrigin = { Client.OriginX, Client.OriginY, Client.OriginZ };
                    if (currOrigin[0] == oldOrigin[0] && currOrigin[1] == oldOrigin[1] && currOrigin[2] == oldOrigin[2])
                    { //user stood stil for 2 seconds & his weapon != the sniper
                        if (Client.Other.PrimaryWeapon != Sniper)
                        {
                            Owner.iPrintLnBold("^2Camp powers activated", Client);
                            Core.Ammoz(Client);
                            Client.Other.PrimaryWeapon = Sniper;
                            Client.Other.CurrentWeapon = Sniper;
                        }
                    }
                    else
                    {
                        if (Client.Other.CurrentWeapon == Sniper)
                        {
                            Core.TakeAll(Client);
                            Owner.iPrintLnBold("^1Camp powers deactivated. Camp again to get your weapon", Client);
                        }
                    }
                    if (Core.Debug)
                    {
                        string x = "^1CURR";
                        foreach (float a in currOrigin)
                        {
                            x += " " + a;
                        }
                        string b = "^1OLD";
                        foreach (float d in oldOrigin)
                        {
                            b += " " + d;
                        }

                        Owner.ServerPrint(b);
                        Owner.ServerPrint(x);
                    }

                    oldOrigin = new float[] { Client.OriginX, Client.OriginY, Client.OriginZ };
                }
            }
            catch (Exception z)
            {
                Owner.ServerPrint(z.ToString());
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(camper), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
