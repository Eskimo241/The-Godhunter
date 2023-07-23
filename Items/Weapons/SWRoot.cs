using Terraria.Audio;


using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;
using Terraria.Utilities;
using Terraria.Localization;
using TheGodhunter.Projectiles;

namespace TheGodhunter.Items.Weapons
{
    public class SWRoot: ModItem {
        private int atkCycle = 0;

        public override void SetStaticDefaults()
        {
            this.SetResearch(1);
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.damage = 100;
            Item.crit = 10;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Expert;
            Item.shoot = ModContent.ProjectileType<SWRootAltProj1>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine Toolt = tooltips.FirstOrDefault(x => x.Name =="Damage"&& x.Mod == "Terraria");
            if(Toolt != null) Toolt.OverrideColor = new Color (255 - Main.DiscoR,255 - Main.DiscoG,255-Main.DiscoB);

            if(!ItemSlot.ShiftInUse) {
                string description = Language.GetTextValue("Mods.TheGodhunter.SWRootTT1");
                tooltips.Add(new TooltipLine(Mod, "test", description));
            }
            else
            {
               string description = Language.GetTextValue("Mods.TheGodhunter.SWRootTT2");
            tooltips.Add(new TooltipLine(Mod, "test", description)); 
            }
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2 )
            {
                Projectile.NewProjectile(source, player.Center, new Vector2 (0,0), ProjectileType<SWRootAltProj1>(), 0,0, player.whoAmI);
                player.noFallDmg = true;
                MyPlayer.LockX = 60;
                MyPlayer.olddir = player.direction;
                MyPlayer.oldpos.X = player.position.X;
                Main.NewText(source);
            }
            else
            {
                Vector2 ShootVel = Vector2.Normalize(Main.MouseWorld - player.Center);
                switch (atkCycle){
                    case 0 :
                        Projectile.NewProjectile(source, player.Center,new Vector2 (0,-1), ModContent.ProjectileType<SWRootAltProj1>(),1,0, player.whoAmI );
                        break;
                    
                    
                }
            }
            return false;
        }

    }

}