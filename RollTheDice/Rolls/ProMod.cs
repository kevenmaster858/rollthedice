using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class ProMod : Roll
    {
        public override string Name
        {
            get
            {
                return "ProMod";
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
                return "Because the normal game isn't hard enough";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void promod(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            css = new CSS();
            css.Owner = Owner;
            css.onInit(Client);
            Core.RemoveAllBut(true, Client);
            Core.Ammoz(Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("iw5_msr_mp_msrscopevz_camo11");
            Client.Other.CurrentWeapon = Owner.GetWeapon("iw5_msr_mp_msrscopevz_camo11");
        }

        Roll css;
        public override void onInit(ServerClient Client)
        {

            ThreadHandler.AddThread(new WaitCallback(promod), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            if(css != null) css.onRemove(Client);
        }
    }
}
