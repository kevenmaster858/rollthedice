using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Deaf : Roll
    {
        public override string Name
        {
            get
            {
                return "Deaf";
            }
        }
        public override string Version
        {
            get
            {
                return "1.1";
            }
        }
        public override string Description
        {
            get
            {
                return "No sounds";
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
            Owner.SetClientDvar(Client.ClientNum, "snd_enable2d \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "snd_enable3d \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "snd_enable2d \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "snd_enable3d \"1\"");
        }
    }
}
