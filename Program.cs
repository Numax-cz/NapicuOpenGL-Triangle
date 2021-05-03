using System;
using NapicuOpenGL.Game;
using OpenTK.Windowing.Desktop;

namespace NapicuOpenGL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            using (Window game = new Window(GameWindowSettings.Default, NativeWindowSettings.Default))
            {
                game.Initialise();
                game.GameLoop();
            }
            
        }
    }
}
