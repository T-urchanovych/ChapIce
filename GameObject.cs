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
        public Vector2i size;
        protected Image image;
        protected Texture texture;
        public Sprite sprite;
        public string name;
        public List<GameObject> gameObjects;
        public bool isCollide = false;
        public float top;
        public float bottom;
        public float right;
        public float left;

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
            result.top = size.X;
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
                    OnCollisionReact(i.name);
                }
            }
        }
        public virtual void OnCollisionReact(string name)
        {

        }
    }
}
