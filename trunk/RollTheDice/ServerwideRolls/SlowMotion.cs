using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class SlowMotion : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "SlowMotion";
            }
        }

        public override string Description
        {
            get
            {
                return "NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO.........";
            }
        }

        public override bool Good
        {
            get
            {
                return true;
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

        unsafe public override void onGlobalRemove()
        {
            Core.Owner.ServerCommand("con_timescale \"1\"");
            _active = false;
        }


        unsafe void SLOOOOWMMOOOOTIOOOOOOOOOON(object rrr)
        {
            Core.Owner.ServerCommand("con_timescale \"0.25\"");
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(SLOOOOWMMOOOOTIOOOOOOOOOON));
        }
    }
}
