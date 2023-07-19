
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Ammo
{
	class BombFishRocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bomb Fish Ammunition ");
			// Tooltip.SetDefault("Ammo used as rocket\nBe careful it explode");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.RocketI);
			Item.width = 26;
			Item.height = 14;
			Item.value = Item.buyPrice(0, 0, 0, 40);
			Item.rare = ItemRarityID.Orange;
			Item.damage = 24;
			Item.shoot = ProjectileID.BombFish;
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
		{
			type = Item.shoot;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.BombFish, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
	}
}

