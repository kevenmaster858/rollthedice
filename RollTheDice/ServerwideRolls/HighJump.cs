using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class HighJump : ServerwideRoll
    {
        public override string Name
        {
            get
            {
                return "High Jump";
            }
        }

        public override string Description
        {
            get
            {
                return "SKY HIGH BABY!";
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
            *(float*)Core.j_height = old;
            *(float*)Core.fallmin = 128.0f;
            *(float*)Core.fallmax = 300.0f;
            _active = false;
        }

        float old;

        unsafe void jump(object rrr)
        {
            old = *(float*)Core.j_height;
            *(float*)Core.j_height = 999.0f;
            *(float*)Core.fallmin = 999999.0f;
            *(float*)Core.fallmax = 1000000.0f;
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(jump));
        }
    }
}
