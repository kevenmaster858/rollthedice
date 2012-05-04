using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Orgasm : Roll
    {
        public override string Name
        {
            get
            {
                return "^6Orgasm";
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
                return "Guess war sometimes get a little bit to exciting";
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

                Core.Owner.PlaySoundAtOrigin(new Addon.Vector(Client.OriginX, Client.OriginY, Client.OriginZ), "generic_death_american_" + new System.Random().Next(0, 8));

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
