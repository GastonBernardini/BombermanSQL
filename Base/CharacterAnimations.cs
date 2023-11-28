using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class CharacterAnimations
    {
        public Animation idleAnimation;
        public Animation rightAnimation;
        public Animation leftAnimation;
        public Animation upAnimation;
        public Animation downAnimation;
        public CharacterAnimations()
        {

        }

        public void CreateAnimations()
        {
                List<IntPtr> PlayerRightTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Right/B_Right{i}.png");
                    PlayerRightTextures.Add(frame);
                }
                rightAnimation = new Animation("WalkRight", PlayerRightTextures, 0.2f, true);

                List<IntPtr> PlayerLeftTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Left/B_Left{i}.png");
                    PlayerLeftTextures.Add(frame);
                }
                leftAnimation = new Animation("WalkLeft", PlayerLeftTextures, 0.2f, true);

                List<IntPtr> PlayerUpTextures = new List<IntPtr>();
                for (int i = 0; i < 5; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Up/B_Up{i}.png");
                    PlayerUpTextures.Add(frame);
                }
                upAnimation = new Animation("WalkUp", PlayerUpTextures, 0.2f, true);

                List<IntPtr> PlayerDownTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Down/B_Down{i}.png");
                    PlayerDownTextures.Add(frame);
                }
                downAnimation = new Animation("WalkDown", PlayerDownTextures, 0.2f, true);

                List<IntPtr> PlayerIdleTextures = new List<IntPtr>();
                for (int i = 0; i < 1; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Idle/B_Idle{i}.png");
                    PlayerIdleTextures.Add(frame);
                }
                idleAnimation = new Animation("WalkLeft", PlayerIdleTextures, 0.2f, true);
        }
    }
}