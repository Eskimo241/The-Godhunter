using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheGodhunter.Buffs;
using Terraria.DataStructures;
using Terraria.Localization;

namespace TheGodhunter.Projectiles
{
    public class SWRootAltProj3 : ModProjectile //Third Proj = Beam Shockwave
    {
        int newWidth = 0;

        

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.width = 2;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.scale = 5f;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.damage = 100;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 120;
            Projectile.timeLeft = 6000; //We want our shockwave to not deal lot of dps but just a hit
            Projectile.ai[0] = 0;
        }

        public override void AI()
        {
            Projectile.damage = 300; 
            Projectile.knockBack = 50;
            Player owner = Main.player[Projectile.owner];
            if (!owner.active || owner.dead|| owner.ghost)
            {
                Projectile.Kill();
                return;
            }
               
            Projectile.ai[0] ++;
           
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            //Expand the hitbox to follow the animation
            if(Projectile.ai[0] < 30)
            {newWidth = (int)(Projectile.width * (int) Projectile.ai[0] *6f);}

            hitbox.Width = newWidth;
            hitbox.Offset( -newWidth/2 + 45,0); //we want to offset so the center stays the same; however I can't seem to perfectly center it, f* it
            
            
            
        }






    }
}