using MyUI.Enum;
using MyUI.Model;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class SkinFactory
    {
        private static System.Drawing.Color COLOR_PRIMARY = ColorTranslator.FromHtml("#3B71CA");
        private static System.Drawing.Color COLOR_SECUNDARY = ColorTranslator.FromHtml("#CCD4DE");
        private static System.Drawing.Color COLOR_SUCCESS = ColorTranslator.FromHtml("#14A44D");
        private static System.Drawing.Color COLOR_DANGER = ColorTranslator.FromHtml("#DC4C64");
        private static System.Drawing.Color COLOR_WARNING = ColorTranslator.FromHtml("#E4A11B");
        private static System.Drawing.Color COLOR_INFO = ColorTranslator.FromHtml("#31c0d2");
        private static System.Drawing.Color COLOR_LIGHT = ColorTranslator.FromHtml("#FBFBFB");
        private static System.Drawing.Color COLOR_DARK = ColorTranslator.FromHtml("#332D2D");
        private static System.Drawing.Color COLOR_LINK = ColorTranslator.FromHtml("#FFFFFF");       
        private static System.Drawing.Color COLOR_TRANSPARENT = System.Drawing.Color.Transparent;
        private static System.Drawing.Color COLOR_BLACK = System.Drawing.Color.Black;
        private static System.Drawing.Color COLOR_WHITE = System.Drawing.Color.White;

        private static System.Drawing.Color COLOR_CARACOL_BANNER = ColorTranslator.FromHtml("#8E541A");
        private static System.Drawing.Color COLOR_CARACOL_MENU = ColorTranslator.FromHtml("#D0A538");
        private static System.Drawing.Color COLOR_CARACOL_SUBMENU = ColorTranslator.FromHtml("#aee637");
        private static System.Drawing.Color COLOR_CARACOL_FORM = ColorTranslator.FromHtml("#fffedb");
        private static System.Drawing.Color COLOR_BOTON_MENU = ColorTranslator.FromHtml("#7b9971");
        private static System.Drawing.Color COLOR_LIST_BG = ColorTranslator.FromHtml("#fffedb");
        private static System.Drawing.Color COLOR_LIST_PAR = ColorTranslator.FromHtml("#f0e2a4");
        private static System.Drawing.Color COLOR_LIST_IMPAR = ColorTranslator.FromHtml("#f4ebc3");
        private static System.Drawing.Color COLOR_BUTTON_ACTIVE = ColorTranslator.FromHtml("#EB7A1D");
        private static System.Drawing.Color COLOR_TIENDA_CERRADA = ColorTranslator.FromHtml("#D7F810");
        private static System.Drawing.Color COLOR_CARACOL_ROW_SELECTED = ColorTranslator.FromHtml("#604BFB");
      

        private static Font FONT_BUTTON = new Font("Segoe UI Light", 10, System.Drawing.FontStyle.Bold);
        private static Font FONT_NORMAL = new Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Regular);       
        private static Font FONT_LIST_TITLE = new System.Drawing.Font("Palatino Linotype", 10, System.Drawing.FontStyle.Bold);
        private static Font FONT_LIST_ITEM = new System.Drawing.Font("Segoe UI Light", 10, System.Drawing.FontStyle.Regular);
        private static Font FONT_LABEL = new Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular);
        private static Font FONT_MENSAJE = new Font("Arial", 12, System.Drawing.FontStyle.Regular);
        private static Font FONT_TITLE = new System.Drawing.Font("Palatino Linotype", 15, System.Drawing.FontStyle.Bold);
        private static Font MIGAS = new System.Drawing.Font("Palatino Linotype", 14, System.Drawing.FontStyle.Bold);
        private static Font LIST = new System.Drawing.Font("Palatino Linotype", 8, System.Drawing.FontStyle.Bold);
        private static Font FONT_SUB_LIST_TITLE = new System.Drawing.Font("Segoe UI Light", 8, System.Drawing.FontStyle.Regular);
       
        public static Skin CARACOL_SKIN()
        {
            Skin skin = new Skin();
           

            skin.colorMensajeError = System.Drawing.Color.Yellow;
            skin.colorMensajeSuccess = System.Drawing.Color.Green;
            skin.colorMensajeException = System.Drawing.Color.Red;
            skin.colorMensajeConfirmation = COLOR_SECUNDARY;


            skin.buttonTextColor = COLOR_DARK;
            skin.buttonBackColor = COLOR_TRANSPARENT;
            skin.buttonIconColor = COLOR_DARK;
            skin.buttonIconSize = 30;
            skin.buttonFont = FONT_LABEL;
            skin.buttonTextImageRelation = TextImageRelation.ImageBeforeText;
            skin.buttonPadding = new Padding(0, 0, 0, 0);
            skin.buttonSize = new Size(100, 30);
            skin.buttonImageAling = ContentAlignment.MiddleCenter;


            skin.comboBoxTextColor = COLOR_BLACK;
            skin.comboBoxBackColor = COLOR_LINK;
            skin.comboBoxFont = FONT_LIST_ITEM;
            skin.comboBoxPadding = new Padding(5, 0, 0, 0);
            skin.comboBoxBoxSize = new Size(260, 45);
            skin.comboBoxDropDownSyle = ComboBoxStyle.DropDownList;


            skin.checkBoxTextColor = COLOR_DARK;
            skin.checkBoxFont = FONT_LABEL;
            skin.checkBoxPadding = new Padding(0, 0, 0, 0);

            skin.formFont = FONT_NORMAL;
            skin.formStartPosition = FormStartPosition.CenterScreen;
            skin.formBackColor = COLOR_CARACOL_FORM;


            skin.labelNormalFont = FONT_LABEL;
            skin.labelTitleFont = FONT_TITLE;
            skin.labelNormalTextColor = COLOR_DARK;
            skin.labelNormalBackColor = COLOR_TRANSPARENT;
            skin.labelFooterTextColor = COLOR_WHITE;
            skin.labelFooterBackColor = COLOR_CARACOL_BANNER;


            skin.richtTextBoxFont = FONT_MENSAJE;
            skin.richtTextBoxPadding = new Padding(10, 5, 5, 0);
            skin.richtTextBoxBorder = BorderStyle.None;


            skin.tabControlTextColor = COLOR_DARK;
            skin.tabControlFont = FONT_LIST_TITLE;

            skin.tabPageTextColor = COLOR_DARK;          
            skin.tabPageBackColor = COLOR_CARACOL_FORM;
            skin.tabPageFont = FONT_LIST_TITLE;


            skin.textBoxTextColor = COLOR_DARK;
            skin.textBoxBackColor = COLOR_LINK;
            skin.textBoxFont = FONT_LIST_ITEM;
            skin.textBoxPadding = new Padding(5, 0, 0, 0);
            skin.textBoxSize = new System.Drawing.Size(260, 45);

            skin.textBoxMultilinePadding = new Padding(5, 5, 5, 0);
            skin.textBoxMultilineFont = FONT_MENSAJE;
            skin.textBoxMultilineTextColor = COLOR_BLACK;

            skin.toolStripButtonTextColor = COLOR_WHITE;
            skin.toolStripButtonBackColor_PanelLateral = COLOR_BUTTON_ACTIVE;
            skin.toolStripButtonBackColor = COLOR_BOTON_MENU;
            skin.toolStripButtonFont = FONT_BUTTON;

            skin.listViewTextColor = COLOR_WHITE;
            skin.listViewBackColor = COLOR_LIST_BG;
            skin.listViewFont = FONT_LIST_TITLE;
            skin.subListViewFont = FONT_SUB_LIST_TITLE;

            skin.listViewItemTextColor = COLOR_BLACK;
            skin.listViewItemTotalBackColor = COLOR_BUTTON_ACTIVE;
            skin.listViewItemTotalFont = FONT_LIST_ITEM;           
            skin.listViewItemSubParBackColor = COLOR_LIST_PAR;
            skin.listViewItemSubImparBackColor = COLOR_LIST_IMPAR;
            skin.listViewItemSublFont = LIST;
            skin.listViewItemConditionalBackColor = COLOR_TIENDA_CERRADA;
          
            return skin;
        }
    }
}
