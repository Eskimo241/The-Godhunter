using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Projectiles.Minions
{
    public class WaterBoltMinionP : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.CloneDefaults(ProjectileID.WaterBolt);
            AIType = ProjectileID.WaterBolt;
        }
        public override void AI()
        {
            if (Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item21);
                Projectile.localAI[0] = 1f;
            }
                        for (int num92 = 0; num92 < 5; num92++)
            {
                float num93 = Projectile.velocity.X / 3f * (float)num92;
                float num94 = Projectile.velocity.Y / 3f * (float)num92;
                //int num95 = 4;

            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 29, 0f, 0f, 180, default(Color), 1.8f);
            Main.dust[dust].velocity *= 0.1f;
            if (Projectile.velocity == Vector2.Zero)
            {
                Main.dust[dust].velocity.Y -= 1f;
                Main.dust[dust].scale = 1.2f;
            }
            else
            {
                Main.dust[dust].velocity += Projectile.velocity * 0.2f;
            }
            Main.dust[dust].position.X = Projectile.Center.X + 4f + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].position.Y = Projectile.Center.Y + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].noGravity = true;

           
         
         




        }
        
    }
}
}