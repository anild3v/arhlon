using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arhlon.Items.Fragments
{
	public class CursedSoul : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cursed Soul");
			Tooltip.SetDefault("'Use it with mind... and curse!'");
			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true; 
			ItemID.Sets.ItemIconPulse[Item.type] = true; 
			ItemID.Sets.ItemNoGravity[Item.type] = true; 

		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = 1000;
			Item.rare = -13;
		}

		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale); 
		}
	}
}