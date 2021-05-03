using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NapicuOpenGL.Game
{
    public class Window : GameWindow
    {
        public bool Running { get; private set; }
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        { 

        }

        public bool Initialise()
        {
            Running = false;
            if (InitialiseOpenGL())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InitialiseOpenGL()
        {
            GLFWBindingsContext bin = new GLFWBindingsContext();
            GL.LoadBindings(bin);
            if (GLFW.Init())
            {
                Console.WriteLine("[SUCCES] Úspěšně inicializován OpenGL");
                return true;
            }
            else
            {
                Console.WriteLine("[ERROR] Úspěšně inicializován OpenGL");
                return false;
            }  
        }

        public void GameLoop()
        {
            if(!Running)
            {
                Running = true;
                Console.WriteLine("[SUCCES] Hra běží");
                base.Run();
            }
        }






        float[] vertices = new float[]
        {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
             0.5f, -0.5f, 0.0f, //Bottom-right vertex
             0.0f,  0.5f, 0.0f  //Top vertex
        };

        int vao;
        int vbo;



        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            //Barva Pozadí
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0.2f, 0.2f, 0.8f, 1.0f);

            GL.Viewport(0, 0, Size.X, Size.Y);


            GL.BindVertexArray(vao);


            GL.DrawArrays((PrimitiveType)BeginMode.Triangles, 0, vertices.Length);
            Context.SwapBuffers();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, 
                vertices.Length * sizeof(float), 
                vertices.ToArray(), 
                BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, true, 0, 0);
        }
        protected override void OnUnload()
        {
            base.OnUnload();
        }



 


    }
}
