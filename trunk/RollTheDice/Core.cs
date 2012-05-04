using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;
namespace RollTheDice
{
    class Core
    {
        public static string Version = "2.1";


        public static IntPtr j_speed = (IntPtr)0x46F3A7;
        public static IntPtr j_height = (IntPtr)0x787408;
        public static IntPtr fallmax = (IntPtr)0x76E3DC;
        public static IntPtr fallmin = (IntPtr)0x787048;
        public static IntPtr gravity = (IntPtr)0x47033C;

        unsafe public static string MW3Console
        {
            get
            {
                IntPtr form = *(IntPtr*)0x593DC80;
                IntPtr txtbox = FindWindowEx(form, IntPtr.Zero, "Edit", null);
                IntPtr console = FindWindowEx(form, txtbox, "Edit", null);
                StringBuilder sb = new StringBuilder(9999999);
                int result = SendMessageTimeout(console, 0x0D, 9999999, sb, 10, 500, IntPtr.Zero);
                return sb.ToString();
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Ansi)]
        public static extern IntPtr FindWindow(string className, string windowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendMessageTimeout(
          IntPtr hWnd,
          uint uMsg,
          uint wParam,
          StringBuilder lParam,
          uint fuFlags,
          uint uTimeout,
          IntPtr lpdwResult);

        public delegate void ClientSayHandler(string message, ServerClient client);
        public static event ClientSayHandler ClientSay;
        public static void invokeSay(string message, ServerClient client)
        {
            if (ClientSay != null) ClientSay(message, client);
        }

        public delegate void ClientSpawnHandler(ServerClient client);
        public static event ClientSpawnHandler ClientSpawn;
        public static void invokeSpawn(ServerClient client)
        {
            if (ClientSpawn != null) ClientSpawn(client);
        }
        public static void RangeKill(ServerClient client, string killmsg)
        {
            foreach (ServerClient otherclient in Core.Owner.GetClients())
            {
                if ((Core.Difference(client.OriginY, otherclient.OriginY) <= 200) && (Core.Difference(client.OriginX, otherclient.OriginX) <= 200) && otherclient.Team == Core.CalculateOtherTeam(client))
                {
                    Kill(otherclient);
                    Owner.ServerSay(string.Format(killmsg, otherclient.Name, client.Name), true);
                }
            }
        }
        public static CPlugin Owner;
        public static bool OutOfDate = false;
        public static bool Debug = false;
        public static int[] GetWeaponArray(ServerClient client)
        {
            return new int[] { client.Other.PrimaryWeapon, client.Other.SecondaryWeapon, client.Other.OffhandWeapon, client.Other.Equipment, client.Other.CurrentWeapon };
        }
        public static void RestoreWeaponArray(ServerClient client, int[] WeaponArray)
        {
            WriteDebug("-- Restoring weapon array: --"); int x =-1;
            foreach (int a in WeaponArray) { x++; WriteDebug(x + " = " + a); }
            WriteDebug("-----------------------------");
            client.Other.PrimaryWeapon = WeaponArray[0];
            client.Other.SecondaryWeapon = WeaponArray[1];
            client.Other.OffhandWeapon = WeaponArray[2];
            client.Other.Equipment = WeaponArray[3];
            client.Other.CurrentWeapon = WeaponArray[4];
        }
        public static int MaxHP = 100;
        public static void DoPhone(ServerClient client, bool restoreweapons)
        {
            Thread.Sleep(500);
            int[] a = GetWeaponArray(client);
            client.Other.FreezeControls(true);
            RemoveAllBut(true, client);
            client.Other.PrimaryWeapon = Owner.GetWeapon("killstreak_emp_mp");
            client.Other.CurrentWeapon = Owner.GetWeapon("killstreak_emp_mp");
            Thread.Sleep(1500);
            client.Other.FreezeControls(false);
            if (restoreweapons) RestoreWeaponArray(client, a);
        }
        public static void TakeAll(ServerClient client)
        {
            client.Other.PrimaryWeapon = 0;
            client.Other.OffhandWeapon = 0;
            client.Other.SecondaryWeapon = 0;
            client.Other.Equipment = 0;
        }
        public static void DoLaptop(ServerClient client, bool restoreweapons)
        {
            Thread.Sleep(500);
            int[] a = GetWeaponArray(client);
            TakeAll(client);
            client.Other.FreezeControls(true);
            client.Other.PrimaryWeapon = Owner.GetWeapon("killstreak_remote_tank_laptop_mp");
            client.Other.CurrentWeapon = Owner.GetWeapon("killstreak_remote_tank_laptop_mp");
            Thread.Sleep(1500);
            client.Other.FreezeControls(false);
            if (restoreweapons) RestoreWeaponArray(client, a);
        }
        public static void thirdPersonCamera(object arg)
        {
            object[] args = (object[])arg;
            ServerClient client = (ServerClient)args[0];
            Roll roll = (Roll)args[1];
            Owner.SetClientDvar(client.ClientNum, "cg_thirdperson \"1\"");
            Core.SafeSleep(5, roll);
            Owner.SetClientDvar(client.ClientNum, "cg_thirdperson \"0\"");
        }
        public static void RemoveHead(ServerClient client)
        {
            //client.Other.SetPlayerHeadModel("tag_origin");
        }
        public static void RemoveModel(ServerClient client)
        {
            client.Other.SetPlayerModel("tag_origin");
        }
        public static string[] AllWeapons /*credits to jaydi & yamato*/ = { "iw5_l96a1_mp", 
                                    "iw5_44magnum_mp",
                                    "iw5_usp45_mp",
                                    "iw5_deserteagle_mp",
                                    "iw5_mp412_mp",
                                    "iw5_g18_mp",
                                    "iw5_fmg9_mp",
                                    "iw5_mp9_mp",
                                    "iw5_skorpion_mp",
                                    "iw5_p99_mp",
                                    "iw5_fnfiveseven_mp",
                                    "rpg_mp",
                                    "iw5_smaw_mp",
                                    "stinger_mp",
                                    "javelin_mp",
                                    "xm25_mp",
                                    "iw5_usp45jugg_mp",
                                    "iw5_mp412jugg_mp",
                                    "iw5_m60jugg_mp",
                                    "iw5_riotshieldjugg_mp",
                                    "iw5_m4_mp",
                                    "riotshield_mp",
                                    "iw5_ak47_mp",
                                    "iw5_m16_mp",
                                    "iw5_fad_mp",
                                    "iw5_acr_mp",
                                    "iw5_type95_mp",
                                    "iw5_mk14_mp",
                                    "iw5_scar_mp",
                                    "iw5_g36c_mp",
                                    "iw5_cm901_mp",
                                    "iw5_mp5_mp",
                                    "iw5_mp7_mp",
                                    "iw5_m9_mp",
                                    "iw5_p90_mp",
                                    "iw5_pp90m1_mp",
                                    "iw5_ump45_mp",
                                    "iw5_barrett_mp",
                                    "iw5_rsass_mp",
                                    "iw5_dragunov_mp",
                                    "iw5_msr_mp",
                                    "iw5_as50_mp",
                                    "iw5_ksg_mp",
                                    "iw5_1887_mp",
                                    "iw5_striker_mp",
                                    "iw5_aa12_mp",
                                    "iw5_usas12_mp",
                                    "iw5_spas12_mp",
                                    "iw5_m60_mp",
                                    "iw5_mk46_mp",
                                    "iw5_pecheneg_mp",
                                    "iw5_sa80_mp",
                                    "emp_grenade_mp",
                                    "iw5_mg36_mp" };
        public static string[] AllPerks /*credits to jaydi & yamato*/ = { "specialty_longersprint",
                                "specialty_fastreload",
                                "specialty_scavenger",
                                "specialty_blindeye",
                                "specialty_paint",
                                "specialty_hardline",
                                "specialty_coldblooded",
                                "specialty_quickdraw",
                                "specialty_twoprimaries",
                                "specialty_assists",
                                "specialty_blastshield",
                                "specialty_detectexplosive",
                                "specialty_autospot",
                                "specialty_bulletaccuracy",
                                "specialty_quieter",
                                "specialty_stalker" };
        public static string[] AllOffhand /*credits to jaydi & yamato*/ = { "frag_grenade_mp",
                                "semtex_mp",
                                "c4_mp" };
        public static string[] AllEquipment /*credits to jaydi & yamato*/ = { "flash_grenade_mp",
                                "concussion_grenade_mp",
                                "smoke_grenade_mp",
                                "emp_grenade_mp" };
        public static string[] AllColors /* credits @ jariz */ = { "^1", "^2", "^3", "^4", "^5", "^6", "^7" };
        public static string[] AllAttachments = 
        {
            "none",
            "acog",
            "acogsmg",
            "reflex",
            "reflexsmg",
            "reflexlmg",
            "silencer",
            "silencer02",
            "silencer03",
            "grip",
            "gl",
            "gp25",
            "m320",
            "akimbo",
            "thermal",
            "thermalsmg",
            "shotgun",
            "heartbeat",
            "fmj",
            "rof",
            "xmags",
            "eotech",
            "eotechsmg",
            "eotechlmg",
            "tactical",
            /*vzscope,*/
            "hamrhybrid",
            "hybrid",
            "zoomscope",
            "scope",
            "scopevz"
        };
        public static Teams CalculateOtherTeam(ServerClient Client)
        {
            Teams otherteam;
            if (Client.Team == Teams.Allies) otherteam = Teams.Axis;
            else if (Client.Team == Teams.Axis) otherteam = Teams.Allies;
            else otherteam = Teams.FFA;
            return otherteam;
        }
        public static float Difference(float loc, float loc2)
        {
            return Math.Abs(loc - loc2);
        }
        public static void Ammoz(ServerClient client)
        {
            client.Ammo.PrimaryAmmo = 0;
            client.Ammo.PrimaryAmmoClip = 215;
            client.Ammo.SecondaryAmmo = 0;
            client.Ammo.SecondaryAmmoClip = 215;
            client.Ammo.EquipmentAmmo = 4;
            client.Ammo.OffhandAmmo = 2;
        }
        public static void Kill(ServerClient client)
        {
            TakeAll(client); // remove weapons
            client.Other.ClearPerks(); // hopefully this removes specialty_fallheight
            client.OriginZ = client.OriginZ + 10000; // teleport 10 km into the air
        }
        public static string getRandom(string[] weapons)
        {
            return weapons[Core.randomFix().Next(0, weapons.Length)];
        }
        public static void GunGame(string[] weapons, ServerClient client, Roll roll) //should be ran in a thread
        {
            Thread.Sleep(500);
            int kills = client.Stats.Kills;
            int rank = 0;
            TakeAll(client);
            int wep = Owner.GetWeapon(RandomWeapon(weapons[rank]));
            client.Other.PrimaryWeapon = wep;
            client.Other.CurrentWeapon = wep;
            rank++;
            while (roll.IsThreadRunning)
            {
                if (client.Stats.Kills > kills) // kills are higher then last time
                {
                    try
                    {
                        rank++;
                        if (rank == weapons.Length) break;
                        Core.RemoveAllBut(true, client);
                        int wepp = Owner.GetWeapon(RandomWeapon(weapons[rank]));
                        client.Other.PrimaryWeapon = wepp;
                        client.Other.CurrentWeapon = wepp;
                        Owner.iPrintLnBold("^1RANK UP!", client);
                    }
                    catch(Exception z) {
                        if (Core.Debug) Owner.ServerSay("^3RtD^7: ^1GG::ChangeRank CRASH ^2" + z.Message, true);
                        Core.Unhandled(z);
                    }
                }
                kills = client.Stats.Kills;
                Thread.Sleep(200);
            }
            if (roll.IsThreadRunning) //break was triggered, roll is is still available
            {
                Owner.iPrintLnBold("^1You completed the gun game!", client);
                Thread.Sleep(1000);
                if (!roll.IsThreadRunning) return;
                int r = randomFix().Next(0,2);
                if (r == 0)
                {
                    Owner.iPrintLnBold("^7Your reward is: ^2WALKING AC130", client);
                    Roll ac130 = new Rolls.WalkingAC130();
                    ac130.Owner = Owner;
                    ac130.onInit(client);
                }
                else
                {
                    Owner.iPrintLnBold("^7Your reward is: ^2Overpowered FMG9", client);
                    Roll fmg9 = new Rolls.EvenMoreOverpoweredFMG();
                    fmg9.Owner = Owner;
                    fmg9.onInit(client);
                }
            }
        }
        public static string RandomWeapon(string[] weapons)
        {
            return WeaponBuilder.CreateWeapon(getRandom(weapons), (WeaponBuilder.Attachment)Enum.Parse(typeof(WeaponBuilder.Attachment), getRandom(AllAttachments)), (WeaponBuilder.Attachment)Enum.Parse(typeof(WeaponBuilder.Attachment), getRandom(AllAttachments)), (WeaponBuilder.Camo)randomFix().Next(0, 12), (WeaponBuilder.Reticle)randomFix().Next(0, 7));
        }
        public static string RandomWeapon(string weapon)
        {
            return WeaponBuilder.CreateWeapon(weapon, (WeaponBuilder.Attachment)Enum.Parse(typeof(WeaponBuilder.Attachment), getRandom(AllAttachments)), (WeaponBuilder.Attachment)Enum.Parse(typeof(WeaponBuilder.Attachment), getRandom(AllAttachments)), (WeaponBuilder.Camo)Enum.ToObject(typeof(WeaponBuilder.Camo), randomFix().Next(0, 12)), (WeaponBuilder.Reticle)Enum.ToObject(typeof(WeaponBuilder.Camo), randomFix().Next(0, 7)));
        }
        public static void RemoveAllBut(bool primary, ServerClient client)
        {
            if (primary) client.Other.SecondaryWeapon = 0;
            else client.Other.PrimaryWeapon = 0;
            client.Other.Equipment = 0;
            client.Other.OffhandWeapon = 0;
        }
        public static void WriteDebug(string msg)
        {
            if(Debug) Owner.ServerPrint("[RTD] " + msg);
        }

        public static void setFilmTweaks(ServerClient Client, string on, string invert, string desaturation, string darktint, string lighttint, string brightness, string contrast)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_filmusetweaks \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweaks \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakenable \"" + on + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakinvert \"" + invert + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdesaturation \"" + desaturation + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakdarktint \"" + darktint + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweaklighttint \"" + lighttint + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakbrightness \"" + brightness + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_filmtweakcontrast \"" + contrast + "\"");
        }

        public static void setGlowTweaks(ServerClient Client, string on, string cutoff, string desaturation, string intensity, string radius)
        {
            Owner.SetClientDvar(Client.ClientNum, "r_glowUseTweaks \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glow \"1\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glowTweakEnable \"" + on + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glowTweakBloomCutOff \"" + cutoff + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glowTweakBloomDesaturation \"" + desaturation + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glowTweakBloomIntensity0 \"" + intensity + "\"");
            Owner.SetClientDvar(Client.ClientNum, "r_glowTweakRadius0 \"" + radius + "\"");
        }

        
        //Sleep, but in the meantime check if the thread is still active
        public static void SafeSleep(int AmountSec, Roll roll)
        {
            int total = 0;
            while (total != AmountSec)
            {
                total++;
                if (!roll.IsThreadRunning)
                    break;
                else Thread.Sleep(1000);
            }
            
        }

        public static Random randomFix()
        {
            Thread.Sleep(10);
            return new Random();
        }



        public static void Unhandled(Exception z)
        {
            Owner.ServerPrint("[RTD] [UNHANDLED] " + z.Message);
            Owner.ServerPrint("[RTD] Sending error information....");
            try
            {
                WebClient wc = new WebClient();
                wc.Headers["Content-type"] = "application/x-www-form-urlencoded";
                string ErrorReport = "------------- RtD v2 ERROR REPORT -------------\r\n";
                try
                {
                    ErrorReport += "Machine name: " + Environment.MachineName;
                    ErrorReport += "\r\nSystem version: " + Environment.OSVersion.ToString();
                    ErrorReport += "\r\n.NET version: " + Environment.Version.ToString();
                    ErrorReport += "\r\nRtD version: " + Core.Version;
                    ErrorReport += "\r\nWorking directory: " + Environment.CurrentDirectory;
                    ErrorReport += "\r\nUser: " + Environment.UserName;
                    ErrorReport += "\r\nSystem directory: " + Environment.SystemDirectory;
                    ErrorReport += "\r\nActive rolls: " + RollManager.RegisteredRolls.Count;
                    ErrorReport += "\r\nLoaded rolls: " + RollManager.Rolls.Count;
                    ErrorReport += "\r\nAmount of roll threads: " + Core.RollThreads.Count;
                    ErrorReport += "\r\nRoll thread dump: ";
                    foreach (string thread in Core.RollThreads)
                    {
                        ErrorReport += " " + thread;
                    }
                    ErrorReport += "\r\nRegistered rolls: ";
                    foreach (DictionaryEntry a in RollManager.RegisteredRolls)
                    {
                        Roll roll = ((Roll)a.Value);
                        ServerClient client = null;
                        foreach (ServerClient aclient in Owner.GetClients())
                        {
                            if (aclient.XUID == (string)a.Value)
                                client = aclient;
                        }
                        string playerstring = "";
                        if (client != null)
                            playerstring = client.Name + " ClientNum:" + client.ClientNum + " XUID: " + client.XUID;
                        ErrorReport += playerstring + " | " + roll.Name;
                    }
                    ErrorReport += "\r\nFull error information:\r\n" + z.ToString();
                    ErrorReport += "\r\nSecond stacktrace:\r\n" + Environment.StackTrace;
                    string console = Core.MW3Console;
                    ErrorReport += "\r\nConsole dump:\r\n" + console.Substring(console.Length - 300, 300);
                    ErrorReport += "\r\n-----------------------------------------------";
                }
                catch (Exception r)
                {
                    Owner.ServerPrint("Could not generate error report. Sending a smaller error report");
                    ErrorReport = "------------- RtD v2 ERROR REPORT -------------\r\n";
                    ErrorReport += "Could not generate full report:\r\n" + r.ToString();
                    ErrorReport += "\r\nInternal Error:\r\n" + z.ToString();
                    ErrorReport += "\r\n-----------------------------------------------";
                }
                if (Core.Debug)
                {
                    System.IO.File.WriteAllText("RtD_v2_ErrorReport.txt", ErrorReport);
                    Core.WriteDebug("Wrote " + ErrorReport.Length + " characters to RtD_v2_ErrorReport.txt");
                }
                string HtmlResult = wc.UploadString("http://jariz.nl/functions/post.php", "name=RtD Error Report&mail=error@jariz.nl&message=" + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes((ErrorReport))));
                Owner.ServerPrint("      Done");
            }
            catch (Exception y)
            {
                Owner.ServerPrint("      " + y.Message);
            }
        }

        public static List<string> RollThreads = new List<string>();
        public static int ActiveRolls = 0;

        public static List<string> OHKs = new List<string>();
        public static List<string> SDs = new List<string>();
    }
}
