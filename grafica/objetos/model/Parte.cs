using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace grafica.objetos
{
    public class Parte:Figura
    {
        List<float> vertices = new List<float>();
        
        public Parte(float widthC,float heigthC,float widthZC){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
        }

        public Parte(float widthC,float heigthC,float widthZC,Vector3 vectorPos){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
            vectorPosicion = vectorPos;
            //centroMasa = vectorPosicion;
        }
        public Parte(float widthC,float heigthC,float widthZC,Vector3 vectorPos, Vector3 cmasa){
            width = widthC;
            heigth = heigthC;
            depth = widthZC;
            vectorPosicion = vectorPos;
            //centroMasa = new Vector4(cmasa,1);
        }


        private void caraDelantera(float medioX,float medioY,float medioZ){
            vertices.Add();
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


        public override void paint()
        {  
            cargar();
        }

        public override void trasladar(float x,float y , float z){
            vTrasladar.X += x;
            vTrasladar.Y += y;
            vTrasladar.Z += z;
        }
        public override void rotar(float grados, float enElEjex, float enElEjey, float enElEjez){
                angulo = grados;
                Console.WriteLine(angulo);
                vRotate = new Vector3(enElEjex,enElEjey,enElEjez);
        }
        public override void escalar(float escalar)
        {   
            vEscala = new Vector3(escalar,escalar,escalar);
            Console.WriteLine(vectorPosicion);
            Console.WriteLine(vEscala);
        }

        public void cargar()
        {   float medioX = width/2, medioY = heigth/2, medioZ = depth/2;
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
            GL.PopMatrix();
        }
    }
}