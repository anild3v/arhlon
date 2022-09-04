using Arhlon.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arhlon.Items.Weapons.Summoner
{
    internal class CursedWhip : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<CursedWhipProjectile>(), 50, 0.75f, 4f);
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = -13;
        }
    }
}