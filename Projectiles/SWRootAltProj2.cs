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
    public class SWRootAltProj2 : ModProjectile
    {
       // public override string Texture => "TheGodhunter/Projectiles/emptyproj";
        private float BladeFrame = 0;
        private float TargetPoint = -1f;
        private bool colide = false;

        

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.scale = 5f;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.damage = 10;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 4;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (!owner.active || owner.dead|| owner.ghost)
            {
                Projectile.Kill();
                return;
            }

            if (TargetPoint == -1)
            {TargetPoint = owner.position.Y - 300;}

            if (Projectile.position.Y >= TargetPoint && !colide )
            {
                
                Projectile.velocity += new Vector2 (0,-1);
            }
            else
            {
                
                Projectile.velocity = Vector2.Zero;
                owner.position = Projectile.position - new Vector2(7.5f,1); //You may ask why the new Vector 2. This is to prevent teleporting into tiles, I have no idea why it is doing that. I had to find 7.5 the hard way °-°
                MyPlayer.oldpos.X = owner.position.X;
                MyPlayer.oldpos.Y = owner.position.Y ;
                MyPlayer.LockY = 60;
                
                if (colide) {
                    owner.AddBuff(ModContent.BuffType<OuchDebuff>(), 600);
                    
                    owner.Hurt(PlayerDeathReason.ByCustomReason (owner.name+ Language.GetTextValue("Mods.TheGodhunter.DeathReasons.HeadTrauma")), 10, 0, false, false, -1,false ,0 ,0 ,0);
                    MyPlayer.LockX = MyPlayer.LockY = 0;
                }


                Projectile.Kill();
                owner.noFallDmg = false;
            }
        }




        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            colide = true;
            return false;
        }

    }
}