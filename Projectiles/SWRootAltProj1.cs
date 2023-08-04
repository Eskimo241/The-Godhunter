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
    public class SWRootAltProj1 : ModProjectile //First Proj = sword throw
    {

        private float BladeFrame = 0;
        private float TargetPoint = -1f;
        private bool collide = false;

        

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
            {
                TargetPoint = owner.position.Y - 300;
                Projectile.velocity.Y = -15; // we give it a little push
            }

            if (/*Projectile.position.Y >= TargetPoint && */!collide && Projectile.velocity.Y <0 )
            {
                
               // Projectile.velocity += new Vector2 (0,-1);
               Projectile.velocity.Y = Projectile.velocity.Y +  0.3f; //slow down like gravity
            }
            else
            {
                Projectile.ai[0]++;
                
                Projectile.velocity = Vector2.Zero;
                owner.Center = Projectile.Center;
                MyPlayer.oldpos.X = owner.position.X;

                
                if (collide) {
                    owner.AddBuff(ModContent.BuffType<OuchDebuff>(), 600);
                    
                    owner.Hurt(PlayerDeathReason.ByCustomReason (owner.name+ Language.GetTextValue("Mods.TheGodhunter.DeathReasons.HeadTrauma")), 10, 0, false, false, -1,false ,0 ,0 ,0);
                    //Maybe change the texture to make it like it is stuck to the roof ? Kill and create other projectile that falls and can hurt player for even more head trauma
                    MyPlayer.LockX = MyPlayer.LockY = -1;
                    Projectile.Kill();
                }
                else
                {
                    Projectile.velocity = Vector2.Zero;
                    if(Projectile.ai[0]>30)
                        {
                            Projectile.Kill();
                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(0,0), ProjectileType<SWRootAltProj2>(),0,0);
                        }
                
                    
                }
                
            }
        }




        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            collide = true;
            return false;
        }

    }
}