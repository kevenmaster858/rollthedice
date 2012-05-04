using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice
{
    class ServerwideRoll : Roll
    {
        public virtual void onGlobalInit()
        {

        }

        public virtual void onGlobalRemove()
        {

        }

        public virtual bool StillActive
        {
            get
            {
                return false;
            }
        }
    }
}
