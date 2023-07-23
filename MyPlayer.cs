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

        public static Vector2 oldpos;
        public static int olddir;
        public static int LockX = -1;
        public static int LockY = -1;
        
        


        public override void ResetEffects()
        {
            WaterBoltMinion = false;
            Pet = false;

        }

        public override void PreUpdate()
        {


            if (LockY >0 && MyPlayer.oldpos.Y !=-1)
            {
                Player.velocity = Vector2.Zero;
                Player.direction = olddir;
                Player.position.Y = oldpos.Y;
                LockY--;
            }
            if (LockX >0 && MyPlayer.oldpos.X !=-1)
            {
                Player.velocity = Vector2.Zero;
                Player.direction = olddir;
                Player.position.X = oldpos.X;
                LockX--;
            }
        }





    }
}