using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NucleoEV.Tema
{
    public enum TipoBoton
    {
        Menu,
        SubMenu,
        Banner,
        Normal,
        NormalWidthLock
       
    }
    public class Boton
    {  
        public void inicializarBoton(ref Button button, TipoBoton tipoButton)
        {
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.ButtonText);
            switch (tipoButton)
            {
                case TipoBoton.Menu:
                    {
                        InicializarBotonMenu(ref button);
                        return;
                    }
                case TipoBoton.Banner:
                    {
                        InicializarBotonBanner(ref button);
                        return;
                    }
                case TipoBoton.Normal:
                    {
                        InicializarBotonNormal(ref button);
                        return;
                    }
                case TipoBoton.NormalWidthLock:
                    {
                        InicializarBotonNormalWidthLock(ref button);
                        return;
                    }
                default:
                    break;
            }
        }       

        void InicializarBotonMenu(ref Button button)
        {          
            button.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.FormText);
            button.TextImageRelation= TextImageRelation.ImageBeforeText;
            button.Padding = new Padding(5, 0, 0, 0);
            button.Size = new Size(250, 45);
            button.ImageAlign =ContentAlignment.MiddleLeft;
        }
        void InicializarBotonBanner(ref Button button)
        {
            button.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.FormText);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Size = new Size(140, 35);
            button.ImageAlign = ContentAlignment.MiddleLeft;
        }
        void InicializarBotonNormal(ref Button button)
        {
            button.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorDark);
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.FormText);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Size = new Size(120, 30);
            button.ImageAlign = ContentAlignment.MiddleLeft;
        }
        void InicializarBotonNormalWidthLock(ref Button button)
        {
            button.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorDark);
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.FormText);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Size = new Size(button.Width, 30);
            button.ImageAlign = ContentAlignment.MiddleLeft;
        }

    }    
}
