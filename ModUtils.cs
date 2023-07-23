using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.ModLoader;
using MonoMod.RuntimeDetour.HookGen;
using Terraria.DataStructures;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.GameContent;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;

namespace TheGodhunter
{
	public static class ModUtils
	{
		public static void SetResearch(this ModItem modItem, int researchValue)
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[modItem.Type] = researchValue;
		}



	}
}