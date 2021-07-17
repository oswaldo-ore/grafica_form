using System;
using System.Collections.Generic;
using grafica.objetos.utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace grafica.objetos
{
    public abstract class Figura:InterfaceFigura
    {
        public float width = 10,heigth = 10,depth =10;
        public Vector3 vectorPosicion = new Vector3(0,0,0);
        public Dictionary<String,Figura> partesObjeto = new Dictionary<String, Figura>();
        public float angulo=0;
        public Vector3 centroMasa = new Vector3(0,0,0);
        public Matrix4 vRotate = Matrix4.Identity;
        public Matrix4 vEscala = Matrix4.CreateScale(new Vector3(1,1,1));
        public Matrix4 vTrasladar = Matrix4.CreateTranslation(new Vector3(0,0,0));

        public virtual void cargarRecursos(Shader shader)
        {
            foreach (var partes in partesObjeto)
            {
                partes.Value.cargarRecursos(shader);
            }
        }

        public virtual void escalar(float escalar)
        {
            foreach (var partes in partesObjeto)
            {   
                partes.Value.escalar(escalar);
            }
        }

        public virtual void paint(Shader shader)
        {   
            foreach (var partes in partesObjeto)
            {   
                partes.Value.paint(shader);
            }
        }

        public virtual void rotar(float grados, float enElEjex, float enElEjey, float enElEjez)
        {
            foreach (var partes in partesObjeto)
            {   
                partes.Value.rotar(grados,enElEjex,enElEjey,enElEjez);
            }
        }

        public virtual void trasladar(float x, float y, float z)
        {
            foreach (var partes in partesObjeto)
            {   
                partes.Value.trasladar(x,y,z);
            }
        }
    }
}