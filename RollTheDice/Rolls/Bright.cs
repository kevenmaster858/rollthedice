using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class Bright : Roll
    {
        public override string Name
        {
            get
            {
                return "Bright";
            }
        }
        public override string Version
        {
            get
            {
                return "1.2";
            }
        }
        public override string Description
        {
            get
            {
                return "Shit's fucking bright!";
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
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakenable \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmUseTweaks \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakcontrast \"1.2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakbrightness \"0.6\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdesaturation \"0.3\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweaklighttint \"2 2 2\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdarktint \"0.6 0.7 0.9\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_filmUseTweaks \"0\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakenable \"0\"");
        }
    }
}
