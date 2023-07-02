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
using static Terraria.ModLoader.ModContent;


namespace TheGodhunter
{
	 public class TheGodhunter : Mod
	{

		public static ModKeybind CycleModeHotkey;
		public static ModKeybind ArmorBonusHotkey;
		
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
			//Mod bossChecklist;
			//ModLoader.TryGetMod("BossChecklist", out bossChecklist);
			
			if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
			{
				
				bossChecklist.Call(
					"AddBoss", //Entry Type
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
					); //Boss Portrait
					

				

			}
		}
		


	}
}
	
	





