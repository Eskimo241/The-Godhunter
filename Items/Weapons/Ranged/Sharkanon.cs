using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheGodhunter.Projectiles;

namespace TheGodhunter.Items.Weapons.Ranged
{
    public class Sharkanon : ModItem
    {
        public int charge = 0;
        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 64;
            Item.height = 30;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 9;
            Item.rare = 8;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            //item.shoot = 134;
            Item.shootSpeed = 15f;
            //Item.shoot = ProjectileID.BombFish;
           // item.shoot = mod.ProjectileType("BombFishBomb");
            //Item.useAmmo = AmmoID.Rocket;
            Item.channel = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharkanon");
            Tooltip.SetDefault("Shoot bomb fishes, powerfull and dangerous");
 			
        }

      /*  public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Main.NewText(Language.GetTextValue(source.ToString()),109,36,255);
            
            if (charge >99)
            {Projectile.NewProjectile(source, position, velocity.RotatedBy(0.25f), type, damage, knockback, player.whoAmI, Main.MouseWorld.X);
            Projectile.NewProjectile(source, position, velocity.RotatedBy(-0.25f), type, damage, knockback, player.whoAmI, Main.MouseWorld.X);

            charge = 0;
            return true;
			}
            return false;
		}*/

        public override bool CanUseItem(Player player)
        {
            
            /*if (!player.channel && charge !<=0)
            {   
                var velocity = Vector2.Normalize(Main.MouseWorld - player.Center);
                if(charge <=15)
                {Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity, 519,48,1, player.whoAmI, Main.MouseWorld.X);}
                if(charge >=30)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(0.45f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(-0.45f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                }
                if (charge >=100)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(0.25f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(-0.25f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                }

                charge = 0;
                
            }*/
            
            return true;
        }
        public override void HoldItem(Player player)
        {
            if (player.channel && charge < 100) {
                charge ++;
            }
            else if(!player.channel && charge >10)
            {   
                var velocity = Vector2.Normalize(Main.MouseWorld - player.Center)*50;
                if(charge <=15)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity, 519,48,1, player.whoAmI, Main.MouseWorld.X);
                }
                if(charge >=30)
                {
                    Main.NewText(Language.GetTextValue("test1"),109,36,255);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(0.45f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(-0.45f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                }
                if (charge >=100)
                {
                    Main.NewText(Language.GetTextValue("test2"),109,36,255);
                    Main.NewText(Language.GetTextValue(velocity.Length().ToString()),109,36,255);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(0.25f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                    Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem),player.position, velocity.RotatedBy(-0.25f), 519,48,1, player.whoAmI, Main.MouseWorld.X);
                }

                charge = 0;
                
            }
        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-44, -5);
        }


    }
}