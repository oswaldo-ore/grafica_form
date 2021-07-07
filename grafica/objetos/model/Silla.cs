using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace grafica.objetos
{
    public class Silla:Figura
    {   
        float grosorPata;
        
        public Silla(float widthS,float heigthS,float widthZS){
            width = widthS;
            heigth = heigthS;
            depth = widthZS;
            this.grosorPata = (float)(heigthS * 0.05);
            cargarSilla();
        }
        public Silla(float widthS,float heigthS,float widthZS,Vector3 centroMasa){
            width = widthS;
            heigth = heigthS;
            depth = widthZS;
            vectorPosicion = centroMasa;
            this.grosorPata = (float)(widthS * 0.05);
            cargarSilla();
        }


        private void cargarSilla(){
            float medioX= width/2,medioY = heigth/2,medioZ= depth/2,medioGro = grosorPata /2;
            partesObjeto =new  Dictionary<String,Figura>(){
                {"asiento" , new Parte(width,grosorPata,depth,this.vectorPosicion)},
                {"pataIzquierdaDelantera" , new Parte(grosorPata,heigth,grosorPata,new Vector3(this.vectorPosicion.X - medioX + medioGro, this.vectorPosicion.Y , this.vectorPosicion.Z + medioZ - medioGro))} ,
                {"pataIzquierdaTrasera" , new Parte(grosorPata,heigth,grosorPata,new Vector3(this.vectorPosicion.X - medioX + medioGro, this.vectorPosicion.Y /* + medioY*/, this.vectorPosicion.Z - medioZ + medioGro))},
                {"pataDerechaDelantera",new Parte(grosorPata,medioY,grosorPata,new Vector3(this.vectorPosicion.X + medioX - medioGro, this.vectorPosicion.Y - medioY / 2,this.vectorPosicion.Z - medioZ + medioGro))},
                {"pataDerechaTrasera", new Parte(grosorPata,medioY,grosorPata,new Vector3(this.vectorPosicion.X + medioX - medioGro, this.vectorPosicion.Y - medioY / 2, this.vectorPosicion.Z + medioZ - medioGro))},
                {"tablonDeAtras", new Parte(grosorPata,grosorPata,depth,new Vector3(this.vectorPosicion.X - medioX + medioGro, this.vectorPosicion.Y + medioY - medioGro, this.vectorPosicion.Z))}
            };
            foreach (var objetos in partesObjeto)
            {
                objetos.Value.centroMasa = vectorPosicion;
            }
        }

        


    }
}