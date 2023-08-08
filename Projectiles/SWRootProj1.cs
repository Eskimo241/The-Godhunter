using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheGodhunter.Buffs;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.Linq;
using Terraria.Graphics.Effects;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;
using Terraria.Utilities;


namespace TheGodhunter.Projectiles
{
    public class SWRootProj1 : ModProjectile //First Proj = sword throw
    {

        private float Frame = 0;


        

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.width = 75;
            Projectile.height = 100;
            Projectile.friendly = true;
            Projectile.scale = 1f;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.damage = 10;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.timeLeft = 25;
        }

        public override void AI()
        {
            Projectile.damage = 10;
            Player owner = Main.player[Projectile.owner];
            if (!owner.active || owner.dead|| owner.ghost)
            {
                Projectile.Kill();
                return;
            }

           
                
            }
        }




    }
