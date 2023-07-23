using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using ReLogic.Content;
using Terraria.DataStructures;
//using MultiHitboxNPCLibrary;
using System.Collections.Generic;
using TheGodhunter;
using Terraria.Localization;
//using TheGodhunter.Systems.CameraSystem;


namespace TheGodhunter.NPCs.Boss.ZaraWE
{
	[AutoloadBossHead]
	public class ZWE : ModNPC
	{
		private int iTimer; //how many frames invincibility lasts
		public int zweSpawnTimer = 0;

		public override void SetStaticDefaults()
		{
			NPCID.Sets.BossBestiaryPriority.Add(Type);

			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				CustomTexturePath = "TheGodhunter/NPCs/Boss/ZWE_Bestiary",
				Position = new Vector2(64f, -64f)
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);


          //  MultiHitboxNPC.MultiHitboxNPCTypes.Add(Type);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				//flavor text
			//	this.TranslatedBestiaryEntry()
			});
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;

			NPC.width = 72;
			NPC.height = 72;

			NPC.defense = 0;
			NPC.damage = 24;
			NPC.knockBackResist = 0f;
			NPC.lifeMax = Main.masterMode ? 5000  : Main.expertMode ? 4000  : 3000;
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.lavaImmune = true;
			NPC.npcSlots = 1f;
			NPC.behindTiles = false;
			NPC.boss = true;
			NPC.value = Item.buyPrice(silver: 1);
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			iTimer = 0;





			segmentPositions = new Vector2[numSegments * segmentsPerHitbox + 6];
		}

		public static void UpdateZWESpawning()
		{
			GHWorld.ZWESpawnTimer++;
			if(GHWorld.ZWESpawnTimer >100)
			{
				CameraSystem.camshake += 100;
				CameraSystem.shakeType = 0;
				foreach(Player player in Main.player)
				{
					SpawnOn(player);
					
					GHWorld.ZWESpawnTimer=0;
					break;
				}
			}
		}

		public static void SpawnOn(Player player)
		{
			
			//NPC zwe = Main.npc[NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int)player.Center.X+2500, (int)player.Center.Y + 1400, NPCType<ZWE>())];
			NPC zwe = Main.npc[NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int)player.Center.X-2500, (int)player.Center.Y-400, NPCType<ZWE>())];
			Main.NewText(Language.GetTextValue("Announcement.HasAwoken", zwe.TypeName), 171, 64, 255);
			//SoundEngine.PlaySound(Sounds.ConvectiveWandererRoar, player.position);
			SoundEngine.PlaySound(SoundID.Roar, player.position);

		}

		public override void OnKill()
		{
			GHWorld.downedZWE = true;
		}

		const int numSegments = 60; //Overall length of the worm 
		const int segmentsPerHitbox = 42+1; // This is the length of the "body" segment; and yes 42 'cause it's fun but had to add 1
		const int segmentsHead = 100;// Length of the Head segment
		const int segmentsTail = 65;// Length of the tail segment
		//All the lengths is the lengths in pixel of the segment divided by two aprox. Ex: My body segment is about 90+ pixels, 90/2= 45, but in my case I had to try I retry because I had to remove the black lines of my sprite
		const int hitboxSegmentOffset = 12;
		private Vector2[] segmentPositions;
		
		private int Phase= 0; 


        public override void AI()
		{
			if(iTimer>0) 
			{
				iTimer--;
				if (iTimer ==0) NPC.dontTakeDamage = false;			//The countdown for iFrames
			}

			Player player = Main.player[NPC.target];
			if (!player.active || player.dead)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
			}

			if (NPC.localAI[0] == 0)
			{
				NPC.rotation = (player.Center - NPC.Center).ToRotation();
				NPC.localAI[0] = 1;

				segmentPositions[0] = NPC.Center + new Vector2(NPC.width / 2 - 2, 0).RotatedBy(NPC.rotation);
				for (int i = 1; i < segmentPositions.Length; i++)
				{
					segmentPositions[i] = segmentPositions[i - 1] - new Vector2(NPC.width, 0).RotatedBy(NPC.rotation);
				}
			}

			//changeable ai values
			float rotationFade = 9f;
			float rotationAmount = 0.1f;

			//Do AI
            NPC.noGravity = true; 
			Vector2 targetPoint;
			if (Phase == 0) 
				{
				 //targetPoint = player.Center + new Vector2(0, -400);
				 //targetPoint = new Vector2(999999 , 2400);
				 targetPoint = new Vector2(NPC.Center.X +10, NPC.Center.Y);
				}
			
			
			else 
			{
				targetPoint = player.Center;
			}

			NPC.ai[0] = 0;


			Vector2 velocityGoal = 32 * (targetPoint - NPC.Center).SafeNormalize(Vector2.Zero);
			NPC.velocity += (velocityGoal - NPC.velocity)/ 60;

			
			Vector2 vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
			float num191 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
			float num192 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
			num191 = (float)((int)(num191 / 16f) * 16);
			num192 = (float)((int)(num192 / 16f) * 16);
			vector18.X = (float)((int)(vector18.X / 16f) * 16);
			vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
			num191 -= vector18.X;
			num192 -= vector18.Y;
			float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
			if (NPC.soundDelay == 0)
			{
				float num195 = num193 / 40f;
				if (num195 < 10f)
				{
					num195 = 10f;
				}
				if (num195 > 20f)
				{
					num195 = 20f;
				}
				NPC.soundDelay = (int)num195;
				SoundEngine.PlaySound(new SoundStyle("Terraria/Sounds/Roar_1"), NPC.Center);
			}

			
			
			
			


			float minSpeed = NPC.noGravity ? 5 : 0; //NPC.noGravity ? 5 : 0    it verifies that the noGravity is true, if true the minSpeed is 5, otherwise minSpeed is 0; Useless here as I defined the worm with noGravity at all
			float maxSpeed =/*512*/1;
			if (NPC.velocity.Length() > maxSpeed)
			{
				NPC.velocity = NPC.velocity.SafeNormalize(Vector2.Zero) * maxSpeed;
			}
			if (NPC.velocity.Length() < minSpeed)
			{
				//prevents extreme ascent in worms with min speed
				if (NPC.noGravity = false && NPC.velocity.Y < 0)
				{
					float xVelocity = (NPC.velocity.X > 0 ? 1 : (NPC.velocity.X < 0 ? -1 : (Main.rand.NextBool() ? 1 : -1))) * (float)Math.Sqrt(minSpeed * minSpeed - NPC.velocity.Y * NPC.velocity.Y);
					NPC.velocity = new Vector2(xVelocity, NPC.velocity.Y);
				}
				else
				{
					NPC.velocity = NPC.velocity.SafeNormalize(Vector2.Zero) * minSpeed;
				}
			}
			NPC.rotation = NPC.velocity.ToRotation();
			NPC.noGravity = true;

			//update segment positions
			segmentPositions[0] = NPC.Center + NPC.velocity + new Vector2(NPC.width / 2 - 2, 0).RotatedBy(NPC.rotation);
			Vector2 rotationGoal = Vector2.Zero;

			for (int i = 1; i < segmentPositions.Length; i++)
			{
				if (i > 1)
				{
					rotationGoal = ((rotationFade - 1) * rotationGoal + (segmentPositions[i - 1] - segmentPositions[i - 2])) / rotationFade;
				}

				segmentPositions[i] = segmentPositions[i - 1] + (rotationAmount * rotationGoal + (segmentPositions[i] - segmentPositions[i - 1]).SafeNormalize(Vector2.Zero)).SafeNormalize(Vector2.Zero) * 2;
			}

			//position hitbox segments
			/*List<RectangleHitboxData> hitboxes = new List<RectangleHitboxData>();
			for (int h = 0; h < numSegments; h++)
			{
				Vector2 spot = segmentPositions[h * segmentsPerHitbox + hitboxSegmentOffset];
				hitboxes.Add(new RectangleHitboxData(new Rectangle((int)spot.X - NPC.width / 2, (int)spot.Y - NPC.height / 2, NPC.width, NPC.height)));
			}*/
			//NPC.GetGlobalNPC<MultiHitboxNPC>().AssignHitboxFrom(hitboxes);

			//dig effect adapted from vanilla
			/*foreach (RectangleHitbox rectangleHitbox in NPC.GetGlobalNPC<MultiHitboxNPC>().hitboxes.AllHitboxes())
			{
				Rectangle hitbox = rectangleHitbox.hitbox;
				int num180 = (int)(hitbox.X / 16f) - 1;
				int num181 = (int)((hitbox.X + hitbox.Width) / 16f) + 2;
				int num182 = (int)(hitbox.Y / 16f) - 1;
				int num183 = (int)((hitbox.Y + hitbox.Height) / 16f) + 2;
				if (num180 < 0)
				{
					num180 = 0;
				}
				if (num181 > Main.maxTilesX)
				{
					num181 = Main.maxTilesX;
				}
				if (num182 < 0)
				{
					num182 = 0;
				}
				if (num183 > Main.maxTilesY)
				{
					num183 = Main.maxTilesY;
				}
				for (int num184 = num180; num184 < num181; num184++)
				{
					for (int num185 = num182; num185 < num183; num185++)
					{
						if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].HasUnactuatedTile && (Main.tileSolid[(int)Main.tile[num184, num185].TileType] || Main.tileSolidTop[(int)Main.tile[num184, num185].TileType] && Main.tile[num184, num185].TileFrameY == 0) || Main.tile[num184, num185].LiquidAmount > 64))
						{
							Vector2 vector17;
							vector17.X = (float)(num184 * 16);
							vector17.Y = (float)(num185 * 16);
							if (hitbox.X + hitbox.Width > vector17.X && hitbox.X < vector17.X + 16f && hitbox.Y + hitbox.Height > vector17.Y && hitbox.Y < vector17.Y + 16f)
							{
								if (Main.rand.NextBool(100) && Main.tile[num184, num185].HasUnactuatedTile)
								{
									WorldGen.KillTile(num184, num185, true, true, false);
								}
								if (Main.netMode != 1 && Main.tile[num184, num185].TileType == 2)
								{
									ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].TileType;
								}
							}
						}
					}
				}
			}*/
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			if (NPC.IsABestiaryIconDummy)
			{
				NPC.rotation = MathHelper.Pi;
				NPC.Center -= new Vector2(20, 0);
				segmentPositions[0] = NPC.Center + new Vector2(NPC.width / 2 - 2, 0).RotatedBy(NPC.rotation);
				const float rotAmoutPerSegment = 0.05f;
				for (int i = 1; i < segmentPositions.Length; i++)
				{
					segmentPositions[i] = segmentPositions[i - 1] - new Vector2(2, 0).RotatedBy(NPC.rotation + rotAmoutPerSegment * i);
				}
			}

			//draw body
			Texture2D bodyTexture = TextureAssets.Npc[Type].Value;
			for (int i = segmentPositions.Length - 1; i > 0; i--)
			{
				Vector2 drawPosition = (segmentPositions[i] + segmentPositions[i - 1]) / 2;

				int buffer = 16;
				if (!spriteBatch.GraphicsDevice.ScissorRectangle.Intersects(new Rectangle((int)(drawPosition - screenPos).X - buffer, (int)(drawPosition - screenPos).Y - buffer, buffer * 2, buffer * 2)))
				{
					continue;
				}

				float rotation = (segmentPositions[i - 1] - segmentPositions[i]).ToRotation();
				float scale = 1f;

				int segmentFramePoint = i < (segmentsHead + 1) ? 470 - 2 * (i - 1) //head; "470" here is approximately the width of the sprite; It reads the sprite from the right  until it reaches the segmentsHead you have inputted *2
					: i >= segmentPositions.Length - segmentsTail ? 2 * (segmentPositions.Length - 1 - i) //tail; same as above but read from the left untill segmentsTail
					: 244 - 2 * ((i - (segmentsHead + 1)) % segmentsPerHitbox); //body; same as head, starts from the right, here from 244 pixels for 43 pixels to the left

				Tile posTile = Framing.GetTileSafely(drawPosition.ToTileCoordinates());
				if (posTile.HasTile && Main.tileBlockLight[posTile.TileType] && Lighting.GetColor((int)(drawPosition.X / 16), (int)(drawPosition.Y / 16)) == Color.Black && !Main.LocalPlayer.detectCreature)
                {
					continue;
                }

				Color color = Color.White; //Lighting.GetColor((int)(drawPosition.X / 16), (int)(drawPosition.Y / 16));
				spriteBatch.Draw(bodyTexture, drawPosition - screenPos, new Rectangle(segmentFramePoint, 0, 4, TextureAssets.Npc[Type].Height()), NPC.GetAlpha(NPC.GetNPCColorTintedByBuffs(color)), rotation, new Vector2(2, TextureAssets.Npc[Type].Height() / 2), new Vector2(scale, 1), SpriteEffects.None, 0f);
			}

			return false;
		}


		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			
		}

		public override bool CheckDead()
		{
			if(Phase==2) {
				if (!DownedBossSystem.downedZWE)
			{
				DownedBossSystem.downedZWE = true;
			
				if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
				
			}
			CameraSystem.camshake = 100;
			CameraSystem.shakeType = 3;
			/*ICollection<RectangleHitbox> collection = NPC.GetGlobalNPC<MultiHitboxNPC>().hitboxes.AllHitboxes();
			foreach (RectangleHitbox hitbox in collection)
			{
				for (int j = 0; j < 3; j++)
				{
					Main.dust[Dust.NewDust(hitbox.hitbox.TopLeft(), hitbox.hitbox.Width, hitbox.hitbox.Height, 74, Scale: 1.75f)].noGravity = true;
				}
			}*/
			return true;
			}
			else{
				if(Phase!=0){
					//Animation same but screen shake
					Phase=2;
					CameraSystem.shakeType = 2;
					CameraSystem.camshake = 100;
					NPC.life=NPC.lifeMax =Main.masterMode ? 5000  : Main.expertMode ? 4000  : 3000;
					Main.NewText(Language.GetTextValue("Mods.TheGodhunter.NPCMessages.ZWE2"),109,36,255);
					return false;
				}
				//Animation for second phase : Go above the player, glow white, blue explosion particle and remove first layer
				Phase=1;
				CameraSystem.shakeType = 1;
				CameraSystem.camshake = 100;
				NPC.life=NPC.lifeMax = Main.masterMode ? 15000  : Main.expertMode ? 10000  : 7500;
				Main.NewText(Language.GetTextValue("Mods.TheGodhunter.NPCMessages.ZWE1"),109,36,255);
				NPC.dontTakeDamage = true;
				iTimer = 100;
				return false;
			}
			
		}
	}
}

