using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheGodhunter.Items.Weapons         //The directory for your .cs and .png; Example: Mod Sources/TutorialMOD/Items
{
    public class AzesClaw : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aze's Claw");
		}
        public override void SetDefaults()
         {
            Item.damage = 23;     //The damage stat for the Weapon.
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;      //This defines if it does Melee damage and if its effected by Melee increasing Armor/Accessories.
            Item.scale = 2f;
            Item.width = 24;   //The size of the width of the hitbox in pixels.
            Item.height = 24;  //The size of the height of the hitbox in pixels.
            Item.useTime = 5;   //How fast the Weapon is used.
            Item.useAnimation = 5;     //How long the Weapon is used for.
            Item.useStyle = 1;            //The way your Weapon will be used, 1 is the regular sword swing for example
            Item.knockBack = 2;  //The knockback stat of your Weapon.
            Item.value = Item.buyPrice(0, 45, 0, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            Item.rare = 4;    //The color the title of your Weapon when hovering over it ingame
            Item.UseSound = SoundID.Item1;   //The sound played when using your Weapon
            Item.autoReuse = true;//Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            Item.crit = 46; 
            }
 
       /* public override void AddRecipes()
        {                                        //this is how to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GoldKing", 1);  //this is how to add an ingredient from Terraria,  so for crafting this item you need 1 Light's Bane   
            recipe.AddIngredient(null, "AstraliteIngot", 15);  
            recipe.AddIngredient(ItemID.ShadowScale, 15);         
            recipe.AddTile(TileID.Anvils);  //this is where to craft the item ,WorkBenches = all WorkBenches    Anvils = all anvils , MythrilAnvil = Mythril Anvil and Orichalcum Anvil, Furnaces = all furnaces , DemonAltar = Demon Altar and Crimson Altar , TinkerersWorkbench = Tinkerer's Workbench
            recipe.SetResult(this);
            recipe.AddRecipe();
               
            

                                 
        
        }*/

        		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add Onfire buff to the NPC for 1 second
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 600);
            target.AddBuff(BuffID.Poisoned, 600);
            target.AddBuff(BuffID.BrokenArmor, 600);
                }

    }
}
