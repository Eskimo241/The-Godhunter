using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TheGodhunter;
using Microsoft.Xna.Framework;

namespace TheGodhunter.Buffs
{
    public class OuchDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water Bolt Minion");
			// Description.SetDefault("A Flying Water Bolt to fight with you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            
            

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 10 ;
        }
    }
}