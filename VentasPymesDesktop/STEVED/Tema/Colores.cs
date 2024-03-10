using System.Drawing;

namespace NucleoEV.Tema
{
    public enum TipoColor
    {
        Logo,
        LateralMenu,
        LateralSubMenu,
        FormBackColor,
        SubFormBackColor,
        ButtonFontColorLigth,
        ButtonFontColorDark,
        ToolStripButton,
        ToolStripButtonActivo,
        ListViewBg,
        ListViewFC,
        ListItemBgPar,
        ListItemBgImpar,
        listItemFC,
        FooterBarBC,
        FooterBarFC,
        PanelBannerBC,
        PanelDetails,
        PanelBannerDetails, 
        RowTiendaCerrada,
        RowSeleccionada
    }
    public class Colores
    {   
        string colorBanner_1 = "#8E541A";
        string colorMenu_2 = "#D0A538";      
        string colorSubMenu_4 = "#aee637";
        string color_ApplicationBG_5 = "#fffedb";
        string colorBotones = "#7b9971";
        string colorListViewBG_3 = "#fffedb";
        string colorListView_ItemParBG = "#f0e2a4";
        string colorListView_ItemImparBG = "#f4ebc3";
        string colorBotonActivo = "#EB7A1D";
        string rowTiendaCerrada = "#D7F810";
        string rowSeleccionada = "#604BFB";

        public Color getColor(TipoColor tipoColor)
        {           
            switch (tipoColor)
            {
                //COLOR PRINCIPAL 1
                case TipoColor.Logo:
                case TipoColor.PanelBannerBC:
                case TipoColor.FooterBarBC:
                    {
                        return ColorTranslator.FromHtml(colorBanner_1);
                    }
                //Color 2
                case TipoColor.LateralMenu:
                case TipoColor.ListViewFC:
                case TipoColor.PanelDetails:               
                case TipoColor.PanelBannerDetails:
                    {
                        return ColorTranslator.FromHtml(colorMenu_2);
                    }
                    //color 3
                case TipoColor.ListViewBg:               
                    {
                        return ColorTranslator.FromHtml(colorListViewBG_3);
                    }   
                    //color 4              
                case TipoColor.LateralSubMenu:
                    {                      
                      return ColorTranslator.FromHtml(colorSubMenu_4);                        
                    }
                // color 5
                case TipoColor.FormBackColor:
                    {
                        return ColorTranslator.FromHtml(color_ApplicationBG_5);
                    }
                case TipoColor.ButtonFontColorLigth:
                case TipoColor.FooterBarFC:               
                    {
                        return Color.White;
                    }
                case TipoColor.ButtonFontColorDark:
                case TipoColor.listItemFC:
                    {
                        return Color.Black;
                    }
                case TipoColor.ToolStripButton:               
                    {
                        return ColorTranslator.FromHtml(colorBotones);
                    }
                case TipoColor.ToolStripButtonActivo:
                    {
                        return ColorTranslator.FromHtml(colorBotonActivo);
                    }
                case TipoColor.ListItemBgPar:
                    
                    {
                        return ColorTranslator.FromHtml(colorListView_ItemParBG);
                    }
                case TipoColor.ListItemBgImpar:               
                    {
                        return ColorTranslator.FromHtml(colorListView_ItemImparBG);
                    }  
                case TipoColor.SubFormBackColor:
                    {
                        return ColorTranslator.FromHtml(colorListView_ItemImparBG);
                    }
                case TipoColor.RowTiendaCerrada:
                    {
                        return ColorTranslator.FromHtml(rowTiendaCerrada);
                    }
                case TipoColor.RowSeleccionada:
                    {
                        return ColorTranslator.FromHtml(rowSeleccionada);
                    }

                default:
                    break;
            }
            return Color.White;
        }       
    }    
}
