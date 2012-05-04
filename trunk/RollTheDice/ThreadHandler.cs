using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RollTheDice
{
    class ThreadHandler
    {
        //Provides better exception handling and overall better thread monitoring
        //Created for ROLLS and ROLLS only

        public static void AddThread(WaitCallback callback, object state)
        {
            object[] args = { callback, state };
            ThreadPool.QueueUserWorkItem(Invoker, args);
        }

        public static void AddThread(WaitCallback callback) { AddThread(callback, null); }

        static void Invoker(object args)
        {
            try
            {
                object[] arg = (object[])args;
                WaitCallback callback = (WaitCallback)arg[0];
                object state = arg[1];
                string thname = callback.Method.DeclaringType.Namespace + "." + callback.Method.DeclaringType.Name + "." + callback.Method.Name;
                Core.RollThreads.Add(thname);
                try
                {
                    Core.WriteDebug("[ThreadHandler] Thread started: " + thname);
                    callback.Invoke(state);
                }
                catch (Exception z)
                {
                    Core.Unhandled(z);
                }
                Core.RollThreads.Remove(thname);
            }
            catch(Exception z)
            {
                Core.Owner.ServerPrint("[rtd] [ThreadHandler] FATAL ERROR : Threadhandler failed to invoke! Calling Core.Unhandled!");
                Core.Unhandled(z);
            }
        }
    }
}
