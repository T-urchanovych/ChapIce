using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;


namespace ChapIce
{
    class Hero:Character
    {
        public Hero()
        {
            name = "skull";
            spawnPosition = new Vector2f(600, 500);
            spriteStep = 0;
            size = new Vector2i(38, 54);
            startingPositionX = 13;
            yUp = 11;
            yLeft = 75;
            yDown = 140;
            yRight = 202;
            textureLength = 65;
            direction = Direction.down;
            speed = 6.5f;
            image = new Image("Images/skull.png");
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = spawnPosition;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX, yDown), size);
        }
        public Hero(List<GameObject> list)
        {
            this.list = list;
            spawnPosition = new Vector2f(600, 500);
            spriteStep = 0;
            size = new Vector2i(38, 54);
            startingPositionX = 13;
            yUp = 11;
            yLeft = 75;
            yDown = 140;
            yRight = 202;
            textureLength = 65;
            direction = Direction.down;
            speed = 6.5f;
            image = new Image("Images/skull.png");
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = spawnPosition;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX, yDown), size);
        }
        public void Movement(KeyEventArgs e)
        {
            float x = sprite.Position.X;
            float y = sprite.Position.Y;
            switch (e.Code)
            {
                case Keyboard.Key.W:
                    MoveUp(x, y);
                    break;
                case Keyboard.Key.A:
                    MoveLeft(x, y);
                    break;
                case Keyboard.Key.D:
                    MoveRight(x, y);
                    break;
                case Keyboard.Key.S:
                    MoveDown(x, y);
                    break;
                case Keyboard.Key.F:
                    Fireball fireball = new Fireball(sprite.Position);
                    fireball.direction = direction;
                    list.Add(fireball);
                    break;
            }
        }
        public override void OnCollisionReact(string name)
        {
            if (name == "levelZero") 
            {
                sprite.Color = Color.Red;
            }
        }
    }
}
