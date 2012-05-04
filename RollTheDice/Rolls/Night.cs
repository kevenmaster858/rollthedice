using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Night : Roll
    {
        public override string Name
        {
            get
            {
                return "Night";
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
                return "Pure Darkness.... MUHAHAHAHHAHAHA!";
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
            Owner.SetClientDvar(Client.ClientNum, "r_singleCell \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_singleCell \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"1\"");
        }
    }
}
