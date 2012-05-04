using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;
using System.Collections;

namespace RollTheDice.Rolls
{
    class ChooseYourOwnRoll : Roll
    {
        public override string Name
        {
            get
            {
                return "Choose your own roll";
            }
        }
        public override string Version
        {
            get
            {
                return "3.0";
            }
        }
        public override string Description
        {
            get
            {
                return "Type ^1!choose name ^7where name is (part of) the roll";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        string name = "";
        bool ninja = false;
        bool used = false;
        ServerClient currclient;

        void doNinja(object arg)
        {
            ServerClient client = (ServerClient)arg;
            currclient = client;
            while (IsThreadRunning)
            {
                if (ninja && !used)
                {
                    used = true;
                    foreach (Roll rolls in RollManager.Rolls)
                    {
                        string rolcolor = "^1";
                        if (rolls.Good) rolcolor = "^2";
                        Owner.ServerSay("^3RtD^7: ^2" + client.Name + " chose a new roll called \""+rolcolor + rolls.Name+"^7\"", true);
                        if (rolls.Name.Contains(name))
                            RollManager.RegisterRoll(rolls, client);
                    }
                }
                Thread.Sleep(200);
            }
        }



        public override void onInit(ServerClient Client)
        {
            Core.ClientSay += new Core.ClientSayHandler(Core_ClientSay);
            ThreadHandler.AddThread(new WaitCallback(doNinja), Client);
        }

        void Core_ClientSay(string message, ServerClient client)
        {
            try
            {
                if (client.XUID == currclient.XUID && message.StartsWith("!choose "))
                {
                    name = message.Substring(8);
                    ninja = true;
                }
            }
            catch { }
        }

        public override void onRemove(ServerClient Client)
        {
            ninja = false;
            Core.ClientSay -= Core_ClientSay;
            IsThreadRunning = false;
        }
    }
}
