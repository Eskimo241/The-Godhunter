using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using TheGodhunter;
namespace TheGodhunter.Items.Armor.GodhunterArmor
{
	
	[AutoloadEquip(EquipType.Body)]
	public class GodsHunterBreastplate : ModItem
	{		
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("God's Hunter  Breastplate");
			//Tooltip.SetDefault("+20 max mana and +1 max minions");
			this.SetResearch(1);		
			}
        	public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Master;
			Item.defense = 430;
		}

		public override void UpdateEquip(Player player) {
			
			player.statManaMax2 += 20;
			player.maxMinions++;
		}


	}
	[AutoloadEquip(EquipType.Legs)]
	public class GodsHunterLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("5% increased movement speed");
			this.SetResearch(1);
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Master;
			Item.defense = 400;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.50f;

			

		}


	}
	[AutoloadEquip(EquipType.Head)]
	public class GodsHunterHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("sd");
			this.SetResearch(1);
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Master;
			Item.defense = 430;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<GodsHunterBreastplate>() && legs.type == ItemType<GodsHunterLeggings>();
		}

		private int HealthTimer;
		private int RegenTimer; 
		private int HpBoons;
		public bool BaseHpSet;
		public int BaseHp;
		
		

		public override void UpdateArmorSet(Player player) {
			

			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Venom] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.OgreSpit] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.WitheredArmor] = true;
			player.buffImmune[BuffID.WitheredWeapon] = true;
			player.buffImmune[BuffID.Horrified] = true;
			player.buffImmune[BuffID.TheTongue] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.Frostburn] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Webbed] = true;
			player.buffImmune[BuffID.Stoned] = true;
			player.buffImmune[BuffID.VortexDebuff] = true;
			player.buffImmune[BuffID.Obstructed] = true;
			player.buffImmune[BuffID.Electrified] = true;
			player.buffImmune[BuffID.Rabies] = true;
			player.buffImmune[BuffID.MoonLeech] = true;
			player.buffImmune[BuffID.BetsysCurse] = true;
			player.buffImmune[BuffID.ShadowFlame] = true;

			player.buffImmune[BuffID.ManaSickness] = true;
			player.buffImmune[BuffID.PotionSickness] = true;
			player.buffImmune[BuffID.ChaosState] = true;
			player.buffImmune[BuffID.Suffocation] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.buffImmune[BuffID.Lovestruck] = true;
			player.buffImmune[BuffID.Stinky] = true;
			player.buffImmune[BuffID.WindPushed] = true;
			player.buffImmune[BuffID.NoBuilding] = true;
			player.noFallDmg = true;

		if(BaseHpSet == false)
		{
			

			BaseHp=player.statLifeMax;
			BaseHpSet = true;
			
		}
		

		switch (MyPlayer.WritersRule){
		case 0:
		{
			HealthTimer ++;
			RegenTimer ++;
				if(player.statLife<player.statLifeMax)
				{
					if(RegenTimer>60)
					{
						RegenTimer =0;
						player.statLife+= (player.statLifeMax-player.statLife)/4 ; 
						
						if (player.statLife/player.statLifeMax<0.9)
						{
							player.statLife = player.statLifeMax;
						}
					}

					if(HealthTimer>150)
					{
						HealthTimer=0;
						HpBoons+=1;
						player.statLifeMax = BaseHp + HpBoons;
						
					}
				}	

		}	
		 break;
		case 1:
		{
			HealthTimer ++;
			RegenTimer ++;
				if(player.statLife<player.statLifeMax)
				{
					if(RegenTimer>60)
					{
						RegenTimer =0;
						player.statLife+= (player.statLifeMax-player.statLife)/4 ; 
						
						if (player.statLife/player.statLifeMax<0.9)
						{
							player.statLife = player.statLifeMax;
						}
					}

					if(HealthTimer>150)
					{
						HealthTimer=0;
						HpBoons+=1;
						player.statLifeMax2 = BaseHp + HpBoons;
						
					}
				}	
		}	
		 break;
		}



			


		

			
			


			player.setBonus = Language.GetTextValue(("Mods.TheGodhunter.ArmorSetBonus."+ Name) + MyPlayer.WritersRule + "\nBaseHp: "+ BaseHp.ToString() + "\nHpBoons: "+HpBoons.ToString() +"\nBaseHpSet?: "+BaseHpSet.ToString()+"\nModeId:"+MyPlayer.WritersRule.ToString()+"\nTTT");
			//player.GetDamage(DamageClass.Generic) += 50f;
			//player.lifeRegen = 9000;


		}

	}
}