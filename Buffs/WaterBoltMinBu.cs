using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TheGodhunter;


namespace TheGodhunter.Buffs
{
    public class WaterBoltMinBu : ModBuff
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
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer<MyPlayer>();
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("WaterBoltMinion").Type] > 0)
            {
                modPlayer.WaterBoltMinion = true;
            }
            if (!modPlayer.WaterBoltMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}