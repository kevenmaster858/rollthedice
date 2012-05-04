using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Sphere : Roll
    {
        public override string Name
        {
            get
            {
                return "DISCO FEVER";
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
                return "You're a walking discoball";
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
            System.Threading.Thread.Sleep(500);
            /*while (IsThreadRunning)
            {*/

                //Core.Owner.PlaySoundAtOrigin(new Addon.Vector(Client.OriginX, Client.OriginY, Client.OriginZ), "generic_death_american_" + new System.Random().Next(0, 8));
            Core.RemoveHead(Client);
            Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"-500\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"1\"");

            bool silver = false;
            while (IsThreadRunning)
            {
                if (!silver)
                {
                    silver = true;
                    Client.Other.SetPlayerModel("test_sphere_silver");
                }
                else
                {
                    silver = false;
                    Client.Other.SetPlayerModel("test_sphere_redchrome");
                }
                System.Threading.Thread.Sleep(500);
                
            }
                /*System.Threading.Thread.Sleep(Core.randomFix().Next(500, 1000));
            }*/

        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoOrgasm, Client);
        }

        public override void onRemove(ServerClient Client)
        {

            Core.Owner.SetClientDvar(Client.ClientNum, "cg_gun_x \"0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cg_thirdperson \"0\"");
            IsThreadRunning = false;
        }
    }
}
