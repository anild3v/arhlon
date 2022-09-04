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

namespace Arhlon.Projectiles
{
    public class AileeYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 15.5f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 325f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13.5f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.Size = new Vector2(16);
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
			Projectile.damage = 34;
			Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }
    }
}