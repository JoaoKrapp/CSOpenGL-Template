using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template
{
    public class Engine(int width, int height, string title) : GameWindow(GameWindowSettings.Default, new NativeWindowSettings(){
            ClientSize = new OpenTK.Mathematics.Vector2i(width, height),
            Title = title
        })
    {

        private Square square;

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
               Close(); 
            }

            const float moveSpeed = 0.001f;

            if (KeyboardState.IsKeyDown(Keys.Left))
                square.Move(-moveSpeed, 0);
            if (KeyboardState.IsKeyDown(Keys.Right))
                square.Move(moveSpeed, 0);
            if (KeyboardState.IsKeyDown(Keys.Up))
                square.Move(0, moveSpeed);
            if (KeyboardState.IsKeyDown(Keys.Down))
                square.Move(0, -moveSpeed);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            square = new Square();

        }
        

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            float aspectRatio = (float)Size.X / Size.Y; // Calcula a razão de aspecto
            square.Render(aspectRatio);

            SwapBuffers();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            square.Dispose();
        }
    }
}
