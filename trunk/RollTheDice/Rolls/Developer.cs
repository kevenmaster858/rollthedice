using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Developer : Roll
    {
        public override string Name
        {
            get
            {
                return "Developer";
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
                return "Welcome to the IW team. Bobby will be proud!";
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
            Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"1\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"0\"");
        }
    }
}
