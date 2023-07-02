/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;

namespace TheGodhunter.Items.Placeable
{
    public class IngotTemplate : ModItem
    {
        public override void SetStaticDefaults()
		{                                                              
			DisplayName.SetDefault("name template");     
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8)); //5 is duration by frame for each frame/ 8 is number of frame
            Tooltip.SetDefault("Tooltip template");
            
            
		}
		
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            //item.useAnimation = 15;\\
           // item.useTime = 10;====== don't put with multi frame
            //item.useStyle = 1;     //
            item.consumable = false;
            item.value = Item.buyPrice(0, 0, 40, 0);
            
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Astralite", 6);   //what you need to craft
            recipe.AddTile(TileID.Furnaces);   //wht tile you need for craft
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
    }
}*/
