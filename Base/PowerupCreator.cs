using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Xml;

namespace MyGame
{
    public class PowerupCreator
    {
        private float frequency;
        private float lastPowerup;
        public PowerupCreator(float frequency) 
        {
            this.frequency = frequency;
        }

        public void Update()
        {
            lastPowerup += GameManager.Instance.levelController.DeltaTime;
            if (lastPowerup > frequency) 
            {
                tryCreatePowerup();
                lastPowerup = 0;
            }
        }

        private void tryCreatePowerup()
        {
            Random rnd = new Random();
            int roll = rnd.Next(2);
            Random rndPos = new Random();
            int rollPos = rndPos.Next(1,5);
            Random rndType = new Random();
            int rollType = rndType.Next(1, 3);
            if (roll == 1)
            {
                Engine.Debug("¡Se logró crear un powerup!");
                switch (rollPos)
                {
                    case 1:
                        GameManager.Instance.levelController.gameObjectList.Add(Powerupfactory.CreatePickupeable(new Vector2(225, 225), rollType) as GameObject);
                        break;
                    case 2:
                        GameManager.Instance.levelController.gameObjectList.Add(Powerupfactory.CreatePickupeable(new Vector2(825, 225), rollType) as GameObject);
                        break;
                    case 3:
                        GameManager.Instance.levelController.gameObjectList.Add(Powerupfactory.CreatePickupeable(new Vector2(225, 675), rollType) as GameObject);
                        break;
                    case 4:
                        GameManager.Instance.levelController.gameObjectList.Add(Powerupfactory.CreatePickupeable(new Vector2(825, 675), rollType) as GameObject);
                        break;
                }
            }
            else
            {
                Engine.Debug("Se intentó crear un powerup");
            }
        }


    }
}