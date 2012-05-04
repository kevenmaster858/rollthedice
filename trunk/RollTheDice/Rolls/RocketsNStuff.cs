using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class RocketsNStuff : Roll
    {
        public override string Name
        {
            get
            {
                return "RocketsNStuff";
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
                return "RAPE THE MAP";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void hurrdurrrrrr(object arg)
        {
            Thread.Sleep(500);
            ServerClient Client = (ServerClient)arg;
            Core.Ammoz(Client);
            css = new UnlimitedAmmo();
            css.Owner = Owner;
            css.onInit(Client);
            Core.RemoveAllBut(true, Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("rpg_mp");
            Client.Other.SecondaryWeapon = Owner.GetWeapon("xm25_mp");
            Client.Other.CurrentWeapon = Owner.GetWeapon("rpg_mp");
        }

        Roll css;
        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(hurrdurrrrrr), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            if (css != null) css.onRemove(Client);
        }
    }
}
