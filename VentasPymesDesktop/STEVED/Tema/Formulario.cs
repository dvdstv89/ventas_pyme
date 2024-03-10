using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucleoEV.Tema
{
    public class Formulario
    {
        public void InicializarFormDialog<T>(ref T form) where T : Form
        {
            form.BackColor = new Colores().getColor(TipoColor.SubFormBackColor);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.ShowIcon = false;
          //  form.ShowInTaskbar = false;
        }
    }
}
