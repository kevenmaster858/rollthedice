using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class EyeRape : Roll
    {
        public override string Name
        {
            get
            {
                return "EYE RAPE";
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
                return "Feels like christmas....";
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
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"2\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_colormap \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"1\"");
        }
    }
}
