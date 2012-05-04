using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class Pullback : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "Pullback";
            }
        }

        public override string Description
        {
            get
            {
                return "Opposite of knockback";
            }
        }

        public override bool Good
        {
            get
            {
                return false;
            }
        }

        bool _active = true;
        public override bool StillActive
        {
            get
            {
                return _active;
            }
        }
        string knockback = "";
        unsafe public override void onGlobalRemove()
        {
            knockback = Core.Owner.GetDvar("g_knockback");
            Core.Owner.ServerCommand("g_knockback \"-40000\"");
            _active = false;
        }


        unsafe void knock(object rrr)
        {
            Core.Owner.ServerCommand("g_knockback \"" + knockback + "\"");
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(knock));
        }
    }
}
