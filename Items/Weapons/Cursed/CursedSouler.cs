using Arhlon.DamageClasses;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Arhlon.Projectiles;

namespace Arhlon.Items.Weapons.Cursed
{
	public class CursedSouler : ModItem
	{
		public override string Texture => "Arhlon/Items/Weapons/Cursed/CursedSouler";

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.DamageType = ModContent.GetInstance<CursedClass>(); // Makes our item use our custom damage type.
			Item.width = 28;
			Item.height = 30;
			Item.useStyle = 5;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.autoReuse = true;
			Item.damage = 56;
			Item.mana = 4;
			Item.shoot = ModContent.ProjectileType<CursedSoulerProjectile>();
			Item.knockBack = 4;
			Item.crit = 6;
			Item.value = Item.buyPrice(gold: 1);
			Item.rare = -13;
			Item.UseSound = SoundID.Item71;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Fragments.CursedSoul>(20)
				.Register();
		}
	}
}
