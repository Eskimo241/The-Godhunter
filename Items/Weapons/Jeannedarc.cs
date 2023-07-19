using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Items.Weapons
{
	public class Jeannedarc : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jeanne D'arc");
			// Tooltip.SetDefault("It's a small spear but she deal a lot of damage");
		}
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 80;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = 15000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.useTurn = true;
			Item.shoot = Mod.Find<ModProjectile>("JannedarcProjectile").Type;
			Item.shootSpeed = 5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "AstraliteIngot", 1);
			recipe.AddIngredient(null, "GoldKingIngot", 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
