using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework.Input;
using TheGodhunter.Items.Consumable;
using TheGodhunter.Items.Bags;
using TheGodhunter.Items.Armor.GodhunterArmor;
using TheGodhunter.NPCs.Boss.ZaraWE;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.Achievements;
using static Terraria.ModLoader.ModContent;


namespace TheGodhunter
{
	 public class TheGodhunter : Mod
	{

		public static ModKeybind CycleModeHotkey;
		public static ModKeybind ArmorBonusHotkey;

		#region Achievements
		private  string AchievementTex = "TheGodhunter/Textures/Achievements/"; //The Folder for the textures
		private string[]  AchievementsName = //Array with all Achievements' name
		{
			"test",					
			"AchievementName",
			"KillZWE"
		};
		public string [][] AchievementsCond = new string[3][]; //Initializing array with conditions; ModItem not yet initialized so we will add what we need later
		#endregion

		public override void Load()
		{
			ModUtils.Load();
			 ArmorBonusHotkey = KeybindLoader.RegisterKeybind(this, "Armor Bonus Set Action", Keys.K);
			 CycleModeHotkey = KeybindLoader.RegisterKeybind(this, "Cycle Writer's Mode", Keys.K);

		}

		public override void Unload()
		{
			ModUtils.Unload();
			ArmorBonusHotkey = null;
			CycleModeHotkey = null;
			
		}

        public override object Call(params object[] args)
		{
			// Make sure the call doesn't include anything that could potentially cause exceptions.
			if (args is null)
			{
				throw new ArgumentNullException(nameof(args), "Arguments cannot be null!");
			}

			if (args.Length == 0)
			{
				throw new ArgumentException("Arguments cannot be empty!");
			}

			// This check makes sure that the argument is a string using pattern matching.
			// Since we only need one parameter, we'll take only the first item in the array..
			if (args[0] is string content)
			{
				// ..And treat it as a command type.
				switch (content)
				{
					case "downedZWE":
						return DownedBossSystem.downedZWE;


				}
			}
        return false;

            }   

        public override void PostSetupContent()
		{	
			if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
			{
				
				/*bossChecklist.Call(
					"LogBoss", //Entry Type
					this, //Mod Instance
					"$Mods.TheGodhunter.NPCName.ZWE", //Boss Name
					ModContent.NPCType<NPCs.Boss.ZaraWE.ZWE>(), //Boss ID
					18.5f, //Progression
					() => DownedBossSystem.downedZWE, //Downed boolean
					() => true, //Availability
					new List<int> { ItemType<GodsHunterBreastplate>(), ItemType<GodsHunterHelmet>(), ItemType<GodsHunterLeggings>() }, //collection
					new List<int> { ItemType<AstralGem>(), ItemType<ChangelogBag>() }, //Spawning
					"Use a [i:" + ItemType<AstralGem>() + "] anywhere; WIP",
					null,
					(SpriteBatch sb, Rectangle rect, Color color) => {
                        Texture2D texture = Request<Texture2D>("TheGodhunter/Textures/BossChecklist/ZWE").Value;
                        Vector2 centered = new Vector2(rect.X + (rect.Width / 2), rect.Y + (rect.Height / 2));
                        sb.Draw(texture, centered, texture.Frame(), color, 0f, texture.Size() / 2, 0.2f, SpriteEffects.None, 0f);
                    }
					//"$Mods.TheGodhunter.BossChecklist.ZWE.DespawnMessage" //Despawn Message
					); //Boss Portrait*/
					Func<LocalizedText> ZWEspawnInfo = delegate()
					{
						LocalizedText text = Language.GetOrRegister(Language.GetText("Mods.TheGodhunter.BossChecklist.ZWE.SpawnInfoPart1") + " [i:" + ModContent.ItemType<AstralGem>() + "]" + Language.GetText("Mods.TheGodhunter.BossChecklist.ZWE.SpawnInfoPart2")); 
						return text; // I don't know another way to do it, but at least it works!
					};

					bossChecklist.Call
					(
						"LogBoss",
						this,
						//Language.GetText("Mods.TheGodhunter.NPCName.ZWE"),
						nameof(ZWE),
						1.5f,
						() => DownedBossSystem.downedZWE,
						ModContent.NPCType<ZWE>(),
						new Dictionary<string, object>()
						{
						["spawnItems"] = ModContent.ItemType<AstralGem>(),
						["displayName"] = Language.GetText("Mods.TheGodhunter.NPCName.ZWE"),
						["spawnInfo"] = ZWEspawnInfo,
						// Other optional arguments as needed...
						}
					);

			}

			if(ModLoader.TryGetMod("TMLAchievements", out Mod TMLachievements))
			{
				#region AchievementsCond
				AchievementsCond[0] = new string[] { "Collect_" + ItemID.RodofDiscord };	//Here we can add our Condition values; Everything is initialize so ItemType<>() will work. May exists better way
				AchievementsCond[1] = new string[] { "Collect_" + ItemType<AstralGem>().ToString()};
				AchievementsCond[2] = new string[] {"Kill_" + NPCType<ZWE>()};
				#endregion
				
				for(int i = 0; i< AchievementsName.Length; i++) TMLachievements.Call("AddAchievement", this, AchievementsName[i], AchievementCategory.Collector, AchievementTex + AchievementsName[i] , null, false, false, 2.5f, AchievementsCond[i]); 	//Making life easier, and code more readable

			}
		}
		

		


	}
}
	
	





