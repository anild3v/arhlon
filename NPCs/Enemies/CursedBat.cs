using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arhlon.NPCs.Enemies
{
    class CursedBat : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Bat");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.GiantBat];
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.CaveBat);
            AnimationType = NPCID.GiantBat;
            AIType = NPCID.CaveBat;
            NPC.lifeMax = 100;
            NPC.damage = 35;
            NPC.scale = 1f;
            NPC.knockBackResist = .55f;
            NPC.value = 350;
            NPC.defense = 5;
            NPC.buffImmune[BuffID.Confused] = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            float chance = 0;
            if (Main.hardMode)
            {
                chance = Terraria.ModLoader.Utilities.SpawnCondition.Sky.Chance * 0.2f;
            }
            return chance;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.NextBool(8))
            {
                target.AddBuff(BuffID.Confused, 600, true);
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 15; i++)
            {
                int DustType = 16;
                int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.04f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.04f;
                dust.scale *= .8f + Main.rand.Next(-30, 31) * 0.01f;
                dust.noGravity = true;
            }
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 30; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 16, Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), 70, default(Color), .8f);
                }
            }
        }
    }
}