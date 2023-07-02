using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheGodhunter.Tiles
{
    public class ErrTileBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            ItemDrop = Mod.Find<ModItem>("ERrROr").Type;   //put your CustomBlock name
            AddMapEntry(new Color(200, 200, 200));
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}