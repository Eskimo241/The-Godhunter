using Terraria.Audio;

using TheGodhunter.NPCs.Boss.ZaraWE;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using static Terraria.ModLoader.ModContent;
namespace TheGodhunter.Items.Consumable
{
	public class AstralGem : ModItem
	{
		


		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Astral Gem");
			//Tooltip.SetDefault("Summon the Zara's world Destroyer ");
			this.SetResearch(1);
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12;
			
			//DisplayName.SetDefault("Extinction");
		}


		public override void SetDefaults()
		{
			Item.width = Item.height = 16;
			Item.rare = ItemRarityID.LightRed;
			Item.maxStack = 99;

			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useTime = Item.useAnimation = 1;

			Item.noMelee = true;
			Item.consumable = false;
			Item.autoReuse = false;
			
			Item.UseSound = SoundID.Item43;
			
	
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<ZWE>());
		}

		public override bool? UseItem(Player player)
		{
			//NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<ZWE>());
			if(!NPC.AnyNPCs(ModContent.NPCType<ZWE>()) && GHWorld.ZWESpawnTimer==0) GHWorld.ZWESpawnTimer=1;
			Main.NewText("test "+ ItemType<AstralGem>());
			//SoundEngine.PlaySound(SoundID.Roar, player.position);

						
			return false;
		}




		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SpiritBar>(), 3);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}

	
}
