using Exiled.API.Features;
using Exiled.API.Interfaces;
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

        private static readonly Program Singleton = new Program();

        public override void OnEnabled()
        {
            base.OnEnabled();
        }
    }
}
