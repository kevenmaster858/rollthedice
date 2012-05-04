using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class Cocaine : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "Cocaine";
            }
        }

        public override string Description
        {
            get
            {
                return "MYNOSEISDRIBBLINGISANYONEELSESNOSEDRIBBLINGTHATSREALLYWEIRDIHOPEIDONTHAVEACOLD";
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
            *(int*)Core.j_speed = old;
            _active = false;
        }

        int old;

        unsafe void cocaine(object rrr)
        {
            old = *(int*)Core.j_speed;
            *(int*)Core.j_speed = 500;
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(cocaine));
        }
    }
}
