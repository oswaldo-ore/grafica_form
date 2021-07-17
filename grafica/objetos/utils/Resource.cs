using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System.Collections.Generic;

namespace grafica.objetos.utils
{
    class Resource
    {
        private int _vertexBufferObject;

        private int _vertexArrayObject;
        private int _elementBufferObject;

        // This class is a wrapper around a shader, which helps us manage it.
        // The shader class's code is in the Common project.
        // What shaders are and what they're used for will be explained later in this tutorial.

        public float[] _vertices;
        public uint[] _indices;

        private Shader _shader;

        public void setShader(Shader shader)
        {
            _shader = shader;
        }

        public void load(float[] _ver,uint[] _ind)
        {
            _vertices = _ver;
            _indices = _ind;
            
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            
            
            /*GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);*/
            
            
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            //_shader = new Shader("../../objetos/utils/shader/shader.vert", "../../objetos/utils/shader/shader.frag");
            _shader.Use();

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        }

        public void draw()
        {
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.Quads, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void unload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(_vertexBufferObject);
        }
    }
}
