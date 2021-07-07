using OpenTK.Graphics.OpenGL4;

namespace grafica.objetos.utils
{
    class Resource
    {
        private int _vertexBufferObject;

        private int _vertexArrayObject;
        public float[] _vertices;
        public Shader _shader;

        public void load()
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer,_vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer,_vertices.Length * sizeof(float),_vertices,BufferUsageHint.DynamicDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0,3, VertexAttribPointerType.Float,false,3*sizeof(float),0);
            GL.EnableVertexAttribArray(0);

        }

        public void unload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(_vertexBufferObject);
        }
    }
}
