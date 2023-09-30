﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame
{
    internal class TileMap
    {
        private IntPtr tile0 = Engine.LoadImage("assets/tile0.png");
        private IntPtr tile1 = Engine.LoadImage("assets/tile1.png");
        private IntPtr tile2 = Engine.LoadImage("assets/tile2.png");

        private int[,] tiles0 = new int[,]{
            {1,1,1,1,1,1,1,0,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,2,1,1,1,1,3,1,1,1,1,1}
        };

        private int[,] tiles1 = new int[,]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,1,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,1,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,2,0,2,0,2,0,2,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0}
        };

        private int tileSize;

        public TileMap(int tileSize)
        {
            this.tileSize = tileSize;
        }

        public void update()
        {
            for (int row = 0; row < tiles1.GetLength(0); row++)
            {
                for (int col = 0; col < tiles1.GetLength(1); col++)
                {
                    if (tiles1[row, col] == 0)
                    {
                        Engine.Draw(tile0, row * tileSize, col * tileSize);
                    }
                    if (tiles1[row, col] == 1)
                    {
                        Engine.Draw(tile1, row * tileSize, col * tileSize);
                    }
                    if (tiles1[row, col] == 2)
                    {
                        Engine.Draw(tile2, row * tileSize, col * tileSize);

                    }
                }
            }
        }
    }
}