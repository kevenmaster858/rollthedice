using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class BlackWhite : Roll
    {
        public override string Name
        {
            get
            {
                return "Black and White";
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
                return "Ah... Back in the day...";
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
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"3\"");
	        Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"1\"");
        }
    }
}
