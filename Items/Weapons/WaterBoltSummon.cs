using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheGodhunter.Items.Weapons
{  
    public class WaterBoltSummon : ModItem
    {
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Enchanted Water Stone");
			// Tooltip.SetDefault("Contain the power of a Water Bolt");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
        public override void SetDefaults()
        {

            Item.damage = 19;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 20;
            Item.width = 26;
            Item.height = 28;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 4, 50, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item44;
            Item.buffType = Mod.Find<ModBuff>("WaterBoltMinBu").Type;
            Item.shoot = Mod.Find<ModProjectile>("WaterBoltMinion").Type;
            Item.shootSpeed = 7f;
            Item.buffTime = 36000;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return true;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WaterBolt, 1);
            recipe.AddIngredient(null, "EmptyEnchentementRune", 1);   
            recipe.AddTile (TileID.AlchemyTable);
            recipe.Register();
        }
    }
}