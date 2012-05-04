using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class GETTUDACHOPAAA : Roll
    {
        public override string Name
        {
            get
            {
                return "GET TU DA CHOPPA";
            }
        }
        public override string Version
        {
            get
            {
                return "1.5";
            }
        }
        public override string Description
        {
            get
            {
                return "";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public void DoCHOPPAAAA(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            Core.RemoveHead(Client);

            string model = "";
            switch (new System.Random().Next(0, 5))
            {
                case 0:
                    model = "vehicle_mi24p_hind_mp";
                    break;
                case 1:
                    model = "vehicle_cobra_helicopter_fly_low";
                    break;
                /*case 2:
                    model = "vehicle_little_bird_armed_mp";
                    break;*/
                case 2:
                    model = "vehicle_apache_mp";
                    break;
                case 3:
                    model = "vehicle_pavelow";
                    break;
                case 4:
                    model = "vehicle_pavelow_opfor";
                    break;
            }
            Core.WriteDebug("---- CHOPPER ROLLED: " + model + " ------");
            Core.TakeAll(Client);
            Client.Other.SetPlayerModel(model);
            Client.Other.EnableNoclip(true);
            
            //Client.Other.PrimaryWeapon = Owner.GetWeapon("cobra_20mm_mp");
            //Client.Ammo.PrimaryAmmo = int.MaxValue; //unlim. ammo the cheap way
            Core.Owner.SetClientDvar(Client.ClientNum, "camera_thirdperson \"1\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "camera_thirdpersonoffset \"-800\"");
            Client.OriginZ += 500; // UP THE AIR!

            while (IsThreadRunning)
            {
                Owner.PlaySoundAtOrigin(new Vector(Client.OriginX, Client.OriginY, Client.OriginZ), "littlebird_move");
                System.Threading.Thread.Sleep(1000);
            }

        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoCHOPPAAAA, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Client.Other.EnableNoclip(false);
            Core.Owner.SetClientDvar(Client.ClientNum, "camera_thirdperson \"0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "camera_thirdpersonoffset \"-300\"");
            IsThreadRunning = false;
        }
    }
}
