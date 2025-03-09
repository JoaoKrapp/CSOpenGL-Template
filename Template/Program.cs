using Template;


namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            using Engine engine = new(800, 800, "OpenTK Tutorial");
            engine.Run();
        }
    }
}