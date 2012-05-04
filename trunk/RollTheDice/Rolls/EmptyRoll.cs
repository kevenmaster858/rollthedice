using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class EmptyRoll : Roll
    {
        public override string Name
        {
            get
            {
                return "ER";
            }
        }
        public override string Version
        {
            get
            {
                return "DEBUG ONLY ROLL";
            }
        }
        public override string Description
        {
            get
            {
                return "^1<ONLY FOR DEBUG PURPOSES>";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        public override void onInit(ServerClient Client)
        {
            //throw new EntryPointNotFoundException("WTF LOL");
        }

        public override void onRemove(ServerClient Client)
        {
            
        }
    }
}
