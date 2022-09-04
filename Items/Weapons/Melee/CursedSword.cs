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
using Terraria.GameContent.Creative;
namespace Arhlon.Items.Weapons.Melee
{
    public class CursedSword : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Sword");
            Tooltip.SetDefault("Wait... This is not a sword?!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
			Item.Size = new Vector2(24);
			Item.damage = 46;
			Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 25;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.noUseGraphic = true;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = -13;
			      Item.shoot = ProjectileType<Projectiles.CursedSword>();
            Item.shootSpeed = 12f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
