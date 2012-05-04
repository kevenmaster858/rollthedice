using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class CharlieSheen : Roll
    {
        public override string Name
        {
            get
            {
                return "Charlie Sheen";
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
                return "Kill players to increase drug abuse";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void addSeizure(ServerClient Client)
        {

            int rand = Core.randomFix().Next(0, 7);
            if (rand == 1)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_showFbColorDebug \"1\"");
            }
            else if (rand == 0)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_showFloatZDebug \"1\"");
            }
            else if (rand == 2)
            {
                Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"1\"");
            }
            else if (rand == 3)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_colorMap \"" + Core.randomFix().Next(0, 4) + "\"");
            }
            else if (rand == 4)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"0\"");
            }
            else if (rand == 5)
            {
                Owner.SetClientDvar(Client.ClientNum, "r_lightMap \"" + Core.randomFix().Next(0, 4) + "\"");
            }
            else if (rand == 6)
            {
                Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"1\"");
            }
        }

        void seizure(ServerClient Client)
        {
            int i = 0;
            while (i != 3)
            {
                i++;
                addSeizure(Client);
            }
        }

        void Normal(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_scaleViewPort \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_colorMap \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_debugMode \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_showFloatZDebug \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_showFbColorDebug \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "ui_showlist \"0\"");
        }

        void doSheen(object arg)
        {
            Thread.Sleep(1500);
            ServerClient client = (ServerClient)arg;
            Core.TakeAll(client);
            client.Other.PrimaryWeapon = Owner.GetWeapon("iw5_44magnum_mp");
            int kills = client.Stats.Kills;
            float speed = client.Other.SpeedScale;
            float normalspeed = client.Other.SpeedScale;
            while (IsThreadRunning)
            {
                client.Other.SpeedScale = speed;
                if (client.Stats.Kills > kills)
                {
                    if (speed >= 3.0f) Owner.iPrintLnBold("^1You've had enough drugs I think....", client);
                    int a = 0;
                    while (a != 10)
                    {
                        a++;
                        seizure(client);
                        Thread.Sleep(100);
                        Normal(client);
                        Thread.Sleep(50);
                    } // (100 + 50) * 10 = 1500 = 1,5 second

                    speed += normalspeed * 0.2f;
                    
                    Owner.iPrintLn("^1DRUGS! ^2Speed: "+Math.Round((speed - normalspeed ) * 2 * 100 / 2) + "%", client);
                }
                kills = client.Stats.Kills;
                Thread.Sleep(200);
            }
        }

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doSheen), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
