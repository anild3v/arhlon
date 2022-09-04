using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Arhlon.Items.Weapons.Melee
{
    public class AileeYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.Size = new Vector2(24);
            Item.rare = -13;
            Item.value = Item.sellPrice(gold: 2);

            Item.useTime = 25;
            Item.useAnimation = 20;
            Item.useStyle = 2;
            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.damage = 34;
            Item.knockBack = 3.5f;
            Item.shoot = ProjectileType<Projectiles.AileeYoyo>();
            Item.shootSpeed = 10.5f;
        }
		public override void AddRecipes() {
			Recipe recipe = Recipe.Create(ModContent.ItemType<Items.Weapons.Melee.AileeYoyo>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Fragments.AilFragment>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeables.AmnBar>(), 16);
			recipe.Register();
		}
    }
}