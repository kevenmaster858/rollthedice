using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class OneHitKill : Roll
    {
        public override string Name
        {
            get
            {
                return "One Hit Kill";
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
                return "When someone shoots, you instantly die";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        public override void onInit(ServerClient Client)
        {
            Core.OHKs.Add(Client.XUID);
        }

        public override void onRemove(ServerClient Client)
        {
            try
            {
                Core.OHKs.Remove(Client.XUID);
            }
            catch
            {

            }
        }
    }
}
