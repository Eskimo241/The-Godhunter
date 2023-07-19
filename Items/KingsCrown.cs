using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items
{
    public class KingsCrown : ModItem
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("King's crown");
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
            
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "GoldKingIngot", 20);   
            recipe.AddTile(TileID.WorkBenches);   
            recipe.Register();
        }
    }
}
