using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Projectiles
{
    public class ExtinctionProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 120;
            Projectile.height = 120;
            Projectile.scale = 1.5f;
            Projectile.aiStyle = 50;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = 999999;
            Projectile.ownerHitCheck = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 50;
            Projectile.hide = false;
        }
        public override void AI()
        {
            Main.player[Projectile.owner].direction = Projectile.direction;
            Main.player[Projectile.owner].heldProj = Projectile.whoAmI;
            Main.player[Projectile.owner].itemTime = Main.player[Projectile.owner].itemAnimation;
            Projectile.position.X = Main.player[Projectile.owner].position.X + (float)(Main.player[Projectile.owner].width / 20) - (float)(Projectile.width / 6);
            Projectile.position.Y = Main.player[Projectile.owner].position.Y + (float)(Main.player[Projectile.owner].height / 2) - (float)(Projectile.height / 2);
            Projectile.position += Projectile.velocity * Projectile.ai[0]; if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 2f;
                Projectile.netUpdate = true;
            }
            if (Main.player[Projectile.owner].itemAnimation < Main.player[Projectile.owner].itemAnimationMax / 3)
            {
                Projectile.ai[0] -= 1.1f;
            }
            else
            {
                Projectile.ai[0] += 0.95f;
            }

           /* if (Main.player[projectile.owner].itemAnimation == 0)
            {
                projectile.Kill();
            }*/

           Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 2.355f;
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation -= 1.57f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 

        }
    }
}