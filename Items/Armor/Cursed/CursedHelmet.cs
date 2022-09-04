using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Arhlon.DamageClasses;
using static Terraria.ModLoader.ModContent;

namespace Arhlon.Items.Armor.Cursed
{
    [AutoloadEquip(EquipType.Head)]
    public class CursedHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.Size = new Vector2(18);
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = -13;
            Item.defense = 7;
        }

        public override void SetStaticDefaults() {
          Tooltip.SetDefault("10% increased cursed damage");

          CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void UpdateEquip(Player player)
              {
                  player.GetDamage<CursedClass>() += 0.10f;
              }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<CursedBreastplate>() && legs.type == ItemType<CursedLeggings>();
        }
    }
}
