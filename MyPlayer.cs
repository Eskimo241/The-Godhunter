using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheGodhunter.Items.Armor.GodhunterArmor;

namespace TheGodhunter
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public static float WritersRule=0;
       
        public bool WaterBoltMinion = false;
        public bool Pet = false;
        public static bool hasProjectile;
        
        


        public override void ResetEffects()
        {
            WaterBoltMinion = false;
            Pet = false;

        }



    }
}