using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Wallhack : Roll
    {
        public override string Name
        {
            get
            {
                return "Wallhack";
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
                return "Look trough walls :O";
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
            Owner.iPrintLnBold("^2Wallhack ACTIVATED!", Client);
            Core.DoPhone(Client, true);
            Owner.SetClientDvar(Client.ClientNum, "r_drawDecals \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_drawDecals \"1\"");
        }
    }
}
