using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class CharacterAnimations
    {
        private Character player;
        public Animation idleAnimation;
        public Animation rightAnimation;
        public Animation leftAnimation;
        public Animation upAnimation;
        public Animation downAnimation;

        public CharacterAnimations(Character player)
        {
            this.player = player;
        }

        public void CreateAnimations()
        {
            if (player.Id == 1)
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

            if (player.Id == 2)
            {
                List<IntPtr> Player2RightTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Right/B_Right{i}.png");
                    Player2RightTextures.Add(frame);
                }
                rightAnimation = new Animation("WalkRight", Player2RightTextures, 0.2f, true);

                List<IntPtr> Player2LeftTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Left/B_Left{i}.png");
                    Player2LeftTextures.Add(frame);
                }
                leftAnimation = new Animation("WalkLeft", Player2LeftTextures, 0.2f, true);

                List<IntPtr> Player2UpTextures = new List<IntPtr>();
                for (int i = 0; i < 5; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Up/B_Up{i}.png");
                    Player2UpTextures.Add(frame);
                }
                upAnimation = new Animation("WalkUp", Player2UpTextures, 0.2f, true);

                List<IntPtr> Player2DownTextures = new List<IntPtr>();
                for (int i = 0; i < 4; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Down/B_Down{i}.png");
                    Player2DownTextures.Add(frame);
                }
                downAnimation = new Animation("WalkDown", Player2DownTextures, 0.2f, true);

                List<IntPtr> Player2IdleTextures = new List<IntPtr>();
                for (int i = 0; i < 1; i++)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Player/B_Idle/B_Idle{i}.png");
                    Player2IdleTextures.Add(frame);
                }
                idleAnimation = new Animation("WalkLeft", Player2IdleTextures, 0.2f, true);
            }
        }
    }
}