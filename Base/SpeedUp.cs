using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class SpeedUp : GameObject, IsPickupeable
    {
        private Animation speedAnimation;
        public SpeedUp(Vector2 pos) : base(pos)
        {

        }
        protected override void CreateAnimations()
        {
            List<IntPtr> speedTextures = new List<IntPtr>();
            for (int i = 0; i <= 1; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/speed_{i}.png");
                speedTextures.Add(frame);
            }
            speedAnimation = new Animation("Morespeed", speedTextures, 0.2f, false);
        }
        public override void Update()
        {

        }

        public override void Render()
        {

        }
        public void Pickup()
        {
            Engine.Debug("¡Tienes mas velocidad de movimiento!");
            GameManager.Instance.levelController.gameObjectList.Remove(this);
        }
    }






}

