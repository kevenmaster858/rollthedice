using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class FiftyPerks : Roll
    {
        public override string Name
        {
            get
            {
                return "50 Perks";
            }
        }
        public override string Version
        {
            get
            {
                return "1.0";
            }
        }
        public override string Description
        {
            get
            {
                return "All perks you can select in a custom class";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        public override void onInit(ServerClient Client)
        {
            Client.Other.ClearPerks();
            Client.Other.SetPerk(Owner.GetPerk("specialty_longersprint"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastreload"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_scavenger"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blindeye"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_paint"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hardline"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_coldblooded"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quickdraw"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_twoprimaries"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_assists"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blastshield"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_detectexplosive"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_autospot"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletaccuracy"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quieter"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stalker"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_heartbreaker"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_armorpiercing"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_empimmune"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_assists"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_siege"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_falldamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_shellshock"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_delaymine"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_shield"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_thermal"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_localjammer"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blackbox"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_challenger"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_saboteur"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_endgame"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_carepackage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_copycat"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_light_armor"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_primarydeath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_secondarybling"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_explosivedamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_laststandoffhand"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_dangerclose"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_luckycharm"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hardjack"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_extraspecialduration"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_steadyaimpro"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stun_resistance"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_double_load"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_regenspeed"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_autospot"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_overkillpro"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_anytwo"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_combathigh"));
        }

        public override void onRemove(ServerClient Client)
        {
            Client.Other.ClearPerks();
        }
    }
}
