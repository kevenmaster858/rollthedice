using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Terrorist : Roll
    {
        public override string Name
        {
            get
            {
                return "Terrorist";
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
                return "You're literary a walking time bomb";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        public void DoOrgasm(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            while (IsThreadRunning)
            {
                string sound = "";
                switch (new System.Random().Next(0, 3))
                {
                    case 0:
                        sound = "ui_mp_suitcasebomb_timer";
                        break;
                    case 1:
                        sound = "missile_locking";
                        break;
                    case 2:
                        sound = "mp_killconfirm_tags_deny";
                        break;
                    case 3:
                        sound = "mp_killconfirm_tags_pickup";
                        break;
                    case 4:
                        sound = "mp_killstreak_radar";
                        break;
                    case 5:
                        sound = "ims_plant";
                        break;
                    case 6:
                        sound = "scrambler_beep";
                        break;
                    case 7:
                        sound = "sentry_gun_beep";
                        break;
                }


                Core.Owner.PlaySoundAtOrigin(new Addon.Vector(Client.OriginX, Client.OriginY, Client.OriginZ), sound);

                System.Threading.Thread.Sleep(Core.randomFix().Next(500, 1000));
            }

        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoOrgasm, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
