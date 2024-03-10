using NucleoEV.Tema;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    public class ItemListView<Tipo>
    {
        public Tipo tipo { get; set; }
        public ListViewItem listViewItem { get; set; }
        public int posicion { get; set; }
        public bool isSeleccionado { get; set; }
        public bool isTienda { get; set; } = false;
        public bool isTiendaAbierta { get; set; } = true;
        public ItemListView(Tipo tipo, ListViewItem listViewItem, int posicion, bool isSeleccionado = false)
        {
            this.listViewItem = listViewItem;
            this.posicion = posicion;
            this.isSeleccionado = isSeleccionado;
            this.tipo= tipo;
        }
        public ItemListView(Tipo tipo, ListViewItem listViewItem, int posicion, bool isTiendaAbierta, bool isSeleccionado = false)
        {
            this.listViewItem = listViewItem;
            this.posicion = posicion;
            this.isSeleccionado = isSeleccionado;
            this.isTienda = true;
            this.isTiendaAbierta = isTiendaAbierta;
            this.tipo = tipo;
        }
        public ListViewItem GetListViewItem()
        {
            inicializarListViewItem();
            return listViewItem;
        }
        public void inicializarListViewItem()
        {
            listViewItem.Font = new TemaAplication().inicializarTexto(TipoTexto.ListViewItemText);
            listViewItem.ForeColor = new TemaAplication().inicializarColor(TipoColor.listItemFC);

            if (isSeleccionado)
            {
                listViewItem.BackColor = new TemaAplication().inicializarColor(TipoColor.RowSeleccionada);
                return;
            }
            if (!isTienda || (isTienda && isTiendaAbierta))
            {
                listViewItem.BackColor = (posicion % 2 == 0) ? new TemaAplication().inicializarColor(TipoColor.ListItemBgPar) : new TemaAplication().inicializarColor(TipoColor.ListItemBgImpar);
                return;
            }
            if (!isTiendaAbierta)
            {
                listViewItem.BackColor = new TemaAplication().inicializarColor(TipoColor.RowTiendaCerrada);
                return;
            }           
        }
    }
}
