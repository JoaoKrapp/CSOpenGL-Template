using Template.common;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template.entity
{
    public class Player : Element, EventHandleObject
    {
        public Player(float[] vertices, uint[] indices) : base(vertices, indices)
        {

        }

        public void EventHandle(KeyboardState keyboardState)
        {
            const float moveSpeed = 0.001f;
            
            if (keyboardState.IsKeyDown(Keys.Left))
                this.Move(-moveSpeed, 0);
            if (keyboardState.IsKeyDown(Keys.Right))
                this.Move(moveSpeed, 0);
            if (keyboardState.IsKeyDown(Keys.Up))
                this.Move(0, moveSpeed);
            if (keyboardState.IsKeyDown(Keys.Down))
                this.Move(0, -moveSpeed);
        }
    }
}
