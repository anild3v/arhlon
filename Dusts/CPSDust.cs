using Terraria;
using Terraria.ModLoader;

namespace Arhlon.Dusts
{
    internal class CPSDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            if(dust.scale < 0.3f)
            {
                dust.active = false;
            }


            return false;
        }
    }
}
