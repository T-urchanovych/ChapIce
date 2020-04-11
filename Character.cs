using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;


namespace ChapIce
{
    class Character : GameObject
    {
        protected int startingPositionX;
        public int textureLength;
        public int stepCounter;
        public int spriteStep;
        private Random random = new Random();

        //------------------------For speed-----------------------------//
        public float speed;

        //----------------------------res--------------------------------//
        public Vector2f spawnPosition;
        public int yUp;
        public int yDown;
        public int yLeft;
        public int yRight;
        public float x;
        public float y;
        public Character()
        {
        }
        public Character(List<GameObject> list)
        {
            this.list = list;
            spriteStep = 0;
            sprite.Position = spawnPosition;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX, yUp), size);
        }
        public void Movement()
        {
            x = sprite.Position.X;
            y = sprite.Position.Y;
            switch (direction)
            {
                case Direction.left:
                    MoveLeft(x, y);
                    break;
                case Direction.up:
                    MoveUp(x, y);
                    break;
                case Direction.down:
                    MoveDown(x, y);
                    break;
                case Direction.right:
                    MoveRight(x, y);
                    break;
            }
            stepCounter++;
        }
        protected void MoveUp(float x, float y)
        {
            sprite.Position = new Vector2f(x, y - speed);
            if (spriteStep >= image.Size.X)
                spriteStep = 0;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, yUp), size);
            spriteStep += textureLength;
            direction = Direction.up;
        }
        protected void MoveDown(float x, float y)
        {
            sprite.Position = new Vector2f(x, y + speed);
            if (spriteStep >= image.Size.X)
                spriteStep = 0;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, yDown), size);
            spriteStep += textureLength;
            direction = Direction.down;
        }
        protected void MoveRight(float x, float y)
        {
            sprite.Position = new Vector2f(x + speed, y);
            if (spriteStep >= image.Size.X)
                spriteStep = 0;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, yRight), size);
            spriteStep += textureLength;
            direction = Direction.right;
        }
        protected void MoveLeft(float x, float y)
        {
            sprite.Position = new Vector2f(x - speed, y);
            if (spriteStep >= image.Size.X)
                spriteStep = 0;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, yLeft), size);
            spriteStep += textureLength;
            direction = Direction.left;
        }
        public void RandomMove()
        {
            int m = random.Next(1, 5);
            Movement();
            if (stepCounter % 1000 == 0)
            {
                switch (m)
                {
                    case 1:
                        direction = Direction.right;
                        break;
                    case 2:
                        direction = Direction.left;
                        break;
                    case 3:
                        direction = Direction.up;
                        break;
                    case 4:
                        direction = Direction.down;
                        break;
                }
            }
        }
        public void Borders()
        {
            if (sprite.Position.Y + size.X >= 796)
                direction = Direction.up;
            else if (sprite.Position.X >= 1160)
                direction = Direction.left;
            else if (sprite.Position.X <= 0)
                direction = Direction.right;
            else if (sprite.Position.Y <= 45)
                direction = Direction.down;
        }
        public void RestInPeace()
        {
            IsAlive = false;
            if (random.Next(0, 10) == 1)
                list.Add(new Food(sprite.Position, true));
            else list.Add(new Food(sprite.Position, false));
        }
        public void TurnRed()
        {
            if (sprite.Color.R + 35 <= 255)
                sprite.Color = new Color(Convert.ToByte(sprite.Color.R + 35), sprite.Color.G, sprite.Color.B);
            if (sprite.Color.B - 35 >= 0)
                sprite.Color = new Color(sprite.Color.R, sprite.Color.G, Convert.ToByte(sprite.Color.B - 35));
            if (sprite.Color.G - 35 >= 0)
                sprite.Color = new Color(sprite.Color.R, Convert.ToByte(sprite.Color.G - 35), sprite.Color.B);
        }
    }
}
