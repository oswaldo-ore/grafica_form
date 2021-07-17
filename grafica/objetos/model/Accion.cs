
using Newtonsoft.Json;
using System;

namespace grafica.objetos.model
{
    class Accion
    {
        private String nameFigura;
        public String method;
        private float x;
        private float y;
        private float z;
        private float angle;
        private float time;
        private float timeDelta;


        public Accion(String nameFigura,String method, float x, float y, float z,float angle = 0,float timeMiliS = 3)
        {
            this.nameFigura = nameFigura;
            this.method = method;
            this.x = x;
            this.y = y;
            this.z = z;
            this.angle = angle;
            this.time = timeMiliS;
            this.timeDelta = 3;
        }

       
        public String nameObjeto
        {
            get {return nameFigura; }
            set { nameFigura = value; }
        }

        public float X
        {
            get { return this.x; }
            set { x = value; }
        }
        public float Y
        {
            get { return this.y; }
            set { y = value; }
        }
        public float Z
        {
            get { return this.z; }
            set { z = value; }
        }

        public float Angle
        {
            get { return this.angle; }
            set { angle = value; }
        }
    }
}
