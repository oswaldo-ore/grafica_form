using grafica.objetos.utils;
using OpenTK;

namespace grafica.objetos
{
    public interface InterfaceFigura
    {         
        void paint(Shader shader);
        void trasladar(float x,float y , float z);   
        void rotar(float grados,float enElEjex,float enElEjey,float enElEjez);
        void escalar(float escalar);
        void cargarRecursos(Shader shader);
    }
}