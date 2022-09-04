using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Arhlon.Items.Armor.Cursed
{
    [AutoloadEquip(EquipType.Body)]
    public class CursedBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.Size = new Vector2(18);
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = -13;
            Item.defense = 6;
        }
    }
}
