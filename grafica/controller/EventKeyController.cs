using grafica.objetos;
using System;
using System.Windows.Forms;

namespace grafica.controller
{
    class EventKeyController
    {
        public delegate void OnKeyPress();
        public event OnKeyPress onKeyPress;
        public void mostrar(Figura select)
        {
            MessageBox.Show(select.partesObjeto.ToString());
        }
    }
}
