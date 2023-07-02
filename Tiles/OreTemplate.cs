/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace TheGodhunter.Tiles
{
    public class AstraliteTileBlock : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            minPick = 500;
            
            drop = mod.ItemType("Astralite");   //put your CustomBlock name
             AddMapEntry(new Color (33, 133, 185), Language.GetText("Astralite"));

            dustType = 84;
			 
			soundType = 21;
			soundStyle = 1; 
            }
		       
            
        
          
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
    }*/
