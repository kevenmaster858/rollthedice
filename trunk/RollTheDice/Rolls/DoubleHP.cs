using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class DoubleHP : Roll
    {
        public override string Name
        {
            get
            {
                return "Double HP";
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
                return "Double HP and reroll!";
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
            Client.Other.Health = Client.Other.Health * 2;
            System.Threading.Thread.Sleep(2000);
            Core.WriteDebug("---- reroll ---");
            roll1 = RollManager.Rolls[Core.randomFix().Next(0, RollManager.Rolls.Count)];
            roll1.Owner = Owner;
            roll1.onInit(Client);
            RollManager.ShowMessage(Client, roll1);
            Core.WriteDebug("---------------");
        }

        public override void onRemove(ServerClient Client)
        {
            roll1.onRemove(Client);
            roll1 = new Roll();
        }
    }
}
