using Template;
using Template.entity;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            using Engine engine = new(600, 600, "OpenTK Tutorial");

             float[] vertices = {
                -0.5f, -0.5f, 0.0f,   // Vértice inferior esquerdo
                0.5f, -0.5f, 0.0f,   // Vértice inferior direito

                -0.5f,  0.5f, 0.0f,   // Vértice superior esquerdo
                0.5f,  0.5f, 0.0f,   // Vértice superior direito
            };

            uint[] indices = {
                0, 1, 2,
                1, 2, 3,
            };

            Player square = new(vertices, indices);

            engine.AddElement(square);

            engine.Run();
        }
    }
}