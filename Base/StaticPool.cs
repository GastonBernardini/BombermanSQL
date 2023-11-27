using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Xml;

namespace MyGame
{
    public class StaticPool
    {
        private List<Bomb> bombsInUse = new List<Bomb>();
        private List<Bomb> bombsAvailable = new List<Bomb>();

        public StaticPool(int cantidad) 
        { 
            for (int i = 0; i < cantidad; i++)
            {
                Bomb newBomb = new Bomb(new Vector2(0, 0));
                bombsAvailable.Add(newBomb);
                newBomb.OnExplode += RecycleBomb;

            }
        }

        public Bomb GetBomb()
        {
            Bomb bomb = null;

            if(bombsAvailable.Count > 0)
            {
                bomb = bombsAvailable[0];
                bombsAvailable.Remove(bomb);
                bombsInUse.Add(bomb);
            }

            return bomb;
        }

        public void AddBombSlot() 
        {
            Bomb newBomb = new Bomb(new Vector2(0, 0));
            bombsAvailable.Add(newBomb);
            newBomb.OnExplode += RecycleBomb;
        }

        public void RecycleBomb(Bomb bomb)
        {
            bombsInUse.Remove(bomb);
            bombsAvailable.Add(bomb);
        }

        public void PrintBombs()
        {
            Engine.Debug("Libres: " + bombsAvailable.Count);
            Engine.Debug("En uso" + bombsInUse.Count);
        }
    }
}