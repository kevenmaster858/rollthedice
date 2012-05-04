using System;
using System.Collections.Generic;
using System.Text;
using Addon;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RollTheDice
{
    public class Roll
    {
        #region Methods
        public virtual void onInit(ServerClient player) { }
        public virtual void onRemove(ServerClient player) { }
        #endregion

        #region Properties
        CPlugin _owner;
        bool _isthreadrunning = true;
        public Roll()
        {
            Core.ActiveRolls++;
        }
        public virtual string Name
        {
            get
            {
                return "<roll failed loading>";
            }
        }
        public virtual string Description
        {
            get
            {
                return "<roll failed loading>";
            }
        }
        public virtual string Version
        {
            get
            {
                return "1.0";
            }
        }
        public virtual bool Good
        {
            get
            {
                return false;
            }
        }
        public virtual CPlugin Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }
        public virtual bool IsThreadRunning
        {
            get
            {
                return _isthreadrunning;
            }
            set
            {
                _isthreadrunning = value;
            }
        }
        #endregion
    }
}
