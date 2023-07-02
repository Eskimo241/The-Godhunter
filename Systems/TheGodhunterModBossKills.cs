using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheGodhunter;

namespace TheGodhunter
{
    public class DownedBossSystem : ModSystem
	{
		public static bool downedZWE = false;


		public override void OnWorldLoad()
		{
			downedZWE = false;

		}

		public override void OnWorldUnload()
		{
			downedZWE = false;

		}
		public override void SaveWorldData(TagCompound tag)
		{
			if (downedZWE)
			{
				tag["downedZWE"] = true;
				
				
			}


			// if (downedOtherBoss) {
			//	tag["downedOtherBoss"] = true;
			// }
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedZWE = tag.ContainsKey("downedZWE");
        }


		public override void NetSend(BinaryWriter writer)
		{
			//Order of operations is important and has to match that of NetReceive
			var flags = new BitsByte();
			flags[0] = downedZWE;

			writer.Write(flags);

		}

		public override void NetReceive(BinaryReader reader)
		{

			BitsByte flags = reader.ReadByte();
			downedZWE = flags[0];


		}
	}
}

