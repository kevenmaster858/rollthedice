using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice.Rolls
{
    class ThirdPerson : Roll
    {
        public override string Name
        {
            get
            {
                return "Third Person";
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
                return "This is how call of duty would like if it was made by Rockstar.";
            }
        }
        public override bool Good
        {
            get
            {
                return false;
            }
        }

        public override void onInit(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "camera_thirdperson \"1\"");
        }

        public override void onRemove(ServerClient Client)
        {
            Owner.SetClientDvar(Client.ClientNum, "camera_thirdperson \"0\"");
        }
    }
}
