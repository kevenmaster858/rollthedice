using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using RollTheDice.ServerwideRolls;
using RollTheDice.Rolls;
using RollTheDice;
using Addon;
using System.Collections;

namespace RollTheDice
{
    class RollManager
    {

        public static void LoadRolls()
        {
            Rolls.Clear();

            if (Core.Debug) AddRoll(new EmptyRoll());
            // - ADD YOUR OWN ROLLS HERE - \\
            AddRoll(new Fat());
            AddRoll(new Sensitivity());
            AddRoll(new Lag());
            AddRoll(new Smack());
            AddRoll(new BoltAction());
            AddRoll(new Night());
            AddRoll(new Bright());
            AddRoll(new NoGun());
            AddRoll(new Drunk());
            AddRoll(new BlackWhite());
            AddRoll(new EyeRape());
            AddRoll(new ExtraHardcore());
            AddRoll(new WorldofWax());
            AddRoll(new ThirdPerson());
            AddRoll(new RollTwice());
            AddRoll(new Forced());
            AddRoll(new Annoying());
            AddRoll(new Wallhack());
            AddRoll(new CSS());
            AddRoll(new Spam());
            AddRoll(new Freeze());
            AddRoll(new Blackouts());
            AddRoll(new OneInTheChamber());
            AddRoll(new Grenade());
            AddRoll(new UnlimitedAmmo());
            AddRoll(new Seizure());
            AddRoll(new Ninja());
            AddRoll(new NoCrosshair());
            AddRoll(new MassSlay());
            AddRoll(new FiftyPerks());
            AddRoll(new ProMod());
            AddRoll(new RocketsNStuff());
            AddRoll(new PewPew());
            AddRoll(new WalkingAC130());
            AddRoll(new Briefcase());
            AddRoll(new Sharpshooter());
            AddRoll(new EvenMoreOverpoweredFMG());
            AddRoll(new Bullseye());
            AddRoll(new GodMode());
            AddRoll(new DoubleHP());
            AddRoll(new OneHitKill());
            AddRoll(new NoMACazines());
            AddRoll(new OneManArmy());
            AddRoll(new SubmachineGunGame());
            AddRoll(new ExplosiveGunGame());
            AddRoll(new ShotgunGunGame());
            AddRoll(new AssaultRifleGunGame());
            AddRoll(new Vampire());
            AddRoll(new SantaClaus());
            AddRoll(new Aura());
            AddRoll(new CopyCat());
            AddRoll(new WeaponDealer());
            AddRoll(new Anticamp());
            AddRoll(new SniperGunGame());
            AddRoll(new Useless());
            AddRoll(new ChuckNorris());
            AddRoll(new Swimming());
            AddRoll(new Retarded());
            AddRoll(new TrueCamper());
            AddRoll(new GlassCanon());
            AddRoll(new OPAGun());
            AddRoll(new Hello());
            AddRoll(new ExtremeJuggernaut());
            AddRoll(new Rapist());
            AddRoll(new UberHardcore());
            AddRoll(new Kamikaze());
            AddRoll(new JamesBond());
            AddRoll(new CocaineSprayer());
            AddRoll(new Sphere());
            AddRoll(new GETTUDACHOPAAA());
            AddRoll(new Orgasm());
            AddRoll(new Terrorist());
            AddRoll(new Developer());
            AddRoll(new Deaf());
            AddRoll(new WatchAndLearn());
            AddRoll(new Fashionable());
            AddRoll(new Ghost());
            AddRoll(new ChooseYourOwnRoll());
            AddRoll(new Juggernaut());
            AddRoll(new Headless());
            AddRoll(new Flashing());
            AddRoll(new Attractive());
            AddRoll(new SuperNovaAO());
            AddRoll(new CharlieSheen());
            AddRoll(new RemoteTank());
            AddRoll(new Terminator());
            AddRoll(new Nightvision());
            AddRoll(new UAV());
            AddRoll(new SuperDamage());
            AddRoll(new TinCan());
            AddRoll(new Rage());
            AddRoll(new OverkillHeartbeat());
            

            

            AddSWRoll(new HighJump());
            AddSWRoll(new Cocaine());
            AddSWRoll(new Space());
            //AddSWRoll(new SlowMotion());
            AddSWRoll(new Knockback());
            AddSWRoll(new Pullback());
            // -                          - \\
        }

        public static ServerwideRoll ActiveSWRoll = null;

        static void serverWideRollSystem(object a)
        {
            Core.WriteDebug("Serverwide Roll System online");
            try
            {
                while (true)
                {
                    if (ActiveSWRoll != null)
                    {
                        while (ActiveSWRoll.StillActive) { Thread.Sleep(250); }
                    }
                    
                    int wait = Core.randomFix().Next(60000, 600000); // original : 600000
                    Core.WriteDebug("[SERVERWIDE] Waiting " + wait + " ms (~"+ wait / 60000 + " minutes) before starting serverside roll");
                    Thread.Sleep(wait); //Every 1 - 10 minutes
                    if (Core.Owner.GetClients() != null)
                        doRandomSWRoll();
                    else
                        Core.WriteDebug("[SERVERWIDE] Tried to start serverwide roll, but no players online. Going to sleep again...");
                }
            } 
            catch(Exception un)
            {
                Core.Unhandled(un);
            }
        }

        public static void RegisterSWRoll(ServerwideRoll swroll)
        {
            ActiveSWRoll = swroll;
            ShowMessageSS(ActiveSWRoll);
            Core.WriteDebug("\r##### SERVERWIDE ROLL #####\rServerwide roll " + ActiveSWRoll.Name + " started!\r###########################");
            foreach (ServerClient rr in Core.Owner.GetClients())
            {
                ActiveSWRoll.onInit(rr);
            }
            ActiveSWRoll.onGlobalInit();
        }

        public static void doRandomSWRoll()
        {
            RegisterSWRoll(SWRolls[Core.randomFix().Next(0, SWRolls.Count)]);
        }

        static void RollWatcher(object a)
        {
            try
            {
                Core.WriteDebug("[RollWatcher] RollWatcher online");
                while (true)
                {
                    Thread.Sleep(4000);
                    int removed = 0;

                    List<ServerClient> clients = Core.Owner.GetClients();
                    Hashtable Copy_RegRolls = (Hashtable)RegisteredRolls.Clone();
                    foreach (DictionaryEntry regroll in Copy_RegRolls)
                    {
                        bool alive = false;
                        foreach (ServerClient c in clients)
                        {
                            if (c.XUID == (string)regroll.Key)
                            {
                                alive = true;
                            }
                        }
                        if (!alive)
                        {
                            removed++;
                            Roll thisroll = (Roll)regroll.Value;
                            thisroll.IsThreadRunning = false; //try to kill the thread.
                            Thread.Sleep(1500); // give the thread some time to stop
                            RegisteredRolls.Remove((string)regroll.Key);
                        }
                    }
                    if (removed > 0) Core.WriteDebug(string.Format("[RollWatcher] Removed {0} clients", removed.ToString()));
                }
            }
            catch (Exception z)
            {
                Core.Unhandled(z);
            }
        }

        public static List<Roll> Rolls;
        public static List<ServerwideRoll> SWRolls;
        public static List<Roll> AbsoluteRolls;
        public static Hashtable RegisteredRolls;
        public static void Initialize(bool InitRegistered)
        {
            Rolls = new List<Roll>();
            if (InitRegistered)
            {
                RegisteredRolls = new Hashtable();
                AbsoluteRolls = new List<Roll>();
                SWRolls = new List<ServerwideRoll>();
                ThreadPool.QueueUserWorkItem(new WaitCallback(RollWatcher));
                ThreadPool.QueueUserWorkItem(new WaitCallback(serverWideRollSystem));
            }

            LoadRolls();
            

            int good = 0;
            int bad = 0;
            int total = 0;
            int sw = 0;

            foreach (Roll roll in Rolls)
            {
                total++;
                if (roll.Good) good++;
                else bad++;
            }

            foreach (ServerwideRoll swroll in SWRolls)
            {
                sw++;
            }
            total = total + sw;
            Core.Owner.ServerPrint(string.Format("  {0} good rolls loaded, {1} bad rolls loaded.", good, bad));
            Core.Owner.ServerPrint(string.Format("  {0} serverwide rolls loaded", sw));
            Core.Owner.ServerPrint(string.Format("  A total of {0} rolls loaded", total));
        }

        //expiremental :\
        public static void RemoveRoll(Roll roll, ServerClient client)
        {
            Roll regroll = ((Roll)RegisteredRolls[client.XUID]);
            Core.WriteDebug("RegisterRoll - Old roll name: " + regroll.Name);
            regroll.onRemove(client);
            RegisteredRolls.Remove(client.XUID);
        }

        public static void justJoined(object arg)
        {
            ServerClient client = (ServerClient)arg;
            Thread.Sleep(6000);
            Core.Owner.iPrintLnBold("^7Welcome to ^3Roll^2The^1Dice.", client);
            Thread.Sleep(1000);
            Core.Owner.iPrintLnBold("^3If you don't know ^5what the hell^3 is going on, type ^2!help", client);
            
        }

        public static void RegisterRoll(Roll roll, ServerClient client)
        {
            try
            {
                LoadRolls(); //this should either fix a lot of issues, or add a lot of issues....
                Core.WriteDebug("RegisterRoll - Roll name: " + roll.Name + " Client name: " + client.Name);
                if (RegisteredRolls[client.XUID] != null)
                {
                    Core.WriteDebug("RegisterRoll - Roll is already registered. Removing and invoking onRemove");
                    RemoveRoll(roll, client);
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(justJoined), client);
                }
                ShowMessage(client, roll);
                RegisteredRolls.Add(client.XUID, roll);
                roll.onInit(client);
                Core.WriteDebug("RegisterRoll - Roll and client added. onInit invoked.");
            }
            catch (Exception z)
            {
                Core.Unhandled(z);
            }
        }

        public static void ShowMessageSS(ServerwideRoll ServerSideRoll)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowMessageSSTH), ServerSideRoll);
        }

        public static void ShowMessageSSTH(object arg)
        {
            Core.WriteDebug("ShowMessageSSTH - Showing messages..");
            ServerwideRoll roll = (ServerwideRoll)arg;

            Core.Owner.iPrintLn("^1[SERVER-WIDE] EVERYONE rolled " + roll.Name, null);
            Core.Owner.iPrintLnBold("^1[SERVER-WIDE] EVERYONE rolled " + roll.Name, null);
            System.Threading.Thread.Sleep(1000);
            Core.Owner.iPrintLnBold("^3" + roll.Description, null);
            Core.WriteDebug("ShowMessageSSTH - Done. [QUIT]");
        }

        public static void ShowMessage(ServerClient client, Roll roll)
        {
            object[] args = new object[] { client, roll };
            System.Threading.Thread th = new System.Threading.Thread(ShowMessageTH);
            th.Start(args);
        }

        static void ShowMessageTH(object args)
        {
            Core.WriteDebug("ShowMessageTH - Showing messages..");
            ServerClient client = (ServerClient)((object[])args)[0];
            Roll roll = (Roll)((object[])args)[1];
            string r = "^1";
            if (roll.Good) r = "^2";
            Core.Owner.iPrintLn("^3" + client.Name + " rolled "+ r + roll.Name, null);
            Core.Owner.iPrintLnBold("You rolled " + r + roll.Name.ToUpper(), client);
            System.Threading.Thread.Sleep(1000);
            Core.Owner.iPrintLnBold("^3" + roll.Description, client);
            Core.WriteDebug("ShowMessageTH - Done. [QUIT]");
        }

        public static void doRandomRoll(ServerClient client)
        {
             RegisterRoll(Rolls[(Core.randomFix()).Next(0, Rolls.Count)], client);
        }

        public static void WriteRolls()
        {
            Core.Owner.ServerPrint("----------------------------------");
            Core.Owner.ServerPrint("Available rolls:");
            int a = 0;
            foreach (Roll roll in Rolls)
            {
                a++;
                Core.Owner.ServerPrint(a + ". " + roll.Name + " v"+roll.Version);
                Core.Owner.ServerPrint("    " + roll.Description);
            }
            Core.Owner.ServerPrint("\r\nAvailable serverwide rolls:");
            a = 0;
            foreach (ServerwideRoll roll in SWRolls)
            {
                a++;
                Core.Owner.ServerPrint(a + ". " + roll.Name + " v" + roll.Version);
                Core.Owner.ServerPrint("    " + roll.Description);
            }
            Core.Owner.ServerPrint("----------------------------------");
            
        }

        public static string ToINI(string rollname)
        {
            return rollname.Replace(" ", "-").ToLower();
        }

        public static void AddSWRoll(ServerwideRoll roll)
        {
            SWRolls.Add(roll);
        }

        public static void AddRoll(Roll roll)
        {
            AbsoluteRolls.Add(roll);

            if (Core.Owner.GetServerCFG("RTDROLLS", ToINI(roll.Name), "") == "")
            {
                Core.Owner.SetServerCFG("RTDROLLS", ToINI(roll.Name), Convert.ToString(true));
            }

            if (Core.Owner.GetServerCFG("RTDROLLS", ToINI(roll.Name), "").ToLower() == Convert.ToString(true).ToLower())
            {
                roll.Owner = Core.Owner;
                Rolls.Add(roll);
            }
        }
    }
}
