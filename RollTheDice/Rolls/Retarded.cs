using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Retarded : Roll
    {
        public override string Name
        {
            get
            {
                return "Retarded";
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
                return "You're retarded. Idea by Yamato";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        void setGun(int x, int y, int z, ServerClient client)
        {
            Owner.SetClientDvar(client.ClientNum, "cg_gun_x \"" + x + "\"");
            Owner.SetClientDvar(client.ClientNum, "cg_gun_y \"" + x + "\"");
            Owner.SetClientDvar(client.ClientNum, "cg_gun_z \"" + x + "\"");
        }

        void doRetarded(object arg)
        {
            
            ServerClient client = (ServerClient)arg;
            IsThreadRunning = true; while (IsThreadRunning)
            {
                setGun(1, 1, 0, client);
                Thread.Sleep(200);
                setGun(2, 2, 0, client);
                Thread.Sleep(200);
                setGun(1, 1, 0, client);
                Thread.Sleep(200);
                setGun(1, 1, 0, client);
                Thread.Sleep(200);
                setGun(-1, -1, 0, client);
                Thread.Sleep(200);
                setGun(-2, -2, 0, client);
                Thread.Sleep(200);
                setGun(-1, -1, 0, client);
                Thread.Sleep(200);
                setGun(1, 1, 1, client);
                Thread.Sleep(200);
                setGun(2, 2, 2, client);
                Thread.Sleep(200);
                setGun(0, 0, 0, client);
                Thread.Sleep(200);
            }
            setGun(0, 0, 0, client);
        }



        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doRetarded), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
