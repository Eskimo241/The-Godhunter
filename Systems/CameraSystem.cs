using System;
using Terraria.Graphics.CameraModifiers;
using Terraria;
using Terraria.ModLoader;
using TheGodhunter;
using System.Collections.Generic;

namespace TheGodhunter
{
    public class CameraSystem : ModSystem
    {
        public static int camshake = 0;

        public static int shakeType =0;
        private  Dictionary<int, float> shakeValues = new Dictionary <int, float>(){
            {0, 15f},
            {1, 20f},
            {2, 30f},
            {3, 150f}
        };

        public override void ModifyScreenPosition()
        {
            if (camshake >0) 
            {
                camshake--;
            }
            else
            {
                shakeType = 0;
            }
            float mult = Main.screenWidth/2048f * 1.2f;
            Main.instance.CameraModifiers.Add(new PunchCameraModifier(Main.LocalPlayer.position, Main.rand.NextFloat(3.14f).ToRotationVector2(), camshake * mult, shakeValues[shakeType], 30, 2000, "CamShakeTest"));
        }

        public override void OnWorldLoad()
        {
            camshake = 0;
        }
    }
}