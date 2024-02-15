using TheGodhunter.NPCs;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using TheGodhunter.NPCs.Boss.ZaraWE;
using Terraria.Localization;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace TheGodhunter.NPCs.Boss.ZaraWE
{
	// These three class showcase usage of the WormHead, WormBody and WormTail classes from Worm.cs
	[AutoloadBossHead]
	internal class ZWEHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<ZWEBody>();

		public override int TailType => ModContent.NPCType<ZWETail>();

        private  int iTimer; //how many frames invincibility lasts
        public  int Phase= 0; 

		public override void SetStaticDefaults() {
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() { // Influences how the NPC looks in the Bestiary
				CustomTexturePath = "TheGodhunter/NPCs/Boss/ZaraWE/ZWE_Bestiary", 
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}

		public override void SetDefaults() {
			// Head is 10 defense, body 20, tail 30.
			NPC.CloneDefaults(NPCID.DiggerHead);
			NPC.aiStyle = -1;
			NPC.width = 280;
			NPC.height = 95;
			NPC.boss = true;
			NPC.lifeMax = Main.masterMode ? 5000/2  : Main.expertMode ? 4000/2  : 3000/2;
			NPC.npcSlots = 10;
			iTimer = 0;

		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Looks like a Digger fell into some aqua-colored paint. Oh well.")
			});
		}

		public override void Init() {
			// Set the segment variance
			// If you want the segment length to be constant, set these two properties to the same value
			MinSegmentLength = 50;
			MaxSegmentLength = 50;
            CanFly = true;
            iTimer = 0;




			CommonWormInit(this);
		}


		internal static void CommonWormInit(Worm worm) {
			// These two properties handle the movement of the worm
			worm.MoveSpeed = 5.5f;
			worm.Acceleration = 1;


		}


        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {

			modifiers.SetMaxDamage(1000);
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

		public override void OnKill()
		{
			GHWorld.downedZWE = true;
		}

		public static void SpawnOn(Player player)
		{
			
			//NPC zwe = Main.npc[NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int)player.Center.X+2500, (int)player.Center.Y + 1400, NPCType<ZWE>())];
			NPC zwe = Main.npc[NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int)player.Center.X-2500, (int)player.Center.Y-400, NPCType<ZWEHead>())];
			Main.NewText(Language.GetTextValue("Announcement.HasAwoken", zwe.TypeName), 171, 64, 255);
			//SoundEngine.PlaySound(Sounds.ConvectiveWandererRoar, player.position);
			SoundEngine.PlaySound(SoundID.Roar, player.position);

		}


		public override void AI() {
				Player player = Main.player[NPC.target];

                if(iTimer>0) 
			{
				iTimer--;
				if (iTimer ==0) NPC.dontTakeDamage = false;			//The countdown for iFrames
			}


			if (!player.active || player.dead)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
			}

			
            NPC.noGravity = true; 

			if (Phase == 0) 
				{
				 //targetPoint = player.Center + new Vector2(0, -400);
				 //targetPoint = new Vector2(999999 , 2400);
				 ForcedTargetPosition = new Vector2(NPC.Center.X +10, NPC.Center.Y);
				 MoveSpeed = 10f;
				 
				}
			
			
			else 
			{
				ForcedTargetPosition = player.Center;
				MoveSpeed = 50;
			}

			}

        public override bool CheckActive()
        {
            return false;
        }

        public override bool CheckDead()
        {
            switch (CheckDeadPhase())
			{
				case 1:
				Phase=1;
				CameraSystem.shakeType = 1;
				CameraSystem.camshake = 100;
				NPC.life=NPC.lifeMax = Main.masterMode ? 15000  : Main.expertMode ? 10000  : 7500;
				CommonWormInit(this);
				Main.NewText(Language.GetTextValue("Mods.TheGodhunter.NPCMessages.ZWE1"),109,36,255);
				NPC.dontTakeDamage = true;
				iTimer = 100;
				return false;

				case 2:
				Phase=2;
				CameraSystem.shakeType = 2;
				CameraSystem.camshake = 100;
				NPC.life=NPC.lifeMax =Main.masterMode ? 5000  : Main.expertMode ? 4000  : 3000;
				Main.NewText(Language.GetTextValue("Mods.TheGodhunter.NPCMessages.ZWE2"),109,36,255);
				return false;

				case 3:
				CameraSystem.camshake = 100;
				CameraSystem.shakeType = 3;
				DownedBossSystem.downedZWE = true;
			
				if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
				return true;

				default:
				return false;

			}
        }

        

		public int CheckDeadPhase()
		{
			if(Phase==2) {
			return 3;
			}
			else{
				if(Phase!=0){
					return 2;
				}
				return 1;
			}
			
		}
    
	}


	


	internal class ZWEBody : WormBody
	{
		private int iTimer; //Yeah we have to put an iTimer here too to the boss to not be crushed by super weapons
		public override void SetStaticDefaults() {
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.width = 95;
			NPC.height = 95;

		}

		public override void Init() {
			ZWEHead.CommonWormInit(this);
		}
		
        public override void HitEffect(NPC.HitInfo hit)
        {
			int incomingDmg = hit.SourceDamage;
			Main.NewText("Here");
			
        }

        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {
			Main.NewText("There");
			//modifiers.SetMaxDamage(10);
			iTimer = 12;
        }

		public override bool CheckActive()
        {
            return false;
        }





        public override bool CheckDead()
        {
			iTimer = 100;
            return false;
        }

        public override bool SpecialOnKill()
        {
            return true;
        }

        public override void AI()
        {
            if(iTimer>0) 
			{
				iTimer--;
				if (iTimer ==0) NPC.dontTakeDamage = false;			//The countdown for iFrames
			}
        }





    


      

		
	}


	internal class ZWETail : WormTail
	{
		private int iTimer;
		public override void SetStaticDefaults() {
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.width = 114;
			NPC.height = 95;

		}

        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {
				modifiers.SetMaxDamage(1);

        }

        public override void HitEffect(NPC.HitInfo hit)
        {
			int incomingDmg = hit.SourceDamage;
			
        }

        public override bool SpecialOnKill()
        {
            return true;
        }

        

		public override void Init() {
			ZWEHead.CommonWormInit(this);
		}
		
        public override bool CheckActive()
        {
            return false;
        }

        public override bool CheckDead()
        {
			iTimer = 100;
            return false;
        }

        public override void AI()
        {
            if(iTimer>0) 
			{
				iTimer--;
				if (iTimer ==0) NPC.dontTakeDamage = false;			//The countdown for iFrames
			}
        }
    
	}

}