using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;



namespace ChapIce
{
    class Fireball:GameObject
    {
        protected bool Collide = false;
        public Fireball(Vector2f position)
        {
            image = new Image("Images/Fireball.png");
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = position;
        }
        public void Fly()
        {
            float x = sprite.Position.X;
            float y = sprite.Position.Y;
           switch (direction)
           {
               case Direction.up:
                   sprite.Position = new Vector2f(x, y - 8);
                   break;
               case Direction.left:
                   sprite.Position = new Vector2f(x - 8, y);
                   break;
               case Direction.right:
                   sprite.Position = new Vector2f(x + 8, y);
                   break;
               case Direction.down:
                   sprite.Position = new Vector2f(x, y + 8);
               break;
           }
            
        }
        public override void Draw(RenderWindow window)
        {
            Fly();
            window.Draw(sprite);
        }
    }
}
