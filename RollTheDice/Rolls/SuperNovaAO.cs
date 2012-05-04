using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class SuperNovaAO : Roll
    {
        public override string Name
        {
            get
            {
                return "SuperNovaAO";
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
                return "148 PERKS";
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
            Client.Other.SetPerk(Owner.GetPerk("specialty_akimbo"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_amplify"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_anytwo"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_ap"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_armorpiercing"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_armorvest"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_assists"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_assists_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_automantle"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_autospot"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_autospot_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blackbox"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blastshield"));
            Client.Other.SetPerk(Owner.GetPerk("_specialty_blastshield_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blindeye"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_blindeye_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bling"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bombsquad"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletaccuracy"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletaccuracy2"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletaccuracy_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletdamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_bulletpenetration"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_burstfire"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_carepackage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_challenger"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_coldblooded"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_coldblooded_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_combathigh"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_commando"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_concussiongrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_copycat"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_c4death"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_dangerclose"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_delaymine"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_detectexplosive"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_detectexplosive_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_double_load"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_empimmune"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_empgrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_endgame"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_explosivebullets"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_explosivedamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_exposeenemy"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_extendedmags"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_extendedmelee"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_extraammo"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_extraspecialduration"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_falldamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fasterlockon"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastermelee"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastmantle"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastmeleerecovery"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastoffhand"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastreload"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastreload_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastsnipe"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fastsprintrecovery"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_feigndeath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_finalstand"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_flashgrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fmj"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_fraggrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_freerunner"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_gpsjammer"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_grenadepulldeath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hard_shell"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hardjack"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hardline"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_hardline_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_heartbreaker"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_holdbreath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_holdbreathwhileads"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_improvedholdbreath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_ironlungs"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_jhp"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_juiced"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_jumpdive"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_ks_null"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_laststandoffhand"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_light_armor"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_lightweight"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_littlebird_support"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_localjammer"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_longerrange"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_longersprint"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_longersprint_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_lowprofile"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_luckycharm"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_marathon"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_marksman"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_moredamage"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_null"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_null_attachment"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_null_gl"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_null_grip"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_null_shotgun"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_omaquickchange"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_onemanarmy"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_overkillpro"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_paint"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_paint_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_paint_pro"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_parabolic"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_perks_all"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_pistoldeath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_portable_radar"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_primarydeath"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quickdraw"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quickdraw_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quickswap"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_quieter"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_radararrow"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_radarblip"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_radarjuggernaut"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_rearview"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_reducedsway"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_regenspeed"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_revenge"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_rof"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_rollover"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_saboteur"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_scavenger"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_scavenger_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_scrambler"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_secondarybling"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_selectivehearing"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_sharp_focus"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_shellshock"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_shield"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_siege"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_sitrep"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_smokegrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_specialgrenade"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_spygame"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_spygame2"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stalker"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stalker_ks"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_steadyaim"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_steadyaimpro"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_steelnerves"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stopping_power"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_stun_resistance"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_tacticalinsertion"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_thermal"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_throwback"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_twoprimaries"));
            Client.Other.SetPerk(Owner.GetPerk("specialty_uav"));
        }

        public override void onRemove(ServerClient Client)
        {
            Client.Other.ClearPerks();
        }
    }
}
