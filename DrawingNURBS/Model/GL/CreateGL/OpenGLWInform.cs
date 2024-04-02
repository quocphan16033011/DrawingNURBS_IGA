using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace DrawingNURBS.Model.GL.CreateGL
{
    internal class OpenGLWInform
    {
        private OpenGL gl;
        private int Width;
        private int Height;

        public OpenGLWInform(OpenGL gl, int Width, int Height)
        {
            this.gl = gl;
            this.Width = Width;
            this.Height = Height;
        }

        public static string LoadFileShader(string path)
        {
            var execute = Assembly.GetExecutingAssembly();
            var pathToDots = path.Replace("\\", ".");
            var locate = string.Format("{0}.{1}", execute.GetName().Name, pathToDots);

            using (var stream = execute.GetManifestResourceStream(locate))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
