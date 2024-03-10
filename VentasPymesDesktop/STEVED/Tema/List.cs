using System.Windows.Forms;


namespace NucleoEV.Tema
{   
    public class List
    {  
       public void inicializarListView(ref ListView list)
        {
            list.BackColor = new TemaAplication().inicializarColor(TipoColor.ListViewBg);
            list.Font = new TemaAplication().inicializarTexto(TipoTexto.ListViewText);
            list.ForeColor = new TemaAplication().inicializarColor(TipoColor.ListViewFC);
            list.FullRowSelect= true;
            list.GridLines = false;
        }
        public void inicializarSubListView(ref ListView list)
        {
            list.BackColor = new TemaAplication().inicializarColor(TipoColor.ListViewBg);
            list.Font = new TemaAplication().inicializarTexto(TipoTexto.SubListViewText);
            list.ForeColor = new TemaAplication().inicializarColor(TipoColor.ListViewFC);
            list.FullRowSelect = true;
            list.GridLines = false;
        }
        public void inicializarListViewItem(ref ListViewItem item, int pos, bool isAbierta)
        {
            if (isAbierta)
            {
                item.BackColor = (pos % 2 == 0) ? new TemaAplication().inicializarColor(TipoColor.ListItemBgPar) : new TemaAplication().inicializarColor(TipoColor.ListItemBgImpar);
               
            }
            else
            {
                item.BackColor = new TemaAplication().inicializarColor(TipoColor.RowTiendaCerrada);
            }           
            item.Font = new TemaAplication().inicializarTexto(TipoTexto.ListViewItemText);
            item.ForeColor = new TemaAplication().inicializarColor(TipoColor.listItemFC);
        }

        public void inicializarListViewItemTotal(ref ListViewItem item)
        {
            item.BackColor = new TemaAplication().inicializarColor(TipoColor.ToolStripButtonActivo);
            item.Font = new TemaAplication().inicializarTexto(TipoTexto.ListViewText);
            item.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorDark);
        }
        public void inicializarSubListViewItem(ref ListViewItem item, int pos)
        {
            item.BackColor = (pos % 2 == 0) ? new TemaAplication().inicializarColor(TipoColor.ListItemBgPar) : new TemaAplication().inicializarColor(TipoColor.ListItemBgImpar);
            item.Font = new TemaAplication().inicializarTexto(TipoTexto.SubListViewItemText);
            item.ForeColor = new TemaAplication().inicializarColor(TipoColor.listItemFC);            
        }
    }    
}
