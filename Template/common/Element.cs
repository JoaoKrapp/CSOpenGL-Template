using Template.common;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template.common
{
    

    public class Element : IElement
    {
        protected Vector2 offset = Vector2.Zero;

        protected VBO vbo;
        protected VAO vao;
        protected EBO ebo;
        protected Shader shader;

        protected float[] vertices;
        protected uint[] indices;

        public Element(float[] vertices, uint[] indices)
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

            float time = (float)GLFW.GetTime();
            // Obtém a localização do uniform "uTime"
            int uniformLocation = GL.GetUniformLocation(shader.ID, "uTime");
            GL.Uniform1(uniformLocation, time);

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
