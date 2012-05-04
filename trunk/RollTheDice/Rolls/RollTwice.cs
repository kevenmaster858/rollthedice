using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class RollTwice : Roll
    {
        public override string Name
        {
            get
            {
                return "Roll Twice";
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
                return "ONLY TODAY! 2 rolls for 1";
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
        Roll roll2;

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(thread), Client);
        }

        void thread(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(2000);
            //trying to bypass the whole registerroll system
            Core.WriteDebug("----ROLL TWICE----");
            roll1 = RollManager.Rolls[Core.randomFix().Next(0, RollManager.Rolls.Count)];
            roll1.Owner = Owner;
            Core.WriteDebug("- ROLLING 1st -");
            roll1.onInit(Client);
            RollManager.ShowMessage(Client, roll1);
            System.Threading.Thread.Sleep(1000);
            Core.WriteDebug("- ROLLING 2nd -");
            roll2 = RollManager.Rolls[Core.randomFix().Next(0, RollManager.Rolls.Count)];
            roll2.Owner = Owner;
            roll2.onInit(Client);
            RollManager.ShowMessage(Client, roll2);
            Core.WriteDebug("------------------");
        }

        public override void onRemove(ServerClient Client)
        {
            roll2.onRemove(Client); 
            roll1.onRemove(Client);
            roll1 = new Roll();
            roll2 = new Roll();
        }
    }
}
