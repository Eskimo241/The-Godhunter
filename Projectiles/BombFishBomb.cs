using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheGodhunter.Projectiles
{
	public class BombFishBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Bullet");
		}

		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;

			Projectile.aiStyle = 1;
			//aiType = ProjectileID.Bomb;

			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;

			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
		}

		/*public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height,
					61, projectile.velocity.X * 0.80f, projectile.velocity.Y * 0.75f);
		}*/

		public override void Kill (int timeLeft)
		{
			NPC.SpawnNPC();
		
		}

		/*public override void On (NPC target, int damage, float knockback, bool crit)
		{
			
			if (Main.rand.Next(2) == 0)
				target.AddBuff(ModContent.BuffType<BlightedFlames>(), 260, false);

			MyPlayer mp = Main.player[projectile.owner].GetSpiritPlayer();
			mp.PutridHits++;
			if (mp.putridSet && mp.PutridHits >= 4) {
				Projectile.NewProjectile(projectile.position, Vector2.Zero,
					ModContent.ProjectileType<CursedFlame>(), projectile.damage, 0f, projectile.owner);
				mp.PutridHits = 0;
			}*/
		}

	}

