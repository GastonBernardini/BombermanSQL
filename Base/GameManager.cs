using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameManager
    {
        private static GameManager instance;
        private int gameStatus = 0; //0 inicio, 1 juego, 2 victoria, 3 derrota
        private IntPtr mainMenuScreen = Engine.LoadImage("assets/MainMenu.png");
        private IntPtr winScreen = Engine.LoadImage("assets/Win.png");
        private IntPtr winScreen2 = Engine.LoadImage("assets/Win_01.png");
        private IntPtr gameOverScreen = Engine.LoadImage("assets/GameOver.png");
        private IntPtr gameOverScreen2 = Engine.LoadImage("assets/GameOver_01.png");
        public LevelController levelController;
        private Character player;
        private Character player2;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public void Initialize()
        {
            Engine.Initialize();
            levelController = new LevelController();
            levelController.Initialization();
        }

        public void Update()
        {
            //musicPlayer.Play();
            switch (gameStatus)
            {
                case 0:
                    if (Engine.KeyPress(Engine.KEY_C))
                    {
                        gameStatus = 1;
                    }
                    break;
                case 1:
                    levelController.Update();
                    break;
                case 2:
                    //  Program.Update();
                    break;
                case 3:

                    //   Program.Update();
                    break;
            }

        }

        public void ChangeGameStatus(int gs)
        {
            gameStatus = gs;
        }

        public void Render()
        {
            Engine.Clear();
            switch (gameStatus)
            {
                case 0:
                    Engine.Draw(mainMenuScreen, 0, 0);
                    break;
                case 1:
                    levelController.Render();
                    break;
                case 2:
                    Engine.Draw(winScreen, 0, 0);
                    break;
                case 3:
                    Engine.Draw(gameOverScreen, 0, 0);
                    break;
                case 4:
                    Engine.Draw (winScreen2, 0, 0);
                    break;
                case 5:
                    Engine.Draw (gameOverScreen2, 0, 0);
                    break;
            }
            Engine.Show();
        }
    }
}
