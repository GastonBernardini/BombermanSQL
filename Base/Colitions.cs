using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Colitions
    {
        private Character player = Program.player;
        private bool isCollidingRight = false;
        private bool isCollidingLeft = false;
        private bool isCollidingUp = false;
        private bool isCollidingDown = false;

        public bool IsCollidingRight => isCollidingRight;
        public bool IsCollidingLeft => isCollidingLeft;
        public bool IsCollidingUp => isCollidingUp;
        public bool IsCollidingDown => isCollidingDown;


        private void IsColliding()
        {
            if ( TileMap.Instance.Tiles1[player.TileX +1, player.TileY] != 0 ) 
            { 
                isCollidingRight = true;
                Console.WriteLine("colisiona derecha");
            }

        }

    }
}
