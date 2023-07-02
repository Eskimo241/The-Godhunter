using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Placeable
{
    public class Astralite : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite");
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
            Item.value = Item.buyPrice(0, 0, 15, 0);
            Item.createTile = Mod.Find<ModTile>("AstraliteTileBlock").Type; //put your CustomBlock Tile name
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.Sapphire, 2);   
            recipe.AddTile(TileID.Anvils); 
            recipe.AddTile(TileID.Furnaces);  
            recipe.Register();
        }
    }
}
