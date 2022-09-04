using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arhlon.Projectiles
{
    public class CursedSword : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.aiStyle = 3;
            Projectile.friendly = true;
            Projectile.penetrate = 6;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;


        }


    }
}
