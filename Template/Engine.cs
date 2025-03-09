using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Template.common;


namespace Template
{
    public class Engine(int width, int height, string title) : GameWindow(GameWindowSettings.Default, new NativeWindowSettings(){
            ClientSize = new OpenTK.Mathematics.Vector2i(width, height),
            Title = title
        })
    {

        private List<EventHandleObject> elements  = [];
        private List<Element> basicObjects  = [];

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
               Close(); 
            }

            foreach (EventHandleObject element in elements)
            {
                element.EventHandle(KeyboardState);
            }

        }

        public void AddElement(EventHandleObject element){
            elements.Add(element);
        }

        public void AddBasicObject(Element basicObject){
            basicObjects.Add(basicObject);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            // float[] vertices = {
            //     -0.5f, -0.5f, 0.0f,   // Vértice inferior esquerdo
            //     0.5f, -0.5f, 0.0f,   // Vértice inferior direito

            //     -0.5f,  0.5f, 0.0f,   // Vértice superior esquerdo
            //     0.5f,  0.5f, 0.0f,   // Vértice superior direito
            // };

            // uint[] indices = {
            //     0, 1, 2,
            //     1, 2, 3,
            // };

            // element = new Element(vertices, indices);


            // square = new Circle(2);

        }
        

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            float aspectRatio = (float)Size.X / Size.Y; // Calcula a razão de aspecto
            // element.Render(aspectRatio);

            foreach (EventHandleObject element in elements)
            {
                element.Render(aspectRatio);
            }

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
            foreach (EventHandleObject element in elements)
            {
                element.Dispose();
            }
            // element.Dispose();
            // square.Dispose();
        }
    }
}
