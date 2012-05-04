using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Annoying : Roll
    {
        public override string Name
        {
            get
            {
                return "Annoying";
            }
        }
        public override string Version
        {
            get
            {
                return "1.5";
            }
        }
        public override string Description
        {
            get
            {
                return "OH GOD IT'S SO BIG - That's what she said";
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
            Owner.SetClientDvar(Client.ClientNum, "compassSize \"6\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "compassSize \"1\"");
        }
    }
}
