using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class GlassCanon : Roll
    {
        public override string Name
        {
            get
            {
                return "Glass Canon";
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
                return "RPG with unlimited ammo, but one hit kill. Roll by Pieter";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void glass(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            Core.RemoveAllBut(true, Client);
            int WepID = Owner.GetWeapon("rpg_mp");
            Core.Ammoz(Client);
            Client.Other.PrimaryWeapon = WepID;
            Client.Other.CurrentWeapon = WepID;

        }

        public override void onInit(ServerClient Client)
        {
            Core.OHKs.Add(Client.XUID);
            ThreadHandler.AddThread(new WaitCallback(glass), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Core.OHKs.Remove(Client.XUID);
        }
    }
}
