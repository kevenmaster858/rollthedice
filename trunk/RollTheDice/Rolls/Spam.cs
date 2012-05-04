using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;

namespace RollTheDice.Rolls
{
    class Spam : Roll
    {
        public override string Name
        {
            get
            {
                return "SPAM";
            }
        }
        public override string Version
        {
            get
            {
                return "1.6";
            }
        }
        public override string Description
        {
            get
            {
                return "Get ready for abusive admins and 10 year old players!";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        string getRandom(string[] input)
        {
            Random r = new Random();
            return input[Core.randomFix().Next(0, input.Length)];
        }


        void doSpam(object arg)
        {
            ServerClient client = (ServerClient)arg;
            try
            {
                Thread.Sleep(2000);
                string[] randomchat = { "Hi everybody, I hope we have a very fair game!", "HAHA I'M RECORDING THIS, YOU'RE GONNA GET BANNED BUDDY ;)", "BUY FREE HACKS FROM TOTALLY-NOT-A-SCAM-SITE.CO.CC.TK/FakeSteamLoginv4 !!!!!!", "PLZ NOOB NO BAN REPORT", "HACKERRRRR!!!?!?!?!?!?!111", "Reported, Buddy ;)", "HEY CUT IT OUT MY MOMMY'S NOT GONNA LIKE THAT", "plz no hax plz", "where i can get fashion?", "FASHION LINK THE DOWNLOAD PLEASE", "can you give me a aimbot, i'm not so good at this game", "LAGGGGGGGGGG", "^1sn1p3z-h00k ^2v1 || ^3OWNED YOU, ^1YOU FAGGOT", "NOOOOOOOBBBBBB", "MOAB MOTHERFUCKERS", "host plz leave", "So much hackers.... I'm out." };
                string[] rules = { "^1RULE 1: ^2ALWAYS RESPECT ADMINS", "^1RULE 2: ^3NEVER KILL A ADMIN, OR BE BANNED", "^1RULE 3: ^2ADMINS CAN KICK/BAN WITHOUT A REASON", "^1RULE 4: ^1WE KICK FOR MEMBERS", "^1SIGN ^2UP ^3FOR ^4OUR ^5CLAN ^6NOW!", "^7BUY ^2VIP ^7FOR ONLY $9.99 !!!! ^3PLEASE HELP US!" };
                string[] usernames = { "kokole", "[ESL] XxX_Sn3p1eH4x1337_XxX", "YoMomma", "I REPORT CHEATERS", "JariZ", "Nukem", "I'M RUSSIAN!!1", "zxz0o0", "[TG] TheOwner", "SickSickSick", "xXxL3g1TN0sc0p3z360d0ubl3t4pYYcL4ym0r3L4dd3Rst4LLzxXx" };
                string[] teams = { "^1", "^2" };
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    if (Core.randomFix().Next(0, 2) == 1)
                    {
                        if (Core.randomFix().Next(0, 2) == 0)
                        {
                            Owner.iPrintLn(getRandom(rules), client);
                        }
                        else
                        {
                            Owner.iPrintLnBold(getRandom(rules), client);
                        }
                    }
                    Owner.TellClient(client.ClientNum, getRandom(teams) + getRandom(usernames) + "^7: " + getRandom(randomchat), true);
                    Thread.Sleep(Core.randomFix().Next(100, 1000));
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doLag - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            ThreadHandler.AddThread(new WaitCallback(doSpam), Client);
        }

        public override void onRemove(ServerClient Client)
        {
            IsThreadRunning = false;
        }
    }
}
