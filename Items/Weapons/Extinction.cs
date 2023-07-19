using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheGodhunter;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace TheGodhunter.Items.Weapons
{
	public class Extinction : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Extinction");
			
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			// Tooltip.SetDefault("The extinction of life");
		}
		public override void SetDefaults()
		{
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 33));
			Item.damage = 1770130;
			Item.DamageType = DamageClass.Magic;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 240;
			Item.height = 240;
			Item.useTime = 3;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 0;
			Item.value = 0;
			Item.rare = 9;
			Item.UseSound = SoundID.Item14;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.useTurn = true;
			Item.shoot = Mod.Find<ModProjectile>("ExtinctionProjectile").Type;
			Item.shootSpeed = 50f;
			Item.consumable = false;
		}

		public override bool CanRightClick(){
			return true;
		}
		public override bool ConsumeItem(Player player){		//The item not being consumed when right clicked
			return false;
		}
		public override void RightClick(Player player)		
		{
			if (MyPlayer.WritersRule==0){
				MyPlayer.WritersRule+=1;	
		
			}
			else{
				MyPlayer.WritersRule-=1;

			}
			
			
		}


		
		public override void AddRecipes()  //How to craft this item
        {
			if(MyPlayer.WritersRule==1)
			{
            	Recipe recipe = CreateRecipe();
            	recipe.AddIngredient(null, "AstraliteIngot", 15);
            	recipe.AddIngredient(null, "GodsPearl", 100);   
            	recipe.AddTile(TileID.Furnaces);   
            	recipe.Register();
			}
        }
		
	}
}
