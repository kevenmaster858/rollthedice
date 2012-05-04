using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class SuperDamage : Roll
    {
        public override string Name
        {
            get
            {
                return "Super Damage";
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
                return "Everyone becomes a one hit kill for you";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public override void onInit(ServerClient Client)
        {
            Core.SDs.Add(Client.XUID);
        }

        public override void onRemove(ServerClient Client)
        {
            try
            {
                Core.SDs.Remove(Client.XUID);
            }
            catch
            {

            }
        }
    }
}
