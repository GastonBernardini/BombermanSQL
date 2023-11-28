using System;
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
        private static TileMap instance;

        public static TileMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TileMap();
                }

                return instance;
            }
        }

        private IntPtr tile0 = Engine.LoadImage("assets/tile0.png"); //pasto
        private IntPtr tile1 = Engine.LoadImage("assets/tile1.png"); //pared destruible
        private IntPtr tile2 = Engine.LoadImage("assets/tile2.png"); //pared indestructible
        private IntPtr tile3 = Engine.LoadImage("assets/explosion.png"); //explosion
        private int currentDestroyableBuildings = 1;

        public int CurrentDestroyableBuildings => currentDestroyableBuildings;

        private int[,] tiles1 = new int[,]{
            {2,2,2,2,2,2,2,2,2,2,2,2,2},
            {2,0,0,1,0,1,0,0,0,0,0,0,2},
            {2,0,2,0,2,0,2,0,2,1,2,0,2},
            {2,1,1,0,0,1,0,0,0,0,0,0,2},
            {2,0,2,1,2,0,2,0,2,1,2,0,2},
            {2,1,1,0,0,1,0,0,0,1,0,1,2},
            {2,1,2,0,2,0,2,0,2,0,2,0,2},
            {2,0,1,0,0,1,0,1,0,1,0,1,2},
            {2,1,2,0,2,0,2,1,2,1,2,0,2},
            {2,0,1,0,0,1,0,0,0,0,1,0,2},
            {2,0,2,0,2,0,2,0,2,1,2,1,2},
            {2,0,0,0,1,1,1,1,0,0,0,1,2},
            {2,1,2,1,2,0,2,0,2,0,2,0,2},
            {2,0,0,0,0,1,0,1,0,1,0,0,2},
            {2,2,2,2,2,2,2,2,2,2,2,2,2},
        };

        public int[,] Tiles1
        {
            get
            {
                return tiles1;
            }
            set
            {
                tiles1 = value;
            }
        }

        private int tileSize = 75;

        public int TileSize => tileSize;

        public void Render()
        {
            for (int row = 0; row < tiles1.GetLength(0); row++)
            {
                for (int col = 0; col < tiles1.GetLength(1); col++)
                {
                    if (tiles1[row, col] == 0 || tiles1[row, col] == 4 )
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
                    if (tiles1[row, col] == 3)
                    {
                        Engine.Draw(tile3, row * tileSize, col * tileSize);
                    }
                }
            }
        }

        public void Update()
        {
            currentDestroyableBuildings = 0;
            for (int row = 0; row < tiles1.GetLength(0); row++)
            {
                for (int col = 0; col < tiles1.GetLength(1); col++)
                {
                    if (tiles1[row, col] == 1)
                    {
                        currentDestroyableBuildings++;
                    }
                    
                }
            }
        }
    }
}
