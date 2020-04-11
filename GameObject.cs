using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ChapIce
{
    class GameObject
    {
        public int life;
        public List<GameObject> list;
        public Vector2i size;
        public Image image;
        public Texture texture;
        public int count;
        public Sprite sprite;
        public bool IsAlive = true;
        public int index;
        public string name;
        public Clock clock = new Clock();
        public bool isCollide = false;

        public enum Direction { right = 1, left = 2, up = 3, down = 4 };
        public Direction direction;
        public GameObject()
        {
        }
        public virtual void Draw(RenderWindow window)
        {   
            window.Draw(sprite);
        }

        public Box GetBox()
        {
            Box result;
            result.bottom = size.Y + sprite.Position.Y;
            result.top = sprite.Position.Y;
            result.left = sprite.Position.X;
            result.right = size.X + sprite.Position.X;
            return result;
        }
        public void Collision(List<GameObject> gameObjects)
        {
            foreach (GameObject i in gameObjects)
            {
                if (i == this)
                    continue;
                
                if (GetBox().IsIntersectWith(i.GetBox()))
                {
                    OnCollisionReact(i);
                    i.OnCollisionReact(this);
                    break;
                }
            }
        }
        public virtual void OnCollisionReact(GameObject i)
        {
        }
        public float GeElapsedTime()
        {
            return clock.ElapsedTime.AsMicroseconds();
        }
    }
}
