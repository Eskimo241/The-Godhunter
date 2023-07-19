using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items
{
    public class EmptyEnchentementRune : ModItem
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Empty Rune");
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
            Item.value = Item.buyPrice(0, 0, 15, 0);
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.Sapphire, 2);   
            recipe.AddTile(TileID.Anvils);  
            recipe.Register();
        }
    }
}
