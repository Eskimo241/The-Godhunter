using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Projectiles.Minions
{   
    public class WaterBoltMinion : MinionINFO
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Main.projFrames[Projectile.type] = 9;
            Projectile.friendly = true;
            Main.projPet[Projectile.type] = true;
            Projectile.minion = true;
            Projectile.netImportant = true;
            Projectile.minionSlots = 1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 18000;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
          //  ProjectileID.Sets.Homing[projectile.type] = false;
            inertia = 30f;
            shoot = Mod.Find<ModProjectile>("WaterBoltMinionP").Type;
            shootSpeed = 6f;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void CheckActive()
        {
            Player player = Main.player[Projectile.owner];
            //MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(Mod, "MyPlayer");
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.WaterBoltMinion = false;
            }
            if (modPlayer.WaterBoltMinion)
            {
                Projectile.timeLeft = 2;
            }
        }

        public override void CreateDust()
        {
            Lighting.AddLight((int)(Projectile.Center.X / 16f), (int)(Projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }

        public override void SelectFrame()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 8)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 3;
            }
        }
    }
}