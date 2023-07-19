using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Placeable
{
    public class PlatinumQueen : ModItem
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Platinum Queen");
            // Tooltip.SetDefault("Currently useless");
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
            Item.value = Item.buyPrice(0, 0, 30, 0);
        }

       public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumOre, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        
    }
}
