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
            if (!(sender is PlayerCommandSender))
            {
                response = "Только в консоли, друг!";

                return true;
            }

            string cp = "";

            Player player = Player.Get(sender);

            RaycastHit hit;

            if(Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, Program.Instance.Config.Range))
            {
                Player target = Player.Get(hit.collider.gameObject);

                if (target != null)
                {
                    target.RoleManager.InitializeNewRole(PlayerRoles.RoleTypeId.Tutorial, PlayerRoles.RoleChangeReason.None);
                }

                response = "Игрока " + target.Nickname + " роль была установлена.";

                return true;
            }

            response = "asdqw";

            return true;
        }
    }
}
