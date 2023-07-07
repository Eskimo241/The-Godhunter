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
		
		private Vector2 direction = Vector2.One;
		Player player = Main.clientPlayer;
		public override string Texture => "TheGodhunter/Items/Consumable/" + Name;

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
			Item.useTime = Item.useAnimation = 0;

			Item.noMelee = true;
			Item.consumable = false;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("AstralGemProj").Type;
			Item.UseSound = SoundID.Item43;
			Item.channel = true; 
			Item.noUseGraphic = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<ZWE>());
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			//NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<ZWE>());
			if(!NPC.AnyNPCs(ModContent.NPCType<ZWE>()) && GHWorld.ZWESpawnTimer==0) GHWorld.ZWESpawnTimer=1;
			//SoundEngine.PlaySound(SoundID.Roar, player.position);
						
			return true;
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

	public class AstralGemProj : ModProjectile
{
		public override string Texture => "TheGodhunter/Items/Consumable/AstralGemProj";

		private Player owner => Main.player[Projectile.owner];

		private Vector2 direction = Vector2.One;

		private int frameCounter = 0;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Gem");
			Main.projFrames[Projectile.type] = 22;
		}

		public override void SetDefaults()
		{
			Projectile.width = 2;
			Projectile.damage = 0;
			Projectile.height = 2;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 5;
			Projectile.friendly = false;
		}

		public override void AI()
		{
			Projectile.Center = owner.Center;
			Projectile.timeLeft = 2;

			direction = owner.DirectionTo(Main.MouseWorld);

			owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, direction.ToRotation() - 1.57f);
			owner.heldProj = Projectile.whoAmI;
			owner.itemTime = owner.itemAnimation = 3;

			if (direction.X > 0)
				owner.direction = 1;
			else
				owner.direction = -1;

			frameCounter++;
			if (frameCounter % 4 == 0)
			{
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.active = false;


			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			if (frameCounter < 2)
				return false;

			Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;
			int frameHeight = tex.Height / Main.projFrames[Projectile.type];
			var frame = new Rectangle(0, frameHeight * Projectile.frame, tex.Width, frameHeight);

			var startOrigin = new Vector2(30, 66);
			var midOrigin = new Vector2(12, 50);
			var endOrigin = new Vector2(4, 60);

			Vector2 origin;
			
			origin = Vector2.Lerp(startOrigin, midOrigin, Projectile.frame / 18f);
			

			SpriteEffects effects = SpriteEffects.None;
			float rot = direction.ToRotation();

			if (owner.direction != 1)
			{
				effects = SpriteEffects.FlipHorizontally;
				origin.X = tex.Width - origin.X;
				rot -= 3.14f;
			}

			Main.spriteBatch.Draw(tex, owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, direction.ToRotation() - 1.57f) - Main.screenPosition, frame, lightColor, rot, origin, Projectile.scale, effects, 0f);

			return false;
		}
	}
}
