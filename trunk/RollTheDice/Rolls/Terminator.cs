using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Terminator : Roll
    {
        public override string Name
        {
            get
            {
                return "Terminator";
            }
        }

        public override string Description
        {
            get
            {
                return "You're a cyborg";
            }
        }

        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void sarah(object arg)
        {
            ServerClient player = (ServerClient)arg;
            System.Threading.Thread.Sleep(200);
            Core.TakeAll(player);
            int WepID = Owner.GetWeapon("uav_strike_marker_mp");
            player.Other.PrimaryWeapon = WepID;
            player.Other.CurrentWeapon = WepID;
            System.Threading.Thread.Sleep(200);
            WepID = Owner.GetWeapon("cobra_20mm_mp");
            player.Other.PrimaryWeapon = WepID;
            player.Other.CurrentWeapon = WepID;
            player.Ammo.PrimaryAmmo = int.MaxValue;

            //Core.setFilmTweaks(player, "1", "1", "0", "0", "0", "0", "0");
            player.Other.EnableNightvision(true);

            player.Other.Health = 200;

            float old = player.Other.SpeedScale;
            while (IsThreadRunning)
            {
                player.Other.SpeedScale = old / 2;
                System.Threading.Thread.Sleep(200);
            }
            player.Other.EnableNightvision(true);
            player.Other.EnableNightvision(false);
            
        }

        public override void onInit(Addon.ServerClient player)
        {
            ThreadHandler.AddThread(new System.Threading.WaitCallback(sarah), player);
        }

        public override void onRemove(ServerClient player)
        {
            IsThreadRunning = false;
            //Core.setFilmTweaks(player, "0", "0", "0", "0", "0", "0", "0");
        }
    }
}
