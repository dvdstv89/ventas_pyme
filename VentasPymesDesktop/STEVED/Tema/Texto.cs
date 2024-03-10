using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NucleoEV.Tema
{
    public enum TipoTexto
    {
        FormText = 0,
        ButtonText = 1,
        ListViewText = 2,
        ListViewItemText = 3,
        Title = 4,
        MigasPanFont = 5,
        SubListViewText = 6,
        SubListViewItemText = 7,
    }

    public class Texto
    {
        Font formFont;
        Font buttonFont;
        Font listViewFont;
        Font titleFont;
        Font migasPanFont;
        Font listItemFont;
        Font subListItemFont;
        Font subListViewItemText;
        public Texto()
        {
            buttonFont = new Font("Segoe UI Light", 10, System.Drawing.FontStyle.Bold);
            listViewFont = new System.Drawing.Font("Palatino Linotype", 10, System.Drawing.FontStyle.Bold);
            listItemFont = new System.Drawing.Font("Segoe UI Light", 10, System.Drawing.FontStyle.Regular);
            formFont = new Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular);
            titleFont = new System.Drawing.Font("Palatino Linotype", 15, System.Drawing.FontStyle.Bold);
            migasPanFont = new System.Drawing.Font("Palatino Linotype", 14, System.Drawing.FontStyle.Bold);
            subListItemFont = new System.Drawing.Font("Palatino Linotype", 8, System.Drawing.FontStyle.Bold);
            subListViewItemText = new System.Drawing.Font("Segoe UI Light", 8, System.Drawing.FontStyle.Regular);
        }
        public Font inicializarTexto(TipoTexto tipoTexto)
        {            
            switch (tipoTexto)
            {
                case TipoTexto.FormText:
                    {
                        return formFont;                        
                    }
                case TipoTexto.ButtonText:
                    {
                        return buttonFont;
                        
                    }
                case TipoTexto.ListViewText:
                    {
                        return listViewFont;                        
                    }
                case TipoTexto.ListViewItemText:
                    {
                        return listItemFont;                        
                    }
                case TipoTexto.Title:
                    {
                        return titleFont;
                    }
                case TipoTexto.MigasPanFont:
                    {
                        return migasPanFont;
                    }
                case TipoTexto.SubListViewText:
                    {
                        return subListItemFont;
                    }
                case TipoTexto.SubListViewItemText:
                    {
                        return subListViewItemText;
                    }
                default:
                    return new Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Regular);
            }
        }       
    }
}
