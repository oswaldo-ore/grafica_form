using grafica.objetos.utils.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafica.objetos.model
{
    class Libreto
    {
        public List<Accion> acciones = new List<Accion>();
        
        String name;
        string dir;

        public Libreto(String name)
        {
            this.name = name;
        }
        public Libreto(String name,String dir)
        {
            this.name = name;
            this.dir = dir;
        }
        public void  addAccion(Accion accion)
        {
            acciones.Add(accion);
        }

        public void eliminarAccion(Accion accion)
        {

            acciones.Remove(accion);
        }

        public Accion getAccion(int index)
        {
            return acciones.ElementAt(index);
        }
        public void loadLibreto(String path)
        {
            acciones = JsonSerialize.readLibreto(path);
        }

        public void saveLibreto(String name)
        {
            JsonSerialize.saveLibreto(name,acciones);
        }

    }
}
