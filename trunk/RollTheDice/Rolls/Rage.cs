using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Rage : Roll
    {
        public override string Name
        {
            get
            {
                return "Rage";
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
                return "You. When you almost had a MOAB";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        public void DoRage(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            while (IsThreadRunning)
            {
                string sound = "freefall_death";

                Core.Owner.PlaySoundAtOrigin(new Addon.Vector(Client.OriginX, Client.OriginY, Client.OriginZ), sound);

                System.Threading.Thread.Sleep(Core.randomFix().Next(500, 1000));
            }

        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(DoRage, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
