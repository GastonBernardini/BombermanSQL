using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class BombExplosion
    {
        private Bomb bomb;
        private bool exploded = false;
        public bool Exploded => exploded;
        private bool explosionFinished = false;
        public bool ExplosionFinished => explosionFinished;
        private float explosionTimer = 12;
        private float explosionTimeElapsed = 0;

        public BombExplosion(Bomb bomb)
        {
            this.bomb = bomb;
        }

        public void explosion()
        {
            exploded = true;
            explosionTimeElapsed++;
            if (explosionTimeElapsed < explosionTimer)
            {
                TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley] = 3;

                if (TileMap.Instance.Tiles1[bomb.Tilex + 1, bomb.Tiley] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex + 1, bomb.Tiley] = 3;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex - 1, bomb.Tiley] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex - 1, bomb.Tiley] = 3;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley + 1] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley + 1] = 3;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley - 1] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley - 1] = 3;

                }
            }
            else if (explosionTimeElapsed > explosionTimer)
            {
                TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley] = 0;


                if (TileMap.Instance.Tiles1[bomb.Tilex + 1, bomb.Tiley] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex + 1, bomb.Tiley] = 0;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex - 1, bomb.Tiley] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex - 1, bomb.Tiley] = 0;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley + 1] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley + 1] = 0;
                }

                if (TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley - 1] != 2)
                {
                    TileMap.Instance.Tiles1[bomb.Tilex, bomb.Tiley - 1] = 0;
                }

                explosionFinished = true;
            }
        }
        public void ResetBomb()
        {
            exploded = false;
            explosionFinished = false;
            explosionTimeElapsed = 0;
        }
    }
}