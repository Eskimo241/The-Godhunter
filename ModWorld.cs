using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.GameContent;
using static Terraria.ModLoader.ModContent;
using Terraria.IO;
using TheGodhunter.NPCs.Boss.ZaraWE;

namespace TheGodhunter
{
    public class GHWorld : ModSystem
    {

        public static bool downedZWE = false;
        internal static int terraCheckpoint1 = 0;
        internal static int terraCheckpoint2 = 0;
        internal static int terraCheckpoint3 = 0;
        internal static int terraCheckpointS = 0;
        public static int ZWESpawnTimer;

        public override void OnWorldLoad()/* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */
        {
            downedZWE = false;
            terraCheckpoint1 = 0;
            terraCheckpoint2 = 0;
            terraCheckpoint3 = 0;
            terraCheckpointS = 0;
            ZWESpawnTimer=0;

        }

        public override void OnWorldUnload()
        {
            ZWESpawnTimer=0;
        }
       
       private void FixCheckpoints()
        {
            if (terraCheckpoint1 < 0)
            {
                terraCheckpoint1 = 0;
            }
            if (terraCheckpoint1 > 10)
            {
                terraCheckpoint1 = 10;
            }
            if (terraCheckpoint2 < 0)
            {
                terraCheckpoint2 = 0;
            }
            if (terraCheckpoint2 > 10)
            {
                terraCheckpoint2 = 10;
            }
            if (terraCheckpoint3 < 0)
            {
                terraCheckpoint3 = 0;
            }
            if (terraCheckpoint3 > 10)
            {
                terraCheckpoint3 = 10;
            }
            if (terraCheckpointS < 0)
            {
                terraCheckpointS = 0;
            }
            if (terraCheckpointS > 10)
            {
                terraCheckpointS = 10;
            }

        }





        private const int saveVersion = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Shiny Cool Ores I Swear", PleaseOre));



        }

        private void PleaseOre(GenerationProgress progress, GameConfiguration configuration)
        {progress.Message = "Create Shiny Ore";
                                                                                                                                                                                                                                         //Put your custom tile block name
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); k++)                                                                                                                                      //      |
                {                                                                                                                                                                                                                      //       |
                    WorldGen.TileRunner
                    (
                        WorldGen.genRand.Next(0, Main.maxTilesX), 
                        WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY),
                        (double)WorldGen.genRand.Next(5, 7), 
                        WorldGen.genRand.Next(3, 6), 
                        Mod.Find<ModTile>("AstraliteTileBlock").Type,
                        false, 0f, 0f,
                        false, 
                        true
                    );
                }
                }



        public override void PostUpdateEverything()
        {
            if(ZWESpawnTimer>0)
            {
                ZWE.UpdateZWESpawning();
            }
        }
    }
}

