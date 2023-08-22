using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheGodhunter.Projectiles;
//Oh dear god, why did I made such an awful looking weapon, I think the concept is cool, but I don't have the skills to do it properly yet
namespace TheGodhunter.Items.Weapons.Ranged
{
    public class Sharkanon : ModItem
    {
        public int charge = 0;
        private bool AmmoCons = true;
        private Vector2 DesiredRot;
        private int frameHeight = 34;
        private int frameCounter = 1;
        private Player? DrawOwner = null;

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 64;
            Item.height = 30;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 9;
            Item.rare = 8;
            //Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            //item.shoot = 134;
            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<SharkanonDrawProj>(); //NOTE: Maybe sould replace the Original BombFish so it doesn't explodes tiles. idk how to make explosions like that yet
           // item.shoot = mod.ProjectileType("BombFishBomb");
            Item.useAmmo = AmmoID.Rocket;
            Item.channel = true;
            Item.noUseGraphic = true;

        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sharkanon");
            // Tooltip.SetDefault("Shoot bomb fishes, powerfull and dangerous");
 			
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            //Manually sets when to consume ammo
            if(AmmoCons) {
                AmmoCons= false;
                return true;
            }
            return false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            //We want to shoot our own way, no need to use this method here

            Projectile.NewProjectile(source, position, new Vector2(0,0), Item.shoot,0,0, player.whoAmI, charge);

            return false;
		}


        public override void HoldItem(Player player)
        {
            if(DrawOwner == null) DrawOwner = player;
            DesiredRot = (Main.MouseWorld-player.Center);
            int velocity = 20;
            
            if (player.channel && charge < 100) {
                charge ++;
                switch(charge)
                {
                    case <15: 
                    frameCounter =1;
                    break;
                    case <100: 
                    frameCounter = 2;
                    break;
                    case 100:
                    frameCounter = 3;
                    break;
                }
            }
            if(!player.channel)
            {
                switch(charge) /*So that's easy to understand. I don't want to shoot using the Shoot Method, so it can actually shoot when releasing mousedown. So here we basically do all the 
                work ourselves. Like also setting when the item can consume ammo, otherwise it would drain hundreds to shoot once.*/
                {
                    case <15:
                    charge =0;
                    break;
                    case <100:
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, DesiredRot.SafeNormalize(Vector2.UnitX)*velocity , ProjectileID.BombFish, 0, 0, player.whoAmI, Main.MouseWorld.X);
                    charge =0;
                    AmmoCons= true;
                    break;
                    case 100:
                    AmmoCons= true;
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, (DesiredRot.SafeNormalize(Vector2.UnitX)*velocity).RotatedBy(0.25f) , ProjectileID.BombFish, 0, 0, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, (DesiredRot.SafeNormalize(Vector2.UnitX)*velocity).RotatedBy(-0.25f) , ProjectileID.BombFish, 0, 0, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, DesiredRot.SafeNormalize(Vector2.UnitX)*velocity , ProjectileID.BombFish, 0, 0, player.whoAmI, Main.MouseWorld.X);
                    charge =0;
                    break;
                }
                
            }

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-44, -5);
        }




    }
        public class SharkanonDrawProj : ModProjectile
        {

            private int frameHeight = 34;
            private int frameCounter = 1;
            private Vector2 direction = Vector2.One;
            private Vector2 DesiredRot;
            private Player owner => Main.player[Projectile.owner];
    
            public override void SetDefaults()
            {
                Projectile.width = 1;
                Projectile.height = 1;
                Projectile.friendly = true;
                Projectile.scale = 1f;
                Projectile.hostile = false;
                Projectile.tileCollide = true;
                Projectile.ignoreWater = true;
                Projectile.penetrate = 1;
                Projectile.alpha = 0;
                Projectile.timeLeft = 2;
            }

            public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
            {
                overPlayers.Add(index);
            }

            public override void AI()
            {

                
                DesiredRot = (Main.MouseWorld-owner.Center);
                
                
                switch(Projectile.ai[0])
                {
                    case <15: 
                    frameCounter =0;
                    break;
                    case <100:
                    frameCounter = 1;
                    break;
                    case 100:
                    frameCounter = 2;
                    break;
                }
                Main.NewText(frameCounter);
            }

            public override bool PreDraw(ref Color lightColor)
            {           
                Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;
                var frame = new Rectangle(0,frameHeight*frameCounter,tex.Width, frameHeight);
                SpriteEffects effects = SpriteEffects.None;
                float rot = direction.ToRotation();


                if (owner.direction != 1)
                {
                    effects = SpriteEffects.FlipVertically;
                    
                }
                Main.spriteBatch.Draw(tex, owner.Center - Main.screenPosition - new Vector2 (0,10)/*.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, direction.ToRotation()) - Main.screenPosition*/, frame, lightColor, DesiredRot.ToRotation(), new Vector2 (tex.Width/2,frameHeight/2), Projectile.scale, effects,0f);
                return false;
            
            }

    }
    
}

