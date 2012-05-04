using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class WorldofWax : Roll
    {
        public override string Name
        {
            get
            {
                return "World of Wax";
            }
        }
        public override string Version
        {
            get
            {
                return "1.2";
            }
        }
        public override string Description
        {
            get
            {
                return "dude wat.";
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
            System.Threading.Thread.Sleep(1000);
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"3\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"1\"");
        }
    }
}
