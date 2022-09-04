using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

		namespace Arhlon.Items.Fragments
{
    public class AilFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ail Fragment");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.rare = -13;
            Item.value = Item.sellPrice(copper: 15);
            Item.maxStack = 9999;
        }
		public override void AddRecipes() {
			Recipe recipe = Recipe.Create(ModContent.ItemType<Items.Placeables.AmnBar>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Fragments.AilFragment>(), 2);
			recipe.Register();
		}
    }
}