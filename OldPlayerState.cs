using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KrytoeNazvanie
{
    public class OldPlayerState
    {
        public RoleTypeId Role { get; }
        public Vector3 Position { get; }

        public OldPlayerState(RoleTypeId role, Vector3 position)
        {
            Role = role; Position = position;
        }
    }
}
