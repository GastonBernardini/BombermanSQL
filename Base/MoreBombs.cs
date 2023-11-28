using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class MoreBombs : GameObject,  IPickupeable
    {
        private Animation morebombsAnimation;
        public MoreBombs (Vector2 pos) : base(pos)
        {
            CreateAnimations();
            currentAnimation = morebombsAnimation;
        }
        protected override void CreateAnimations()
        {
            List<IntPtr> morebombsTextures = new List<IntPtr>();
            for (int i = 0; i < 1; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bomb/AddBomb_{i}.png");
                morebombsTextures.Add(frame);
            }
            morebombsAnimation = new Animation("MoreBombs", morebombsTextures, 0.2f, false);
        }
        public override void Update()
        {

        }

        public override void Render()
        {
            renderer.Render(transform, currentAnimation);
        }
        public void Pickup(Character player)
        {
            Engine.Debug("¡Tienes una bomba extra!");
            player.bombPool.AddSlot(new Bomb(Vector2.Zero));
            player.bombPool.PrintObj();
            GameManager.Instance.levelController.gameObjectList.Remove(this);
        }
    }
}
