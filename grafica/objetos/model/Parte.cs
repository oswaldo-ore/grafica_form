using System;
using System.Collections.Generic;
using grafica.objetos.utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace grafica.objetos
{
    public class Parte:Figura
    {
        private float[] _vertices;
        private uint[] _indices;
        private Resource resource = new Resource();
        
        public Parte(float widthC,float heigthC,float widthZC){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
            cargarVertices();
        }

        public Parte(float widthC,float heigthC,float widthZC,Vector3 vectorPos){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
            vectorPosicion = vectorPos;
            cargarVertices();
            //centroMasa = vectorPosicion;
        }
        public Parte(float widthC,float heigthC,float widthZC,Vector3 vectorPos, Vector3 cmasa){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
            vectorPosicion = vectorPos;
            cargarVertices();
            //centroMasa = new Vector4(cmasa,1);
        }

        public override void cargarRecursos(Shader shader)
        {
            resource.setShader(shader);
            resource.load(_vertices,_indices);
        }


        private void caraDelantera(float medioX,float medioY,float medioZ){
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z +medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.End();
        }
        private void caraTrasera(float medioX,float medioY,float medioZ){
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z -medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.End();
        }
        private void caraLadoIzquierdo(float medioX,float medioY,float medioZ){
             GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.End();
        }
        private void caraLadoDerecho(float medioX,float medioY,float medioZ){
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.End();
        }

        private void caraArriba(float medioX,float medioY,float medioZ){
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y + medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z + medioZ);
            GL.End();
        }
        private void caraAbajo(float medioX,float medioY,float medioZ){
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z - medioZ);
            GL.Vertex3(vectorPosicion.X + medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.Vertex3(vectorPosicion.X - medioX, vectorPosicion.Y - medioY,vectorPosicion.Z + medioZ);
            GL.End();
        }

        public override void paint(Shader shader)
        {
            //cargar(); 
            shader.SetMatrix4("transform", vRotate*Matrix4.Identity * vTrasladar  *vEscala );
            resource.draw();
        }

        public override void trasladar(float x,float y , float z){
            vTrasladar *= Matrix4.CreateTranslation(new Vector3(x,y,z)/100);
        }
        public override void rotar(float grados, float enElEjex, float enElEjey, float enElEjez){
            vRotate = Matrix4.CreateFromAxisAngle(centroMasa,MathHelper.DegreesToRadians(grados));
        }
        public override void escalar(float escalar)
        {
            vEscala = Matrix4.CreateScale(escalar);
        }

        public void cargarVertices()
        {
            float medioX = width / 2, medioY = heigth / 2, medioZ = depth / 2;

            _vertices = new float[] {
                //cara delantera
                vectorPosicion.X - medioX, vectorPosicion.Y + medioY, vectorPosicion.Z + medioZ,
                vectorPosicion.X + medioX, vectorPosicion.Y + medioY, vectorPosicion.Z + medioZ,
                vectorPosicion.X + medioX, vectorPosicion.Y - medioY, vectorPosicion.Z + medioZ,
                vectorPosicion.X - medioX, vectorPosicion.Y - medioY, vectorPosicion.Z + medioZ,

                //cara trasera
                vectorPosicion.X - medioX, vectorPosicion.Y + medioY,vectorPosicion.Z -medioZ,
                vectorPosicion.X + medioX, vectorPosicion.Y + medioY, vectorPosicion.Z - medioZ,
                vectorPosicion.X + medioX, vectorPosicion.Y - medioY, vectorPosicion.Z - medioZ,
                vectorPosicion.X - medioX, vectorPosicion.Y - medioY, vectorPosicion.Z - medioZ,

           };

            for (int i = 0;i<_vertices.Length;i++)
            {
                _vertices[i] = (_vertices[i] / 100);
            }
            _indices = new uint[]
            {
                0,1,2,3,
                1,5,6,2,
                4,5,6,7,
                0,4,7,3,
                0,4,5,7,
                2,6,7,3,

            };

    }

        public void cargar()
        {   /*float medioX = width/2, medioY = heigth/2, medioZ = depth/2;
            GL.Color4(System.Drawing.Color.Green);
            GL.LoadIdentity();
            GL.PushMatrix();
                GL.Translate(vTrasladar);
                GL.Scale(vEscala);
                GL.PushMatrix();
                    GL.Translate(centroMasa);
                    GL.Rotate(angulo,vRotate);
                    GL.Translate(centroMasa*-1);
                    GL.PushMatrix();
                        caraDelantera(medioX,medioY,medioZ);
                        caraTrasera(medioX,medioY,medioZ);
                        caraLadoIzquierdo(medioX,medioY,medioZ);
                        caraLadoDerecho(medioX,medioY,medioZ);
                        caraArriba(medioX,medioY,medioZ);
                        caraAbajo(medioX,medioY,medioZ);
                    GL.PopMatrix(); 
                GL.PopMatrix();               
            GL.PopMatrix();*/
        }
    }
}