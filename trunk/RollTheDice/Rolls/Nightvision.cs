using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice.Rolls
{
    class Nightvision : Roll
    {
        public override string Name
        {
            get
            {
                return "Nightvision";
            }
        }

        public override string Description
        {
            get
            {
                return "Just MW3 being the sad little COD4 port it is...";
            }
        }

        public override string Version
        {
            get
            {
                return "1.0";
            }
        }

        public override void onInit(Addon.ServerClient player)
        {
            player.Other.EnableNightvision(true);
        }

        public override void onRemove(Addon.ServerClient player)
        {
            player.Other.EnableNightvision(true);
            player.Other.EnableNightvision(false);
        }
    }
}
