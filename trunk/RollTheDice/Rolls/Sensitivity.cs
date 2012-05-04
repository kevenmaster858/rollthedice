using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Sensitivity : Roll
    {
        public override string Name
        {
            get
            {
                return "High Sensitivity";
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
                return "Unleash your true 1337 inner self";
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
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"100\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_allow_controlschange \"0\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"15\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_allow_controlschange \"1\"");
        }
    }
}
