using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class Space : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "Space";
            }
        }

        public override string Description
        {
            get
            {
                return "\"I’m gonna meet the sun! Oh no, what do I say? Hi? Hi sun?\" - Space Core";
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
            *(int*)Core.gravity = old;
            _active = false;
        }

        int old;

        unsafe void space(object rrr)
        {
            old = *(int*)Core.gravity;
            *(int*)Core.gravity = 1;
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(space));
        }
    }
}
