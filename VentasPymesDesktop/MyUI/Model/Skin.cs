using MyUI.Enum;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Model
{
    public class Skin
    {
        //colors
        public Color colorMensajeError { get; set; }
        public Color colorMensajeSuccess { get; set; }
        public Color colorMensajeException { get; set; }
        public Color colorMensajeConfirmation { get; set; }      


        //button
        public Color buttonTextColor { get; set; }
        public Color buttonBackColor { get; set; }
        public Color buttonIconColor { get; set; }
        public int buttonIconSize { get; set; }
        public System.Drawing.Font buttonFont { get; set; }      
        public TextImageRelation buttonTextImageRelation { get; set; }
        public Padding buttonPadding { get; set; }
        public Size buttonSize { get; set; }       
        public ContentAlignment buttonImageAling { get; set; }

        //combobox
        public Color comboBoxTextColor { get; set; }
        public Color comboBoxBackColor { get; set; }
        public Font comboBoxFont { get; set; }
        public Padding comboBoxPadding { get; set; }
        public Size comboBoxBoxSize { get; set; }
        public ComboBoxStyle comboBoxDropDownSyle { get; set; }

        //checkbox
        public Color checkBoxTextColor { get; set; }
        public Font checkBoxFont { get; set; }
        public Padding checkBoxPadding { get; set; }

        //form
        public System.Drawing.Font formFont { get; set; }
        public FormStartPosition formStartPosition { get; set; }
        public Color formBackColor { get; set; }

        //label

        public System.Drawing.Font labelNormalFont { get; set; }
        public System.Drawing.Font labelTitleFont { get; set; }
        public Color labelNormalTextColor { get; set; }
        public Color labelNormalBackColor { get; set; }
        public Color labelFooterTextColor { get; set; }
        public Color labelFooterBackColor { get; set; }

        //RichtTextBox

        public System.Drawing.Font richtTextBoxFont { get; set; }
        public Padding richtTextBoxPadding { get; set; }
        public BorderStyle richtTextBoxBorder { get; set; }

        //TabControl
        public System.Drawing.Font tabControlFont { get; set; }
        public Color tabControlTextColor { get; set; }

        //TabPage
        public System.Drawing.Font tabPageFont { get; set; }
        public Color tabPageTextColor { get; set; }
        public Color tabPageBackColor { get; set; }

        //TextBox
        public System.Drawing.Font textBoxFont { get; set; }
        public Color textBoxTextColor { get; set; }
        public Color textBoxBackColor { get; set; }
        public Padding textBoxPadding { get; set; }
        public Size textBoxSize { get; set; }
        public System.Drawing.Font textBoxMultilineFont { get; set; }
        public Padding textBoxMultilinePadding { get; set; }
        public Color textBoxMultilineTextColor { get; set; }

        // ToolStripButton
        public Color toolStripButtonTextColor { get; set; }
        public Color toolStripButtonBackColor_PanelLateral { get; set; }
        public Color toolStripButtonBackColor { get; set; }
        public System.Drawing.Font toolStripButtonFont { get; set; }

        //ListView
        public Color listViewTextColor { get; set; }     
        public Color listViewBackColor { get; set; }
        public System.Drawing.Font listViewFont { get; set; }
        public System.Drawing.Font subListViewFont { get; set; }


        //ListViewItem
        public Color listViewItemTextColor { get; set; }
        public Color listViewItemTotalBackColor { get; set; }
        public System.Drawing.Font listViewItemTotalFont { get; set; }     
        public Color listViewItemSubParBackColor { get; set; }
        public Color listViewItemSubImparBackColor { get; set; }
        public System.Drawing.Font listViewItemSublFont { get; set; }
        public Color listViewItemConditionalBackColor { get; set; }
        


        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public Color color3 { get; set; }
        public Color color4 { get; set; }
        public Color color5 { get; set; }
        public Color colorT1 { get; set; }
        public Color colorT2 { get; set; }
        public Color colorBG { get; set; }
        public Color colorBG1 { get; set; }
        public Color colorTBG1 { get; set; }
        public Color colorTBG2 { get; set; }
        public System.Drawing.Font fontHeader { get; set; }
        public System.Drawing.Font fontTextoListasHeaderBold { get; set; }
        public System.Drawing.Font fontTextoListasHeader { get; set; }
        public System.Drawing.Font fontTextoListasText { get; set; }
        public System.Drawing.Font fontTextoListasTextBold { get; set; }
        public System.Drawing.Font fontTextoListasTextSmall { get; set; }
    }
}
