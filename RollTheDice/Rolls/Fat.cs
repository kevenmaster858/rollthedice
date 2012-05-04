using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Fat : Roll
    {
        public override string Name
        {
            get
            {
                return "Fat";
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
                return "You're fat.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }
        public override void onInit(ServerClient client)
        {
            Owner.SetClientDvar(client.ClientNum, "cg_fov \"90\"");
            Owner.SetClientDvar(client.ClientNum, "cg_fovscale \"1.8\"");
        }

        public override void onRemove(ServerClient client)
        {
            Owner.SetClientDvar(client.ClientNum, "cg_fovscale \"1\"");
            Owner.SetClientDvar(client.ClientNum, "cg_fov \"65\"");
        }
    }
}
