using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Template
{
    public class Square
    {
        private float[] vertices = {
            -0.5f, -0.5f, 0.0f,   // Vértice inferior esquerdo
             0.5f, -0.5f, 0.0f,   // Vértice inferior direito

            -0.5f,  0.5f, 0.0f,   // Vértice superior esquerdo
             0.5f,  0.5f, 0.0f,   // Vértice superior direito
        };

        private uint[] indices = {
            0, 1, 2,
            1, 2, 3,
        };

        private Vector2 offset = Vector2.Zero;

        private VBO vbo;
        private VAO vao;
        private EBO ebo;
        private Shader shader;

        public Square()
        {
            vao = new VAO();
            vbo = new VBO(vertices);
            ebo = new EBO(indices);

            vao.Bind();
            vbo.Bind();
            ebo.Bind();

            vao.LinkAttrib(vbo, 0, 3, VertexAttribPointerType.Float, 3, 0);

            vao.Unbind();
            vbo.Unbind();
            ebo.Unbind(); 

            shader = new Shader("shaders/vertex_shader.glsl", "shaders/fragment_shader.glsl");
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
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
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
