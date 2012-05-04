using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Threading;
using System.Collections;

namespace RollTheDice.Rolls
{
    class Ninja : Roll
    {
        public override string Name
        {
            get
            {
                return "Ninja";
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
                return "Teleport to a enemy!";
            }
        }
        public override bool Good
        {
            get
            {
                return true;
            }
        }

        void teleport(ServerClient client, ServerClient destination)
        {
            Core.DoPhone(client, true);
            Owner.iPrintLnBold("^3NINJA POWERZ ACTIVATED", client);
            client.OriginX = destination.OriginX;
            client.OriginY = destination.OriginY;
            client.OriginZ = destination.OriginZ + 150;
        }

        bool ninja = false;
        ServerClient currclient;

        void doNinja(object arg)
        {
            try
            {

                ServerClient client = (ServerClient)arg;
                Core.SafeSleep(2, this);
                currclient = client;
                Owner.iPrintLnBold("^2Type ^2!ninja ^3in chat to teleport on top of a enemy!", client);
                IsThreadRunning = true; while(IsThreadRunning)
                {
                    if (ninja)
                    {
                        bool found = true;
                        foreach (ServerClient otherclient in Owner.GetClients())
                        {
                            if (client.Team == Teams.Allies && otherclient.Team == Teams.Axis)
                            {
                                found = true;
                                teleport(client, otherclient);
                                break;
                            }
                            else if (client.Team == Teams.Axis && otherclient.Team == Teams.Allies)
                            {
                                found = true;
                                teleport(client, otherclient);
                                break;
                            }
                            else if (client.Team == Teams.FFA && otherclient.Team == Teams.FFA)
                            {
                                found = true;
                                teleport(client, otherclient);
                                break;
                            }
                            else found = false;
                        }
                        if (!found) Owner.TellClient(client.ClientNum, "^3RtD^7: Sorry, No other enemy players found. Try again. ^3FOREVERALONE.JPG", true);
                        else break; //exit thread
                    }
                    
                    Thread.Sleep(500);
                }
            }
            catch (ThreadAbortException)
            {
                Core.WriteDebug("doFreeze - Thread aborted");
            }
        }

        

        public override void onInit(ServerClient Client)
        {
            Core.ClientSay += new Core.ClientSayHandler(Core_ClientSay);
            ThreadHandler.AddThread(new WaitCallback(doNinja), Client);
        }

        void Core_ClientSay(string message, ServerClient client)
        {
            if (client.XUID == currclient.XUID && message == "!ninja")
                ninja = true;
        }

        public override void onRemove(ServerClient Client)
        {
            ninja = false;
            Core.ClientSay -= Core_ClientSay;
            IsThreadRunning = false;
        }
    }
}
