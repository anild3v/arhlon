using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arhlon.Buffs;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Arhlon.Common.Player
{
    internal class ArhlonBuffPlayer : ModPlayer
    {
        public bool doomBuff = false;
        public int doomCount = 0;


        public override void ResetEffects()
        {
            doomBuff = false;
            doomCount = 0;
        }

        public override void UpdateDead()
        {
            ResetEffects();
        }

        public void ApplyDoom(int count = 9)
        {
            Player.AddBuff(ModContent.BuffType<Doom>(), 100000, true, false);
            doomBuff = true;
            doomCount = count;
        }

        public void ReApplyDoom()
        {
            Player.AddBuff(ModContent.BuffType<Doom>(), 100000);
        }

        public void DecreaseDoomCount()
        {
            doomCount--;
            if(doomCount <= 0)
            {
                doomCount = 0;
                doomBuff = false;
                Kill(0, 1, false, PlayerDeathReason.ByCustomReason("was cursed."));
            }
        }
    }
}
