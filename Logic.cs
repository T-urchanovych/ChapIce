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
        public Hero skull;
        public RenderWindow window;
        public List<GameObject> gameObjects;
        public List<GameObject> physicObjects;
        public Logic(RenderWindow window)
        {
            nulevichki = new List<LevelZero>();
            int quantityOfCharacters = random.Next(1, 15);
            for (int i = 0; i <= quantityOfCharacters; i++)
            {
                int x = random.Next(0, 1200);
                int y = random.Next(0, 1000);
                Vector2f randomSpawnPosition = new Vector2f(x, y);
                nulevichki.Add(new LevelZero(randomSpawnPosition));
            }
            gameObjects = new List<GameObject>();
            this.window = window;
            skull = new Hero(gameObjects);
            gameObjects.Add(skull);
            gameObjects.AddRange(nulevichki);

            physicObjects = new List<GameObject>();
            physicObjects.Add(skull);
            physicObjects.AddRange(nulevichki);
        }
        public void DrawAll(RenderWindow window)
        {
            foreach (GameObject i in gameObjects)
            {
                i.Collision(physicObjects);
                i.Draw(window);
            }
        }
    }
}
