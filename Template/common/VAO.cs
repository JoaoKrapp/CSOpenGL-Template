using OpenTK.Graphics.OpenGL4;

namespace Template.common
{
    public class VAO
    {
        public int ID { get; private set; }

        public VAO() 
        {
            ID = GL.GenVertexArray();
        }

        public void Bind() => GL.BindVertexArray(ID);

        public void Unbind() => GL.BindVertexArray(0);

        // <param name="vbo">Objeto que contem um INT que representa os dados brutos na GPU</param>
        // <param name="index">Qual variavel a atribuir os dados no vertex shader layout(location = 0) </param>
        // <param name="size">Número de elementos por vértice para este atributo.</param>
        // <param name="type">O tipo de dado dos valores armazenados no VBO.</param>
        // <param name="stride">Quantos bytes um vértice completo ocupa dentro do VBO.</param>
        // <param name="offset">Onde este atributo começa dentro de cada vértice.</param>
        public void LinkAttrib(VBO vbo, int index, int size, VertexAttribPointerType type, int stride, int offset)
        {
            vbo.Bind();
            GL.VertexAttribPointer(index, size, type, false, stride * sizeof(float), offset * sizeof(float));
            GL.EnableVertexAttribArray(index);
            vbo.Unbind();
        }

        public void Dispose() => GL.DeleteVertexArray(ID);

    }
}