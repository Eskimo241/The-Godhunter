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
    public class SWRootAltProj1 : ModProjectile
    {
       // public override string Texture => "TheGodhunter/Projectiles/emptyproj";
        private float BladeFrame = 0;
        private float TargetPoint = -1f;
        private bool colide = false;

        

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.width = 4;
            Projectile.height = 4;
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
            {TargetPoint = owner.position.Y - 300;
            Projectile.velocity.Y = -15;}

            if (/*Projectile.position.Y >= TargetPoint && */!colide && Projectile.velocity.Y <0 )
            {
                
               // Projectile.velocity += new Vector2 (0,-1);
               Projectile.velocity.Y = Projectile.velocity.Y +  0.3f;
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
                //Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(0,0), ProjectileType<SWRootAltProj2>(),10,0);
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