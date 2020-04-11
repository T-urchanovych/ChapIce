using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ChapIce
{
    class Logic
    {
        private Random random = new Random();
        public List<LevelZero> nulevichki;
        public Clock clock = new Clock();
        public Font font;
        public Text time;
        public Texture texture;
        public Image image;
        public Sprite texture1;
        public Text end;
        public Text score;
        public Text life;
        public Hero skull;
        public RenderWindow window;
        public List<GameObject> gameObjects;
        public Logic(RenderWindow window)
        {
            gameObjects = new List<GameObject>();
            skull = new Hero(gameObjects);

            image = new Image("Images/heart.png");
            texture = new Texture(image);
            texture1 = new Sprite(texture);
            texture1.Position = new Vector2f(68, 45);
            font = new Font("IndieFlower-Regular.ttf");
            time = new Text(clock.ElapsedTime.ToString(), font, 25);
            time.Position = new Vector2f(0, 0);
            score = new Text(skull.count.ToString(), font, 25);
            score.Position = new Vector2f(1090, 0);
            life = new Text(skull.life.ToString(), font, 25);
            life.Position = new Vector2f(0, 35);
            end = new Text("Sadly, you have run out of lives : (", font, 50);
            end.Position = new Vector2f(250, 390);

            nulevichki = new List<LevelZero>();
            int quantityOfCharacters = random.Next(7, 15);
            this.window = window;
            gameObjects.Add(skull);
            for (int i = 0; i <= quantityOfCharacters; i++)
            {
                int x = random.Next(0, 1200);
                int y = random.Next(0, 800);
                Vector2f randomSpawnPosition = new Vector2f(x, y);
                gameObjects.Add(new LevelZero(randomSpawnPosition, gameObjects));
            }
        }
        public void Check(RenderWindow window)
        {
            if (skull.life <= 0)
            {
                window.Clear(Color.Black);
                window.Draw(end);
                window.Display();
                while (true)
                {
                    window.DispatchEvents();
                }
            }
            else
            {
                if (gameObjects.Count == 1)
                    gameObjects.Add(new Boss(new Vector2f(10, 20), gameObjects));
                DrawAll(window);
            }
        }
        public void DrawAll(RenderWindow window)
        {
            window.Draw(texture1);
            for (int j = 0; j < gameObjects.Count; j++)
            {
                GameObject i = gameObjects[j];
                time.DisplayedString = Math.Round(clock.ElapsedTime.AsSeconds()).ToString() + " s";
                window.Draw(time);
                score.DisplayedString = "Score: " + skull.count.ToString();
                window.Draw(score);
                life.DisplayedString = "Life: " + skull.life.ToString();
                window.Draw(life);
                if (i.IsAlive)
                {
                    i.Collision(gameObjects);
                    i.Draw(window);
                }
                else
                {
                    gameObjects.Remove(i);
                    break;
                }
            }
        }

    }
}
