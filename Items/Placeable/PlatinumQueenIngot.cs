using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Placeable
{
    public class PlatinumQueenIngot : ModItem
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Platinum Queen Bar");
		}
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 40, 0);
           // item.createTile = mod.TileType("ErrTileBlock"); //put your CustomBlock Tile name
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "PlatinumQueen", 4);   //you need 10 Wood
            recipe.AddTile(TileID.Furnaces);   //at work bench
            recipe.Register();
        }
    }
}
