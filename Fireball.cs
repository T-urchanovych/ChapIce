using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;



namespace ChapIce
{
    class Fireball : GameObject
    {
        public int damage = 1;
        protected bool Collide = false;
        public Fireball(Vector2f position, List<GameObject> list)
        {
            this.list = list;
            name = "bullet";
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
                    sprite.Position = new Vector2f(x, y - 5.5f);
                    break;
                case Direction.left:
                    sprite.Position = new Vector2f(x - 5.5f, y);
                    break;
                case Direction.right:
                    sprite.Position = new Vector2f(x + 5.5f, y);
                    break;
                case Direction.down:
                    sprite.Position = new Vector2f(x, y + 5.5f);
                    break;
            }

        }
        public override void Draw(RenderWindow window)
        {
            Borders();
            Fly();
            window.Draw(sprite);
        }
        public override void OnCollisionReact(GameObject i)
        {
            if (i.name != "skull")
                IsAlive = false;
            if (i.name == "levelZero" || i.name == "levelOne" || i.name == "Zelenskiy")
            {
                list[0].count++;
                i.life -= damage;
                if (i.life <= 0)
                    ((Character)i).RestInPeace();
                ((Character)i).TurnRed();
                if (i.name == "Zelenskiy")
                    if (i.life <= 0)
                        this.count += 200;
            }
        }
        public void Borders()
        {
            if (sprite.Position.Y + size.X >= 796)
                list.Remove(this);
            else if (sprite.Position.X >= 1160)
                list.Remove(this);
            else if (sprite.Position.X <= 0)
                list.Remove(this);
            else if (sprite.Position.Y <= 45)
                list.Remove(this);
        }
    }
}
