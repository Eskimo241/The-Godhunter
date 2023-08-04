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
    public class SWRootAltProj2 : ModProjectile //Second Proj = Radiant Beam
    {
        int newHeight = 0;

        

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.width = 40;
            Projectile.height = 2;
            Projectile.friendly = true;
            Projectile.scale = 5f;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.damage = 100;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 2;
            Projectile.timeLeft = 60*3;
            Projectile.ai[0] = 0;
        }

        public override void AI()
        {
            Projectile.damage = 100; 
            Player owner = Main.player[Projectile.owner];
            if (!owner.active || owner.dead|| owner.ghost)
            {
                Projectile.Kill();
                return;
            }
            MyPlayer.LockY = -1; //We don't know whether he was still lock ; edit: it should NOT be >1 in here, we could use a bool but fuck it
            
            
            Projectile.ai[0] ++;

            if ( Projectile.ai[0] < 19) //Fine tuned the timer so it matches perfectly
            {
                owner.position.Y +=10; //Sadly player.velocity.Y is seems to be capped even though the speed o meter was showing good numbers
            }
            else {
                //Spawn Shockwave then beam slowly vanishes.
                // !!NOTE : SHOULD UPDATE HITBOX.WIDTH ACORDINGLY AS IT FADES!!
                owner.noFallDmg = false;

                if (Projectile.ai[0]==40)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, new Vector2 (0,0), ModContent.ProjectileType<SWRootAltProj3>(), 0,0);
                    
                }

                if (Projectile.ai[0]>=120) Projectile.Kill();
                

            }
           
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            //Expand the hitbox to follow the animation
            if(Projectile.ai[0] < 30)
            {newHeight = (int)(Projectile.height * (int) Projectile.ai[0] *1.38f +5);}

            hitbox.Height = newHeight;
            
            
        }






    }
}