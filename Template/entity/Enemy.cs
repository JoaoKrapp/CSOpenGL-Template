using Template.common;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template.common
{
    public class Enemy : Element, EventHandleObject
    {
        public Enemy(float[] vertices, uint[] indices) : base(vertices, indices)
        {

        }

        public void EventHandle(KeyboardState keyboardState)
        {
            const float moveSpeed = 0.001f;
            
            if (keyboardState.IsKeyDown(Keys.A))
                this.Move(-moveSpeed, 0);
            if (keyboardState.IsKeyDown(Keys.D))
                this.Move(moveSpeed, 0);
            if (keyboardState.IsKeyDown(Keys.W))
                this.Move(0, moveSpeed);
            if (keyboardState.IsKeyDown(Keys.S))
                this.Move(0, -moveSpeed);
        }
    }
}
