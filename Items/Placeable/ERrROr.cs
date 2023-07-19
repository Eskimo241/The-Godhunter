using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Placeable
{
    public class ERrROr : ModItem
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("ERrROr");
            // Tooltip.SetDefault("that's what it is");
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
            Item.createTile = Mod.Find<ModTile>("ErrTileBlock").Type; //put your CustomBlock Tile name
        }
        
    }
}
