using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
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
    public class BackCommand : ICommand
    {
        public string Command => "back";

        public string[] Aliases => new string[] { };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is not PlayerCommandSender playerCommandSender)
            {
                response = "Только в консоли, друг!";

                return true;
            }

            Player player = Player.Get(playerCommandSender);

            RaycastHit hit;

            if (Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, 50))
            {
                Player target = Player.Get(hit.collider);

                target.RoleManager.InitializeNewRole(Program.OldRoles[target.UserId], PlayerRoles.RoleChangeReason.None);

                if (!Program.OldRoles.ContainsKey(target.UserId))
                {
                    response = "Старая роль не найдена";

                    return true;
                }

                Program.OldRoles.Remove(target.UserId);

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
