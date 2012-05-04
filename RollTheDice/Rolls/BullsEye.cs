﻿using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Bullseye : Roll
    {
        public override string Name
        {
            get
            {
                return "Bullseye";
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
                return "Only throwing knifes";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void bullseye(object arg)
        {
            System.Threading.Thread.Sleep(500);
            ServerClient Client = (ServerClient)arg;
            Core.Ammoz(Client);
            css = new UnlimitedAmmo();
            css.Owner = Owner;
            css.onInit(Client);
            Core.RemoveAllBut(true, Client);
            Client.Other.PrimaryWeapon = Owner.GetWeapon("throwingknife_mp");
            Client.Other.CurrentWeapon = Owner.GetWeapon("throwingknife_mp");
        }

        Roll css;
        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new System.Threading.WaitCallback(bullseye), Client);

        }

        public override void onRemove(ServerClient Client)
        {
            if (css != null) css.onRemove(Client);
        }
    }
}
