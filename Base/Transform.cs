using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Transform
    {
        private Vector2 position;
        private Vector2 scale;
        private Vector2 rotation;
        public Vector2 Position => position;
        public Vector2 Scale => scale;
        public Vector2 Rotation => rotation;

        public Transform(Vector2 position, Vector2 scale, Vector2 rotation)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }

        public void Translate(Vector2 direction, float speed)
        {
            position.x += direction.x * speed /* * Program.DeltaTime*/;
            position.y += direction.y * speed /* * Program.DeltaTime*/;
        }
        public void SetNewPosition(Vector2 newPos)
        {
            position.x = newPos.x;
            position.y = newPos.y;
        }

        public Vector2 PositionCenter()
        {

            return new Vector2(position.x + scale.x / 2, position.y + scale.y / 2);

        }
    }
}
