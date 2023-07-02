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
            Item.shoot = ProjectileID.BombFish;
           // item.shoot = mod.ProjectileType("BombFishBomb");
            Item.useAmmo = AmmoID.Rocket;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharkanon");
            Tooltip.SetDefault("Shoot bomb fishes, powerfull and dangerous");
 			
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, Main.MouseWorld.X);
			/*Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, -10, position + muzzleOffset, 0, -10))
			{
				position += muzzleOffset;
			}*/

			return true;
		}



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-44, -5);
        }


    }
}