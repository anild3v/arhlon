using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Arhlon.Items.Tools
{
    public class AilDrill : ModItem
    {
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20, 12);
            Item.useStyle = 13;
            Item.value = Item.sellPrice(gold: 1);

            Item.autoReuse = true;
            Item.useTime = 8;
			Item.rare = -13;
            Item.useAnimation = 25;
            Item.useStyle = 13;
            Item.UseSound = SoundID.Item23;

            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noUseGraphic = true;

            Item.damage = 14;
            Item.knockBack = 6f;
            Item.shoot = ProjectileType<Projectiles.AilDrill>();
			Item.shootSpeed = 40f;

            Item.pick = 70;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<Items.Placeables.AmnBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Items.Fragments.AilFragment>(), 25);
			recipe.Register();
		}
    }
}