using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Drunk : Roll
    {
        public override string Name
        {
            get
            {
                return "Drunk";
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
                return "VADOAWKD AOWKD AWDAWD AWODAWDAW DOK VODKA.";
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
            Owner.SetClientDvar(Client.ClientNum, "r_blur \"3\"");
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"2\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_allow_controlschange \"0\""); //problem? :D
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_blur \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "sensitivity \"15\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_allow_controlschange \"1\"");
        }
    }
}
