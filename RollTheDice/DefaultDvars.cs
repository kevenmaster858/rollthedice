using System;
using System.Collections.Generic;
using System.Text;
using Addon;

namespace RollTheDice
{
    class DefaultDvars
    {
        public static void DoDefaultValues(ServerClient Client)
        {
            Core.Owner.SetClientDvar(Client.ClientNum, "ui_mapName \"<USE !leave TO LEAVE>\""); // show message on menu
            Core.Owner.SetClientDvar(Client.ClientNum, "cl_bypassMouseInput \"1\""); // disable menu
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningColor1 \"0 0 0 0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningColor2 \"0 0 0 0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoAmmoColor1 \"0 0 0 0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoAmmoColor2 \"0 0 0 0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoReloadColor1 \"0 0 0 0\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoReloadColor2 \"0 0 0 0\"");
           
        }

        public static void RemoveDefaultValues(ServerClient Client)
        {
            Core.Owner.SetClientDvar(Client.ClientNum, "ui_mapName \"\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "cl_bypassMouseInput \"0\""); // enable menu
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningColor1 \"255 0 0 255\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningColor2 \"255 0 0 255\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoAmmoColor1 \"255 0 0 255\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoAmmoColor2 \"255 0 0 255\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoReloadColor1 \"255 0 0 255\"");
            Core.Owner.SetClientDvar(Client.ClientNum, "lowAmmoWarningNoReloadColor2 \"255 0 0 255\"");
        }
    }
}
