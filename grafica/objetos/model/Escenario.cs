using System;
using OpenTK;

namespace grafica.objetos
{
    public class Escenario : Figura
    {

        public Escenario(float widthS,float heigthS,float widthZS){
            width = widthS;
            heigth = heigthS;
            depth = widthZS;
        }
        public Escenario(float widthS,float heigthS,float widthZS,Vector3 centroMasa){
            width = widthS;
            heigth = heigthS;
            depth = widthZS;
            vectorPosicion = new Vector3(centroMasa);
        }

        public void add(String key,Figura figura){
            partesObjeto.Add(key,figura);
        }

        public void eliminar(string key){
            partesObjeto.Remove(key);
        }

        public Figura get(string key){
            return partesObjeto[key];
        }
    }
}