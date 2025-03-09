using OpenTK.Graphics.OpenGL4;

namespace Template.common
{
    public class EBO
    {
        public int ID { get; private set; }

        public EBO(uint[] indices)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);

        public void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

        public void Dispose() => GL.DeleteBuffer(ID);
    }
}
