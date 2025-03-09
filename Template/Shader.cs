using OpenTK.Graphics.OpenGL4;
using System;
using System.IO;

namespace Template
{
    public class Shader
    {
        public int ID { get; private set; }

        public Shader(string vertexPath, string fragmentPath)
        {
            string vertexCode = File.ReadAllText(vertexPath);
            string fragmentCode = File.ReadAllText(fragmentPath);

            int vertexShader = CompileShader(vertexCode, ShaderType.VertexShader);
            int fragmentShader = CompileShader(fragmentCode, ShaderType.FragmentShader);

            ID = GL.CreateProgram();
            GL.AttachShader(ID, vertexShader);
            GL.AttachShader(ID, fragmentShader);
            GL.LinkProgram(ID);

            GL.DetachShader(ID, vertexShader);
            GL.DetachShader(ID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        private int CompileShader(string source, ShaderType type)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Erro ao compilar {type}: {infoLog}");
            }

            return shader;
        }

        public void Use() => GL.UseProgram(ID);

        public void Dispose() => GL.DeleteProgram(ID);
    }
}
