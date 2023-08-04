/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

//LUL

namespace TheGodhunter.Tiles
{
	public abstract class Forge : ModTile
	{
		public override void SetStaticDefaults() {
				
			
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.CoordinateHeights = new [] {16, 16, 16, 16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;	
			
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);	
			TileObjectData.addTile(Type);
			//TileObjectData.newTile.CopyFrom(TileObjectData.Style4x3);
			
			
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AddMapEntry(new Color (33, 133, 185), Language.GetText("Forge"));
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles = new int[] { TileID.WorkBenches };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
		public abstract int DropItem { get; }

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			//Item.NewItem(i * 16, j * 16, 64, 64, ItemType<Items.Placeable.Forge>()); //32 16
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 64, DropItem);
		}
	}
}*/