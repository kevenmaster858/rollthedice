using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class MassSlay : Roll
    {
        public override string Name
        {
            get
            {
                return "Mass Slay";
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
                return "If you roll 4, you get to kill every player";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        Roll roll1;

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(thread), Client);
        }

        void thread(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(2500);
            Owner.iPrintLnBold("^2ROLLING.... ^3IF YOU ROLL 4 ALL ENEMY PLAYERS DIE", Client);
            Thread.Sleep(1000);
            int r = new Random().Next(0, 5);
            if (r == 4 && Client.Team != Teams.Spectator)
            {
                Teams otherteam;
                if (Client.Team == Teams.Allies) otherteam = Teams.Axis;
                else if (Client.Team == Teams.Axis) otherteam = Teams.Allies;
                else otherteam = Teams.FFA;
                int xx = 0;
                foreach (ServerClient otherclient in Owner.GetClients())
                {
                    if (otherclient.Team == otherteam)
                    {
                        xx++;
                        Owner.iPrintLnBold("^1" + Client.Name + " ^7killed you by rolling 4 at the ^2Mass Slay^7 roll", otherclient);
                        Core.Kill(Client);
                    }
                }
                Owner.ServerSay("^3RtD: ^2" + Client.Name + " ^7rolled 4 at the ^2Mass Slay ^7roll and killed all players from the ^2" + otherteam.ToString() + " ^7team!", true);
                Core.DoPhone(Client, true);
            }
            else
            {
                Owner.iPrintLnBold("^1You rolled " + r + ". :( Rerolling....", Client);
                Thread.Sleep(1000);
                roll1 = RollManager.Rolls[(new Random()).Next(0, RollManager.Rolls.Count)];
                roll1.Owner = Owner;
                roll1.onInit(Client);
                RollManager.ShowMessage(Client, roll1);
            }
        }

        public override void onRemove(ServerClient Client)
        {
            if (roll1 != null) roll1.onRemove(Client);
        }
    }
}
