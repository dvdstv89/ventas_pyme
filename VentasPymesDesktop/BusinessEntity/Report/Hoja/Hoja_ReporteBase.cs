using ModelData.Atributo;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModelData.Report.Hoja
{
    public class Hoja_ReporteBase
    {
        protected ExcelWorksheet hoja;
        protected string nombreReporte;
        protected string ubicacion;
        protected int anchoReporte;
        public object ExcelLineFormat { get; private set; }
        public Hoja_ReporteBase(string nombreReporte, string ubicacion, int anchoReporte)
        {                          
            this.nombreReporte = nombreReporte;          
            this.ubicacion = ubicacion;
            this.anchoReporte = anchoReporte;
        }
        public virtual ExcelWorksheet getHoja(ExcelWorksheet hoja)
        {
            this.hoja = hoja;
            generarReporte();
            return hoja;
        }

        protected virtual void generarReporte()
        {
            HeadingTextoFullRow(1, 1, nombreReporte);
            HeadingTextoFullRow(2, 1, ubicacion);
        }
        protected void HeadingTextoFullRow(int fila, int columna, string texto)
        {
            textoBold_ExtraLarge(fila, columna, texto, anchoReporte);          
        }
        protected void textoBold_Bordered(int fila, int columna, string texto)
        {
            texto_Bordered(fila, columna, texto);          
            fuenteNegrita(fila, columna);
            centerAling(fila, columna);
        }
        protected void textoBold(int fila, int columna, string texto)
        {
            ponerTexto(fila, columna, texto);
            fuenteNegrita(fila, columna);
        }
        protected void texto_Bordered(int fila, int columna, string texto)
        {
            ponerTexto(fila, columna, texto);
            ponerBorder(fila, columna, 1);
        }
        protected void money_Bordered(int fila, int columna, Atributo_Money money)
        {
            ponerValorMoneda(fila, columna, money);
            ponerBorder(fila, columna, 1);
        }
        protected void textoBold_ExtraLarge(int fila, int columna, string texto, int large)
        {
            ponerTexto(fila, columna, texto);          
            fuenteNegrita(fila, columna);           
            combinarCeldasHorizontales(fila, columna, large);
        }
        protected void textoBold_ExtraLarge_Bordered(int fila, int columna, string texto, int large)
        {
            ponerTexto(fila, columna, texto);
            fuenteNegrita(fila, columna);            
            ponerBorder(fila, columna, large);
            centerAling(fila, columna);
            combinarCeldasHorizontales(fila, columna, large);
        }
        protected void ponerTexto(int fila, int columna, string texto)
        {
            hoja.Cells[fila, columna].Value = texto;           
        }
        protected void ponerValorMoneda(int fila, int columna, Atributo_Money money)
        {
            hoja.Cells[fila, columna].Value = money.MoneyAccount;
            hoja.Cells[fila, columna].Style.Numberformat.Format = money.getMoneyFormatText();
        }
        protected void combinarCeldasHorizontales(int fila, int columnaInicio, int large )
        {
            string rango = crearRango(fila, columnaInicio, large);          
            hoja.Cells[rango].Merge = true;          
        }        
        protected void fuenteNegrita(int fila, int columna)
        {
            hoja.Cells[fila, columna].Style.Font.Bold = true;
        }       
        private void ponerBorder(int fila, int columnaInicio, int large = 1)
        {           
            string rango = crearRango(fila, columnaInicio, large);
            hoja.Cells[rango].Style.Border.BorderAround(ExcelBorderStyle.Thin);                    
        }
        private string crearRango(int fila, int columnaInicio, int large)
        {
            if(large == 1)
                return convertIntToString(columnaInicio) + fila.ToString();
            return convertIntToString(columnaInicio) + fila + ":" + convertIntToString(columnaInicio + large - 1) + fila;
        }
        protected void autoWith(int columnaInicio, int columnaFin)
        {
            for (int i = columnaInicio; i <= columnaFin; i++)
            {
                hoja.Columns[i].AutoFit();
            }
        }
        private void centerAling(int fila, int columnaInicio, int large = 1)
        {
            string rango = crearRango(fila, columnaInicio, large = 1);
            hoja.Cells[rango].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;            
        }
        public string getNombre()
        {
            return nombreReporte;
        }
        private string convertIntToString(int col)
        {
            switch (col)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                case 5: return "E";
                case 6: return "F";
                case 7: return "G";
                case 8: return "H";
                case 9: return "I";
                case 10: return "J";
                case 11: return "K";
                case 12: return "L";
                case 13: return "M";
                case 14: return "N";
                case 15: return "O";
                case 16: return "P";
                case 17: return "Q";
                case 18: return "R";
                case 19: return "S";
                case 20: return "T";
                case 21: return "U";
                case 22: return "V";
                case 23: return "W";
                case 24: return "X";
                case 25: return "Y";
                case 26: return "Z";
                case 27: return "AA";
                case 28: return "AB";
                case 29: return "AC";
                case 30: return "AD";
                case 31: return "AE";
                case 32: return "AF";
                case 33: return "AG";
                case 34: return "AH";
                case 35: return "AI";
                case 36: return "AJ";
                default:
                    return "AK";
            }
        }
    }
}