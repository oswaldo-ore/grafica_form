using grafica.objetos;
using grafica.objetos.model;
using grafica.objetos.utils;
using OpenTK;
using System;
using System.Collections.Generic;

namespace grafica.controller
{
    class AnimationController
    {
        Dictionary<String, Libreto> libretos = new Dictionary<string,Libreto>();
        Libreto libreto1;
        Figura escenario;

        public AnimationController(Figura escenario)
        {
            this.escenario = escenario;
            cargar();
        }

        public void cargar()
        {
            libreto1 = new Libreto("libreto1");
            libreto1.addAccion(new Accion("escenario", Metodos.TRASLADAR, 20, 20, 0));
            libreto1.addAccion(new Accion("escenario.silla", Metodos.TRASLADAR, 50, 50, 0));
            libreto1.addAccion(new Accion("escenario.silla", Metodos.ESCALAR, (float)1.5, 50, 0));
            libreto1.addAccion(new Accion("escenario.silla", Metodos.TRASLADAR, -30, -30, 0));
            libreto1.addAccion(new Accion("escenario.mesa", Metodos.TRASLADAR,-50, -30, -30));
            libreto1.addAccion(new Accion("escenario.mesa.tabla", Metodos.TRASLADAR, 0, -30, -30));
            libreto1.addAccion(new Accion("escenario.silla", Metodos.ROTAR, 1, 0, 0,50));
            libreto1.addAccion(new Accion("escenario.mesa.tabla", Metodos.TRASLADAR, 0, 30, 30));
            libretos.Add("1", libreto1 );
            libreto1.saveLibreto("libreto1");
        }

        public void play()
        {
            foreach (var item in libreto1.acciones)
            {
                Figura figura = getFigura(item.nameObjeto);
                action(figura,item);
            }
            Console.WriteLine(escenario.ToString());
        }

        public Figura getFigura(String name)
        {
            Figura select = escenario;
            char delimiter = '.';
            string[] valores = name.Split(delimiter);
            if (valores.Length == 1)
            {
                return escenario;
            }
            for (int i = 1; i < valores.Length; i++)
            {
                select = select.partesObjeto[valores[i]];
            }
            return select;
        }

        public void action(Figura select , Accion accion)
        {
            switch (accion.method)
            {
                case Metodos.TRASLADAR:
                    select.trasladar(accion.X,accion.Y,accion.Z);
                    break;
                case Metodos.ROTAR:
                    select.rotar(accion.Angle ,accion.X,accion.Y,accion.Z);
                    break;
                case Metodos.ESCALAR:
                    select.escalar(accion.X);
                    break;
                default:
                    break;
            }
        }

        public void trasladar(Figura select, Accion accion)
        {   
        }
    }

    
}


