/*using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheGodhunter;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using ReLogic.Content;
using Microsoft.Xna.Framework.Graphics;


namespace TheGodhunter.Items
{
	public class DevDisplay : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dev Tablette");
            
			this.SetResearch(1);
		}
		public override void SetDefaults()
		{

			Item.width = 12;
			Item.height = 12;
			Item.useTime = 3;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.value = 0;
			Item.rare = 9;
			Item.UseSound = SoundID.Item14;
		}

		public override bool CanRightClick(){
			return true;
		}



		public override bool ConsumeItem(Player player){		//The item not being consumed when right clicked
			return false;
		}
        private int DevMode=0;
		public override void RightClick(Player player)		
		{
			if (DevMode<2)
            {
				DevMode+=1;	
				
                	
			}
			else{
				DevMode=0;
			}
			
			
		}

        	public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine tooltip = new TooltipLine(Mod, "TheGodhunter: DevDisplay", $"DevMode:  {DevMode:N1} ") { OverrideColor = Color.Red };
			tooltips.Add(tooltip);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture = ModContent.Request<Texture2D>("TheGodhunter/Items/DevDisplay_Glow_1.png", AssetRequestMode.ImmediateLoad).Value;
			spriteBatch.Draw(	texture,new Vector2(),new Rectangle(0, 0, texture.Width, texture.Height),Color.White,rotation,texture.Size() * 0.5f,scale, SpriteEffects.None, 0f);
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
*/