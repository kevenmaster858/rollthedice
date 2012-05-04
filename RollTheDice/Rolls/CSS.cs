using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class CSS : Roll
    {
        public override string Name
        {
            get
            {
                return "Counter Strike";
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
                return "Lock'n'load";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void css(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            Thread.Sleep(500);
            Core.DoLaptop(Client, true); //lololol
            Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"3\"");
            Owner.SetClientDvar(Client.ClientNum, "r_detail \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_fog \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_specularMap 0");
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(css), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_lightmap \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_detail \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_fog \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_specularMap 1");
        }
    }
}
