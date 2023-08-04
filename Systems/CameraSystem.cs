using System;
using Terraria.Graphics.CameraModifiers;
using Terraria;
using Terraria.ModLoader;
using TheGodhunter;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

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

        public static void CamReset()
        {
            camshake = 0;
        }
    }

    internal class PanSystem : ICameraModifier
    {
        public Func<Vector2, Vector2, float, Vector2> EaseFunction = Vector2.SmoothStep;

		public int MovementDuration = 0;
		public int Timer = 0;
		public Vector2 Target = new(0, 0);
		public bool Returning = false;

		public string UniqueIdentity => "TGH Panning";

		public bool Finished => false;

		public void PassiveUpdate()
		{
			if (MovementDuration > 0 && Target != Vector2.Zero)
			{
				if (Timer < MovementDuration)
					Timer++;
			}
		}

		public void Update(ref CameraInfo cameraPosition)
		{
			if (MovementDuration > 0 && Target != Vector2.Zero)
			{
				var offset = new Vector2(-Main.screenWidth / 2f, -Main.screenHeight / 2f);

				if (Returning)
					cameraPosition.CameraPosition = EaseFunction(Target + offset, cameraPosition.OriginalCameraCenter + offset, Timer / (float)MovementDuration);
				else
					cameraPosition.CameraPosition = EaseFunction(cameraPosition.OriginalCameraCenter + offset, Target + offset, Timer / (float)MovementDuration);
			}
		}

		public void Reset()
		{
			MovementDuration = 0;
			Target = Vector2.Zero;
		}

    }
}