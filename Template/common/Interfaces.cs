using Template.common;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template.common
{

    public interface IElement 
    {

        void Move(float x, float y);

        void Render(float aspectRatio);

        void Dispose();
    }

    public interface EventHandleObject : IElement
    {
        void EventHandle(KeyboardState keyboardState);
    }

    
}