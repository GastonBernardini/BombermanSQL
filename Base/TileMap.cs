using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class TileMap
    {
        int[,] tiles0 = new int[,]{
            {1,1,1,1,1,1,1,0,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,2,1,1,1,1,3,1,1,1,1,1}
        };



        void update()
        {
            for (int row = 0;  row < tiles0.GetLength(0); row++)
            {
                for (int col = 0; col < tiles0.GetLength(1); col++)
                {
                    
                }
            }
        }
    }
}
