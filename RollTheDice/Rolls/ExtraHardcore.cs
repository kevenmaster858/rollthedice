using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class ExtraHardcore : Roll
    {
        public override string Name
        {
            get
            {
                return "Extra Hardcore";
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
                return "^1PR0M0D ^23SL ^31337 ^4360 ^5N0SC0P3 ^6xXx_SN1P3H4X_xXx ^3SK1LLZ";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void threadthread(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(2000);
            Owner.SetClientDvar(Client.ClientNum, "cg_draw2d \"0\"");
        }

        public override void onInit(ServerClient Client)
        {
            new Thread(threadthread).Start(Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "cg_draw2d \"1\"");
        }
    }
}
