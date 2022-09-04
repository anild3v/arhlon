using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arhlon.Projectiles
{
    internal class CursedWhipProjectile : WhipProjectile
    {
        public override void SafeSetDefaults()
        {
            segments = 30;
            rangeMultiplier = 1.05f;
        }

        public override void CustomAI()
        {
            
        }
    }
}