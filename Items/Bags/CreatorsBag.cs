/*using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using TheGodhunter.Items.Weapons;

namespace TheGodhunter.Items.Bags
{
    public class CreatorsBag :ModItem
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}\nWill be the bag of the last Boss so it contain cheat items");
            
            ItemID.Sets.BossBag[Type] = true;

            
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
        }
        public override bool CanRightClick(){
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemType<Extinction>(), 1));
          / itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemType<ConvectiveWandererMask>(), 7));
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(NPCType<ConvectiveWanderer>()));

            itemLoot.Add(ItemDropRule.Common(ItemType<WandererPlating>(), 1, 7, 10));
            itemLoot.Add(ItemDropRule.Common(ItemType<MantellarOre>(), 1, 50, 80));
            itemLoot.Add(ItemDropRule.Common(ItemType<WormSpewer>(), 10));
        }

        }
       public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Type].Value;
            Rectangle frame = texture.Frame();

            Vector2 vector = frame.Size() / 2f;
            Vector2 value = new Vector2((float)(Item.width / 2) - vector.X, (float)(Item.height - frame.Height));
            Vector2 vector2 = Item.position - Main.screenPosition + vector + value;

            float num = Item.velocity.X * 0.2f;

            float num7 = (float)Item.timeSinceItemSpawned / 240f + Main.GlobalTimeWrappedHourly * 0.04f;
            float globalTimeWrappedHourly = Main.GlobalTimeWrappedHourly;
            globalTimeWrappedHourly %= 4f;
            globalTimeWrappedHourly /= 2f;
            if (globalTimeWrappedHourly >= 1f)
            {
                globalTimeWrappedHourly = 2f - globalTimeWrappedHourly;
            }
            globalTimeWrappedHourly = globalTimeWrappedHourly * 0.5f + 0.5f;
            for (float num8 = 0f; num8 < 1f; num8 += 0.25f)
            {
                spriteBatch.Draw(texture, vector2 + Utils.RotatedBy(new Vector2(0f, 8f), (num8 + num7) * ((float)Math.PI * 2f)) * globalTimeWrappedHourly, frame, new Color(90, 70, 255, 50), num, vector, scale, (SpriteEffects)0, 0f);
            }
            for (float num9 = 0f; num9 < 1f; num9 += 0.34f)
            {
                spriteBatch.Draw(texture, vector2 + Utils.RotatedBy(new Vector2(0f, 4f), (num9 + num7) * ((float)Math.PI * 2f)) * globalTimeWrappedHourly, frame, new Color(140, 120, 255, 77), num, vector, scale, (SpriteEffects)0, 0f);
            }
            return true;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            Lighting.AddLight((int)((Item.position.X + (float)Item.width) / 16f), (int)((Item.position.Y + (float)(Item.height / 2)) / 16f), 0.4f, 0.4f, 0.4f);
            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Dust dust2 = Dust.NewDustPerfect(Item.Center + new Vector2(0f, (float)Item.height * -0.1f) + Main.rand.NextVector2CircularEdge((float)Item.width * 0.6f, (float)Item.height * 0.6f) * (0.3f + Main.rand.NextFloat() * 0.5f), 279, (Vector2?)new Vector2(0f, (0f - Main.rand.NextFloat()) * 0.3f - 1.5f), 127, default(Color), 1f);
                dust2.scale = 0.5f;
                dust2.fadeIn = 1.1f;
                dust2.noGravity = true;
                dust2.noLight = true;
                dust2.alpha = 0;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Lerp(lightColor, Color.White, 0.4f);
        }
    }
}

*/