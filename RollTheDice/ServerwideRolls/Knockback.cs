using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class Knockback : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "Knockback";
            }
        }

        public override string Description
        {
            get
            {
                return "Heavy stuff";
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
            Core.Owner.ServerCommand("g_knockback \"50000\"");
            _active = false;
        }


        unsafe void knock(object rrr)
        {
            Core.Owner.ServerCommand("g_knockback \""+knockback+"\"");
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(knock));
        }
    }
}
