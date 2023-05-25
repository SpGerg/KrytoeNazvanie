using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Hints;
using InventorySystem.Items;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KrytoeNazvanie.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SetTutorialCommand : ICommand
    {
        public string Command => "tutorial";

        public string[] Aliases => new string[] { };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is not PlayerCommandSender playerCommandSender)
            {
                response = "Только в консоли, друг!";

                return true;
            }

            Log.Info(playerCommandSender);

            Player player = Player.Get(playerCommandSender);

            if (player == null)
            {
                Log.Info("bruh");
            }

            Log.Info(player);

            RaycastHit hit;

            if(Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, 50))
            {
                Player target = Player.Get(hit.collider);

                target.RoleManager.InitializeNewRole(PlayerRoles.RoleTypeId.Tutorial, PlayerRoles.RoleChangeReason.None);

                response = "Игрок " + target.Nickname;

                return true;
            }
            else
            {
                response = "very bruh";
            }  

            return true;
        }
    }
}
