using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class EvenMoreOverpoweredFMG : Roll
    {
        public override string Name
        {
            get
            {
                return "Even more overpowered FMG";
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
                return "You thought the FMG couldn't be more overpowered? Think again.";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        Roll css;
        void doDesignator(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.Ammoz(Client);
            css = new UnlimitedAmmo();
            css.Owner = Owner;
            css.onInit(Client);
            Core.RemoveAllBut(true, Client);
            Client.Ammo.PrimaryAmmo = 0;
            Client.Ammo.SecondaryAmmo = 0;
            Client.Ammo.SecondaryAmmoClip = 0;
            Client.Ammo.PrimaryAmmoClip = 0;
            int WepID = Owner.GetWeapon("iw5_fmg9_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            System.Threading.Thread.Sleep(200);
            WepID = Owner.GetWeapon("cobra_20mm_mp");
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;
            Client.Ammo.PrimaryAmmo = int.MaxValue;
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doDesignator, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            css.onRemove(Client);
        }
    }
}
