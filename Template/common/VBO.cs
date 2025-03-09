using OpenTK.Graphics.OpenGL4;

namespace Template.common
{
    public class VBO
    {
        public int ID { get; private set; }

        public VBO(float[] data) {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, ID);

        public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        public void Dispose() => GL.DeleteBuffer(ID);
    }
}