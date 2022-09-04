using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Arhlon.Common.System
{
    internal class BossDownedSystem : ModSystem
    {
        public static bool downedTheCurse = false;

        public override void OnWorldLoad()
        {
            downedTheCurse = false;
        }

        public override void OnWorldUnload()
        {
            downedTheCurse = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedTheCurse) tag["downedTheCurse"] = true;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedTheCurse = tag.ContainsKey("downedTheCurse");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedTheCurse;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedTheCurse = flags[0];
        }
    }

}
