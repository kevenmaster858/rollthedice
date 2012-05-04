using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RollTheDice.Rolls;
using System.Threading;

namespace RollTheDice.ServerwideRolls
{
    class RandomRoll : ServerwideRoll
    {
        public Roll[] rolls = null;
        public Roll curr = null;

        void gg()
        {
            if (curr == null)
            {
                rolls = new Roll[] { new UnlimitedAmmo(), new BoltAction(), new RocketsNStuff(), new Grenade(), new JamesBond(), new GlassCanon(), new Hello(), new Briefcase() };
                curr = rolls[Core.randomFix().Next(0, rolls.Length)];
                curr.Owner = Owner;
            }
        }

        public override string Name
        {
            get
            {
                gg();
                return "Random Roll";
            }
        }

        public override string Description
        {
            get
            {
                return "Randomly Generated Client Roll";
            }
        }

        public override bool Good
        {
            get
            {
                gg();
                return curr.Good;
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

        Hashtable WeaponsArrays = new Hashtable();

        public override void onInit(Addon.ServerClient player)
        {
            WeaponsArrays.Add(player.XUID, Core.GetWeaponArray(player));
            RollManager.RegisterRoll(curr, player);
        }

        public override void onRemove(Addon.ServerClient player)
        {
            RollManager.RemoveRoll(curr, player);
            if (WeaponsArrays.Contains(player.XUID))
            {
                Core.RestoreWeaponArray(player, (int[])WeaponsArrays[player.XUID]);
                WeaponsArrays.Remove(player.XUID);
            }
        }
       

        public override void onGlobalRemove()
        {
            _active = false;
        }

        public void wait(object arg)
        {
            Thread.Sleep(60000);
            onGlobalRemove();
        }

        public override void onGlobalInit()
        {
            ThreadHandler.AddThread(new WaitCallback(wait));
        }
    }
}
