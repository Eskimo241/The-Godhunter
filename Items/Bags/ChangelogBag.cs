using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using System.Collections.Generic;
using TheGodhunter;
using Terraria.ModLoader.IO;
using TheGodhunter.Items.Weapons;
using TheGodhunter.Items.Armor.GodhunterArmor;
using TheGodhunter.Items.Consumable;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;


namespace TheGodhunter.Items.Bags
{
	public class ChangelogBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Changelog Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}\nSome items are in development like the armor set ");
		}

		public override void SetDefaults() {
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = false;
			
		}
		public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot){
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlrosGS>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstralGem>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AzesClaw>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Extinction>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GodsHunterBreastplate>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GodsHunterHelmet>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GodsHunterLeggings>(),1,1,1));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WaterBoltSummon>(),1,1,1));
		}

		






        
		public override void AddRecipes()
		{


    			CreateRecipe()
        			.AddIngredient(ItemID.Wood, 5)
				//	.AddCondition(NetworkText.FromKey("RecipeConditions.LowHealth"), r => Main.LocalPlayer.statLife < Main.LocalPlayer.statLifeMax / 2)
					.AddCondition(NetworkText.FromKey("RecipeConditions.DownedZWE"), r => DownedBossSystem.downedZWE)
        			.Register();
			
			
		}


				


    
	
	}
}

