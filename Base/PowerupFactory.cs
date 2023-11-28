using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Powerupfactory
    {
        public static IPickupeable CreatePickupeable(Vector2 position, int id)
        {
            switch (id)
            {
                case 1:
                    return new MoreBombs(position);
                case 2:
                    return new SpeedUp(position);
            }
            return null;
        }
    }
}
