using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;

namespace TheGodhunter.Items.Placeable
{
    public class GodsPearl : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("God's Pearl");
		}
		
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 10;
            Item.useTurn = true;
            Item.consumable = false;
            Item.value = Item.buyPrice(1, 0, 0, 0);
           // item.createTile = mod.TileType("AstraliteIngotTileBlock"); //put your CustomBlock Tile name
            
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "AstraliteIngot", 15);
            recipe.AddIngredient(null, "GoldKingIngot", 25);   
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }

       
    }
}
