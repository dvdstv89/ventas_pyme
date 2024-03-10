using ModelData.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using System.Globalization;

namespace NucleoEV.Tema
{
    public class TemaAplication
    {       
        private ToolStripBoton toolStripButton { get; set; }
        private Boton boton { get; set; }
        private List listView { get; set; }
        private Texto texto { get; set; }
        private Colores colores { get; set; }
        public MiDataTimePicker dateTime { get; set; }
        private Formulario formulario { get; set; }
        public TemaAplication()
        {          
            boton = new Boton(); 
            listView=new List();
            texto = new Texto();
            colores = new Colores();
            toolStripButton = new ToolStripBoton();
            dateTime= new MiDataTimePicker();
            formulario= new Formulario();
        }
        public void inicializarDateTimePicker(ref DateTimePicker dateTime, CultureInfo cultureInfo, DateTime fechaInicio, DateTime fechaFin, DateTime value)
        {
            this.dateTime.inicializarDateTime (ref dateTime, cultureInfo, fechaInicio,fechaFin,value);
        }
        public void inicializarToolStripButton(ref ToolStripButton button, TipoToolStripButton tipoButton, bool colorParaPanelLateral = false)
        {
            toolStripButton.inicializarBoton(ref button, tipoButton, colorParaPanelLateral);
        }
        public void inicializarBoton(ref Button button, TipoBoton tipoButton)
        {
            boton.inicializarBoton(ref button, tipoButton);
        }
        public void inicializarListView(ref ListView list)
        {
            listView.inicializarListView(ref list);
        }
        public void inicializarSubListView(ref ListView list)
        {
            listView.inicializarSubListView(ref list);
        }
        public void inicializarFormDialog<T>(ref T form) where T : Form
        {
            formulario.InicializarFormDialog(ref form);
        }
        public System.Drawing.Font inicializarTexto(TipoTexto tipoTexto)
        {
            return texto.inicializarTexto(tipoTexto);
        }
        public Color inicializarColor(TipoColor tipoColor)
        {
            return colores.getColor(tipoColor);
        }
        public ListViewItem inicializarListViewItem(ListViewItem item, int pos, bool isAbierta = true)
        {
            listView.inicializarListViewItem(ref item, pos, isAbierta);
            return item;
        }
        public ListViewItem inicializarSubListViewItem(ListViewItem item, int pos)
        {
            listView.inicializarSubListViewItem(ref item, pos);
            return item;
        }
        public ListViewItem inicializarListViewItemTotal(ListViewItem item)
        {
            listView.inicializarListViewItemTotal(ref item);
            return item;
        }
        public Color formularioBgColor()
        {
            return new TemaAplication().inicializarColor(TipoColor.FormBackColor);
        }
        public Color subFormularioBgColor()
        {
            return new TemaAplication().inicializarColor(TipoColor.SubFormBackColor);
        }
    }
}
