using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrytoeNazvanie.Handlers
{
    public static class PlayerHandler
    {
        public static void OnPlayerShooting(ShootingEventArgs args)
        {
            args.Player.SendConsoleMessage("Shot", "RED");
        }
    }
}
