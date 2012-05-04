using System;
using System.Collections;
using Addon;
using System.Reflection;
using System.Collections.Generic;
using RollTheDice;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.IO;

namespace RollTheDice
{
    public class RollTheDice : CPlugin
    {
        public override int OnPlayerDamaged(ServerClient Attacker, ServerClient Victim, string Weapon, int Damage)
        {
            if (Core.OHKs.Contains(Victim.XUID))
            {
                return 100;
            }
            if (Core.SDs.Contains(Attacker.XUID))
            {
                return 100;
            }
            else return base.OnPlayerDamaged(Attacker, Victim, Weapon, Damage);
        }

        public override void OnPreMapChange()
        {
            foreach (ServerClient client in GetClients())
                DefaultDvars.RemoveDefaultValues(client);
        }

        public override void OnPlayerSpawned(ServerClient Client)
        {
            if (Core.OHKs.Contains(Client.XUID)) Core.OHKs.Remove(Client.XUID); // just to be sure :D
            if (Core.SDs.Contains(Client.XUID)) Core.SDs.Remove(Client.XUID); 
            DefaultDvars.DoDefaultValues(Client);
            Core.invokeSpawn(Client);
            if(Client.Team != Teams.Spectator) RollManager.doRandomRoll(Client);
        }

        void sendAll(string msg)
        {
            iPrintLnBold(msg, null);
        }

        void WelcomeMessage(object x)
        {
            try
            {
                Thread.Sleep(6000);
                sendAll("^3ROLL THE DICE");
                Thread.Sleep(1000);
                sendAll("^7By ^2JariZ ^7& ^4JayDi");
                Thread.Sleep(1000);
                sendAll("^3Credits to Nukem, zxz0o0 and AZUMIKKEL");
                Thread.Sleep(1000);
                sendAll("^3ITSMODS.COM");
            }
            catch { }
        }
        bool spam = false;
        void Spam(object x)
        {
            try
            {
                spam = true;
                while (spam)
                {
                    if(GetServerCFG("RTD", "nowarning", "").ToLower() != "true") ServerSay("^3RtD^7: ^1WARNING: ^7When you want to leave, type !leave. Else the roll will be ^1ACTIVATED FOR EVER!", true);
                    if (Core.OutOfDate) ServerSay("^3RtD^7: ^3This version of Roll the Dice is outdated! ^2Go to itsmods.com to download the newest version!", true);
                    Thread.Sleep(1000);
                    iPrintLn("^3Roll the dice MOD^7 - By ^2JariZ^7 & ^4JayDi^7 - ITSMODS.COM", null);
                    Thread.Sleep(60000);
                }
            }
            catch { }
        }

        void startMessagePumps()
        {
            if (!spam) ThreadPool.QueueUserWorkItem(new WaitCallback(Spam));
            ThreadPool.QueueUserWorkItem(new WaitCallback(WelcomeMessage));
        }

        public override void OnMapChange()
        {
            startMessagePumps();
        }

        public override void OnFastRestart()
        {
            foreach (ServerClient client in GetClients())
                DefaultDvars.RemoveDefaultValues(client);
            startMessagePumps();
        }

        public override ChatType OnSay(string Message, ServerClient Client)
        {
            try
            {
                Core.invokeSay(Message, Client);

                if (Message == "!leave")
                {
                    ((Roll)RollManager.RegisteredRolls[Client.XUID]).onRemove(Client);
                    RollManager.RegisteredRolls.Remove(Client.XUID);
                    DefaultDvars.RemoveDefaultValues(Client);
                    ServerSay("^3RtD^7: ^2" + Client.Name + " ^7left by typing !leave.", true);
                    ServerPrint("^3RtD^7: ^2" + Client.Name + " ^7left by typing !leave.");
                    ServerCommand("dropclient " + Client.ClientNum + " \"Thank you for playing ^1Roll^2The^3Dice^7!\r\n^3itsmods.com\r\n^2JariZ.nl\"");
                    return ChatType.ChatNone;
                }
                else if (Message == "!roll")
                {
                    string rolcolor = "^1";
                    if (((Roll)RollManager.RegisteredRolls[Client.XUID]).Good) rolcolor = "^2";
                    TellClient(Client.ClientNum, "^3RtD^7: Hello ^2" + Client.Name + "^7.", true);
                    TellClient(Client.ClientNum, " The roll you got right now is: " + rolcolor + ((Roll)RollManager.RegisteredRolls[Client.XUID]).Name, true);
                    return ChatType.ChatNone;
                }
                else if(Message.StartsWith("!give "))
                {
                    if(Core.Debug)
                    {
                        //Core.RemoveAllBut(true, Client);
                        //Core.Ammoz(Client);
                        //Core.RemoveAllBut(true, Client);
                        
                        Client.Other.PrimaryWeapon = GetWeapon(Message.Substring(6));
                        Client.Other.CurrentWeapon = GetWeapon(Message.Substring(6));
                        Client.Ammo.PrimaryAmmo = int.MaxValue;
                        ServerSay("^3RtD^7: Gave "+Client.Name + " a '"+Message.Substring(6)+"'", true);
                    }
                }
                else if (Message == "!hp")
                {
                    ServerSay("^3RtD^7: Your HP = " + Client.Other.Health, true);
                    return ChatType.ChatNone;
                }
                else if (Message == "!kill")
                {
                    Client.Other.Health = -1;
                    return ChatType.ChatNone;
                }
                /*else if (Message.StartsWith("!give2 "))
                {
                    if (Core.Debug)
                    {
                        //Core.RemoveAllBut(true, Client);
                        Client.Other.PrimaryWeapon = GetWeapon(Message.Substring(7));
                        ServerSay("^3RtD^7: Gave " + Client.Name + " a '" + Message.Substring(7) + "' @ currentweapon", true);
                    }
                }*/
                else if (Message.StartsWith("!setswroll "))
                {
                    if (Core.Debug)
                    {
                        bool found = false;
                        foreach (ServerwideRoll like_a_sir in RollManager.SWRolls)
                        {
                            string formatted = Message.Substring(9).ToLower();
                            if (formatted == like_a_sir.Name.ToLower())
                            {
                                RollManager.RegisterSWRoll(like_a_sir);
                                ServerSay("^3RtD^7: '" + like_a_sir.Name + "' GET!", true);
                                found = true;
                                break;
                            }
                        }
                        if (!found) ServerSay("^3RtD^7: Roll not found :(", true);
                        return ChatType.ChatNone;
                    }
                    else
                    {
                        TellClient(Client.ClientNum, "^3RtD^7: Roll the dice is not running in debug mode, Command not allowed.", true);
                        return ChatType.ChatNone;
                    }
                }
                else if (Message.StartsWith("!model "))
                {
                    if (Core.Debug)
                    {
                        Client.Other.SetPlayerModel(Message.Substring(7));
                        ServerSay("^3RtD^7: Changed " + Client.Name + " to a '" + Message.Substring(7) + "'", true);
                    }
                }
                else if (Message.StartsWith("!head "))
                {
                    if (Core.Debug)
                    {
                        Client.Other.SetPlayerHeadModel(Message.Substring(6));
                        ServerSay("^3RtD^7: Changed the head of " + Client.Name + " to a '" + Message.Substring(6) + "'", true);
                    }
                }
                else if (Message.StartsWith("!sound "))
                {
                    if (Core.Debug)
                    {
                        PlaySoundAtOrigin(new Vector(Client.OriginX, Client.OriginY, Client.OriginZ), Message.Substring(7));
                        ServerSay("^3RtD^7: Playing '" + Message.Substring(7) + "'", true);
                    }
                }
                else if (Message.StartsWith("!setroll "))
                {
                    if (Core.Debug)
                    {
                        bool found = false;
                        foreach (Roll like_a_sir in RollManager.Rolls)
                        {
                            string formatted = Message.Substring(9).ToLower();
                            if (formatted == like_a_sir.Name.ToLower())
                            {
                                RollManager.RegisterRoll(like_a_sir, Client);
                                ServerSay("^3RtD^7: '" + like_a_sir.Name + "' GET!", true);
                                found = true;
                                break;
                            }
                        }
                        if (!found) ServerSay("^3RtD^7: Roll not found :(", true);
                        return ChatType.ChatNone;
                    }
                    else
                    {
                        TellClient(Client.ClientNum, "^3RtD^7: Roll the dice is not running in debug mode, Command not allowed.", true);
                        return ChatType.ChatNone;
                    }
                }
                else if (Message.StartsWith("!cmd "))
                {
                    if (Core.Debug)
                    {
                        string[] holyshit = Message.Substring(5).Split(new string[] { " " }, StringSplitOptions.None);
                        string cmd = string.Format("{0} \"{1}\"", holyshit[0], holyshit[1]);
                        SetClientDvar(Client.ClientNum, cmd);
                        ServerSay("^3RtD^7: Set " + cmd + " to client " + Client.ClientNum, true);
                        return ChatType.ChatNone;
                    }
                    else
                    {
                        TellClient(Client.ClientNum, "^3RtD^7: Roll the dice is not running in debug mode, Command not allowed.", true);
                        return ChatType.ChatNone;
                    }
                }
                else if (Message.ToLower() == "!help")
                {
                    TellClient(Client.ClientNum, "^3RtD^7: Welcome to roll the dice. This is a simple gamemode.", true);
                    TellClient(Client.ClientNum, "^3RtD^7: Every time you spawn, you get a (dis)advantage.", true);
                    TellClient(Client.ClientNum, "^3RtD^7: This means you can get really cool stuff, or really lame stuff when you spawn.", true);
                    TellClient(Client.ClientNum, "^3RtD^7: Have Fun! Made by JariZ.nl @ Itsmods.com", true);
                    return ChatType.ChatNone;
                }
                return ChatType.ChatAll;
            }
            catch(Exception z)
            {
                if(Core.Debug) ServerSay("^3RtD^7: EXCEPTION: ^2" + z.ToString(), true);
                return ChatType.ChatNone;
            }
        }

        void rtdconfig(object arg)
        {
            new RTDConfig().ShowDialog();
        }

        public void doConsole(object x)
        {
            while (true)
            {
                string[] a = Core.MW3Console.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                int c = -1;
                foreach (string b in a)
                {
                    c++;
                    bool linegood = c == a.Length - 2;
                    if (b.ToLower() == "]rtd_dump" && linegood)
                    {
                        RollManager.WriteRolls();
                    }
                    else if (b.ToLower() == "]rtd_reload" && linegood)
                    {
                        RollManager.Initialize(false);
                    }
                    else if (b.ToLower() == "]rtd_crash" && linegood)
                    {
                        ServerPrint("Invoking Core.Unhandled with a fake error...");
                        Core.Unhandled(new Exception("This is a crash-test"));
                    }
                    else if (b.ToLower() == "]rtd_config" && linegood)
                    {
                        ServerPrint("Showing RTDConfig form...");
                        ThreadPool.QueueUserWorkItem(new WaitCallback(rtdconfig));
                    }
                    /*else if (b.ToLower() == "]rtd_monitor" && linegood)
                    {
                        ServerPrint("Showing RTDMonitor...");
                        ThreadPool.QueueUserWorkItem(new WaitCallback(rtdmonitor));
                    }*/
                    else if (b.ToLower() == "]rtd_status" && linegood)
                    {
                        ServerPrint("-----------------------");
                        ServerPrint("Active rolls: " + RollManager.RegisteredRolls.Count);
                        ServerPrint("Loaded rolls: " + RollManager.Rolls.Count);
                        ServerPrint("Roll threads: " + Core.RollThreads.Count);
                        ServerPrint("-----------------------");
                    }
                    else if (b.ToLower() == "]qq" && linegood) //LOL BECAUSE FUCK THE NORMAL QUIT COMMAND
                    {
                        ServerPrint("KTHXBAAI");
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        return;
                    }
                    else if (b.ToLower() == "]rtd_threads" && linegood)
                    {
                        ServerPrint("-----------------------");
                        foreach (string y in Core.RollThreads)
                        {
                            ServerPrint(y);
                        }
                        ServerPrint("-----------------------");
                    }
                    else if (b.ToLower() == "rtd_help" && linegood)
                    {
                        ServerPrint("Commands: rtd_status | rtd_config | rtd_dump | rtd_reload | rtd_threads | rtd_help | qq");
                    }
                }
                Thread.Sleep(100);
            }
        }


        public override void OnServerLoad()
        {
            try
            {
                Core.Owner = this;
                if (GetServerCFG("RTD", "debug", "") == "") SetServerCFG("RTD", "debug", "False");
                if (GetServerCFG("RTD", "nowarning", "") == "") SetServerCFG("RTD", "nowarning", "False");

                Core.Debug = GetServerCFG("RTD", "debug", "").ToLower() == "true";

                ServerPrint("----------------------------------");
                ServerPrint("RollTheDice "+Core.Version);
                Core.WriteDebug("DEBUG MODE ACTIVATED!!1");
                ServerPrint("by JariZ & JayDi");
                ServerPrint("Props to: Nukem, zxz0o0, surtek, Pozzuh,\r\n all server hosters and (our lord and saviour) AZUMIKKEL");
                ServerPrint("Loading rolls...");
                RollManager.Initialize(true);
                if(Core.Debug) RollManager.WriteRolls();
                ServerPrint("Checking for updates...");
                try
                {
                    string serverversion = new System.Net.WebClient().DownloadString("http://playermanager.org/rtd/version.txt");
                    if (serverversion != Core.Version)
                    {
                        Core.OutOfDate = true;
                        ServerPrint("   ROLL THE DICE v" + serverversion + " IS RELEASED!");
                        ServerPrint("   UPDATING IS STRONGLY RECOMMENDED!");
                        ServerPrint("   Go to itsmods.com > Tools > MW3 Addon > Plugin Releases\n   to download the newest version");
                    }
                    else ServerPrint("  RTD is up-to-date.");
                }
                catch { ServerPrint("   Update check failed. Couldn't connect to PlayerManager.org"); }
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                ThreadPool.QueueUserWorkItem(new WaitCallback(doConsole));
                try
                {
                    uint size = 4;
                    uint newProtect = 0x40;
                    uint oldProtect = 0;

                    VirtualProtect(Core.j_speed, size, newProtect, out oldProtect);
                    VirtualProtect(Core.j_height, size, newProtect, out oldProtect);
                    VirtualProtect(Core.fallmin, size, newProtect, out oldProtect);
                    VirtualProtect(Core.fallmax, size, newProtect, out oldProtect);
                    VirtualProtect(Core.gravity, size, newProtect, out oldProtect);
                }
                catch (Exception e)
                {
                    ServerLog(LogType.LogConsole, "SPEED PLUGIN ERROR: " + e.ToString());
                }
                ServerPrint("----------------------------------");
            }
            catch (Exception z)
            {
                ServerError(ErrorType.ErrorNormal, z.ToString(), "onServerLoad");
            }
        }


        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
 
        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Core.Unhandled(e.Exception);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Core.Unhandled((Exception)e.ExceptionObject);
            //System.Windows.Forms.MessageBox.Show(((Exception)e.ExceptionObject).ToString(), "Server crashed!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}