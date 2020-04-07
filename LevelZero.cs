using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ChapIce
{
    class LevelZero : Character
    {
        public LevelZero(Vector2f spawnPosition)
        {
            name = "levelZero";
            size = new Vector2i(43, 65);
            spriteStep = 0;
            startingPositionX = 18;
            this.spawnPosition = spawnPosition;
            yUp = 243;
            yDown = 14;
            speed = 0.2f;
            textureLength = 78;
            yLeft = 90;
            yRight = 168;
            image = new Image("Images/Hero.png");
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = spawnPosition;
            direction = Direction.left;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX, yUp), size);
        }
        public LevelZero(List<GameObject> list, Vector2f position, Direction startingDirection) : base(list)
        {
            this.list = list;
            size = new Vector2i(43, 65);
            spriteStep = 78;
            startingPositionX = 18;
            speed = 3;
            spawnPosition = new Vector2f(300, 250);
            yUp = 14;
            yDown = 243;
            yLeft = 90;
            yRight = 168;
            image = new Image("Images/Hero.png");
            texture = new Texture(image);
            sprite = new Sprite(texture);
            sprite.Position = spawnPosition;
            sprite.TextureRect = new IntRect(new Vector2i(startingPositionX, yUp), size);
        }
        public override void Draw(RenderWindow window)
        {
            RandomMove();
            Borders();
            base.Draw(window);
        }
    }
}
