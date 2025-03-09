using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Template.buffers;

namespace Template
{
    public class Object
    {
        private Vector2 offset = Vector2.Zero;

        private VBO vbo;
        private VAO vao;
        private EBO ebo;
        private Shader shader;

        private float[] vertices;
        private uint[] indices;

        public Object(float[] vertices, uint[] indices)
        {
            this.vertices = vertices;
            this.indices = indices;

            this.vao = new VAO();
            this.vbo = new VBO(vertices);
            this.ebo = new EBO(indices);

            this.vao.Bind();
            this.vbo.Bind();
            this.ebo.Bind();

            this.vao.LinkAttrib(vbo, 0, 3, VertexAttribPointerType.Float, 3, 0);

            this.vao.Unbind();
            this.vbo.Unbind();
            this.ebo.Unbind(); 

            this.shader = new Shader("shaders/vertex_shader.glsl", "shaders/fragment_shader.glsl");
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

        public void Move(float x, float y)
        {
            offset += new Vector2(x, y);
        }

        public void Render(float aspectRatio)
        {
            shader.Use();

            // Atualiza o valor do uniform "offset" no shader
            int offsetLocation = GL.GetUniformLocation(shader.ID, "offset");
            GL.Uniform2(offsetLocation, offset);

            int aspectLocation = GL.GetUniformLocation(shader.ID, "aspectRatio");
            GL.Uniform1(aspectLocation, aspectRatio);

            vao.Bind();
            GL.DrawElements(PrimitiveType.Triangles, this.indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            vbo.Dispose();
            vao.Dispose();
            ebo.Dispose();
            shader.Dispose();
        }
    }
}
