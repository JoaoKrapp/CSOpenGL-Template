using OpenTK.Graphics.OpenGL4;

using Template.buffers;

namespace Template
{
    public class Triangle
    {
        private float[] vertices = {
            -0.5f, -0.5f, 0.0f,  // Vértice inferior esquerdo
             0.5f, -0.5f, 0.0f,  // Vértice inferior direito
             0.0f,  0.5f, 0.0f   // Vértice superior
        };

        private uint[] indices = {
            0, 1, 2,
        };

        private VBO vbo;
        private VAO vao;
        private EBO ebo;
        private Shader shader;

        public Triangle()
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

        public void Render()
        {
            shader.Use();
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
