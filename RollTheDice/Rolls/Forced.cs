using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Forced : Roll
    {
        public override string Name
        {
            get
            {
                return "Forced";
            }
        }
        public override string Version
        {
            get
            {
                return "2.0";
            }
        }
        public override string Description
        {
            get
            {
                return "Good luck trying to make kills :D";
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
            Owner.SetClientDvar(Client.ClientNum, "cl_freelook \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "m_yaw \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "cl_freelook \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "m_yaw \"0.022\"");
        }
    }
}
