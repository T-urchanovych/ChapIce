using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;

namespace ChapIce
{
    class Program
    {
        public static RenderWindow window = new RenderWindow(new VideoMode(1200, 800), "ChapIce");
        public static Logic logic = new Logic(window);
        static void Main()
        {
            window.Closed += WindowCloser;
            window.KeyPressed += WindowKeyPresser;
            window.Resized += NoResize;
            while (window.IsOpen)
            {
                logic.clock.Restart();
                window.DispatchEvents();
                window.Clear(Color.Black);
                logic.Check(window);
                window.Display();
                while (true)
                {
                    if (logic.clock.ElapsedTime.AsMilliseconds() >= 1 / 30 * 1000)
                        break;
                }
            }
        }

        private static void NoResize(object sender, SizeEventArgs e)
        {
            window.Size = new Vector2u(1200, 800);
        }
        private static void WindowKeyPresser(object sender, KeyEventArgs e)
        {
            logic.skull.Movement(e);
        }

        private static void WindowCloser(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
