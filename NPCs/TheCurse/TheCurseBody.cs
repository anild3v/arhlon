using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Arhlon.Items.Fragments;
using Arhlon.Items.Placeables;
using static Terraria.ModLoader.ModContent;

namespace Arhlon.NPCs.TheCurse
{
	[AutoloadBossHead]
    public class TheCurseBody : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.aiStyle = 1;
            NPC.lifeMax = 21000;
            NPC.damage = 40;
            NPC.defense = 30;
            NPC.knockBackResist = 0;
            NPC.width = 154;
            NPC.height = 112;
            AnimationType = NPCID.KingSlime;
            AIType = NPCID.KingSlime;
            NPC.npcSlots = 10f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.netAlways = true;
						NPC.value = Item.buyPrice(gold: 5);
						if (!Main.dedServ) {
					Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/Maze");
				}
        }

				public override void SetStaticDefaults() {
				DisplayName.SetDefault("The Curse");
				Main.npcFrameCount[Type] = 6;

				NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
					SpecificallyImmuneTo = new int[] {
						BuffID.Poisoned,

						BuffID.Confused
					}
			};
		}


				public override void ModifyNPCLoot(NPCLoot npcLoot) {
					LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

					notExpertRule.OnSuccess(ItemDrop.ModContent.ItemType<Items.Fragments.CursedSoul>(), 10);
					notExpertRule.OnSuccess(ItemDrop.ModContent.ItemType<Items.Placeables.CursedBar>(), 15);
				}

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax += (int)(NPC.lifeMax * 0.579f * bossLifeScale);
            NPC.damage += (int)(NPC.damage * 0.6f);
        }
        public override void AI()
        {
            NPC.ai[0]++;
            Player P = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            NPC.netUpdate = true;

        }
    }
}
