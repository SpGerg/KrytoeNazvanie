﻿using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Hints;
using InventorySystem.Items;
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

            Player player = Player.Get(playerCommandSender);

            RaycastHit hit;

            if(Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, 50))
            {
                Player target = Player.Get(hit.collider);
                RoleTypeId role = target.Role.Type;

                target.RoleManager.InitializeNewRole(RoleTypeId.Tutorial, RoleChangeReason.None);

                if (!Program.OldRoles.ContainsKey(target.UserId))
                {
                    Program.OldRoles.Add(target.UserId, role);
                }

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
