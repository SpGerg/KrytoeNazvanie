using Exiled.API.Features;
using Exiled.API.Interfaces;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Player = Exiled.Events.Handlers.Player;

namespace KrytoeNazvanie
{
    public class Program : Plugin<Config>
    {
        public static Program Instance => Singleton;

        public static Dictionary<string, RoleTypeId> OldRoles = new Dictionary<string, RoleTypeId>();

        private static readonly Program Singleton = new Program();

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnReloaded()
        {
            OldRoles.Clear();

            base.OnReloaded();
        }
    }
}
