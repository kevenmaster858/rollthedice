using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Fashionable : Roll
    {
        public override string Name
        {
            get
            {
                return "Fashionable";
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
                return "I wish I could change clothes that fast....";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        string[] models = { "mp_body_delta_elite_assault_aa", "mp_body_delta_elite_assault_ab", "mp_body_delta_elite_assault_ba", "mp_body_delta_elite_assault_bb", "mp_body_delta_elite_lmg_a", "mp_body_delta_elite_lmg_b", "mp_body_delta_elite_smg_a", "mp_body_delta_elite_smg_b", "mp_body_delta_elite_shotgun_a", "mp_body_ally_delta_sniper", "mp_body_russian_military_assault_a", "mp_body_russian_military_lmg_a", "mp_body_russian_military_shotgun_a", "mp_body_russian_military_smg_a", "mp_body_ally_ghillie_desert_sniper", "mp_body_opforce_ghillie_desert_sniper" };
        string[] heads = { "head_delta_elite_a", "head_delta_elite_b", "head_delta_elite_d", "head_delta_elite_c", "head_ally_delta_sniper", "head_russian_military_aa", "head_russian_military_b", "head_russian_military_dd", "head_russian_military_f", "head_opforce_russian_urban_sniper", "head_opforce_russian_air_sniper" };

        void doFashion(object arg)
        {
            ServerClient Client = (ServerClient)arg;
            System.Threading.Thread.Sleep(500);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Core.thirdPersonCamera), new object[] { Client, this });
            while (IsThreadRunning)
            {
                string aaa = Core.getRandom(models);
                string head = Core.getRandom(heads);
                Client.Other.SetPlayerModel(aaa);
                Client.Other.SetPlayerHeadModel(head);
                Owner.ServerPrint(" --- fashionable : " + aaa + " and "+head+" ---");
                Thread.Sleep(700);
            }
        }


        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(doFashion, Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}

//iw5_fnfiveseven_mp_shotgun_zoomscope_camo10_scope5
//killstreak_emp_mp