using OfficeOpenXml;

namespace ModelData.Report.Hoja
{
    internal class Pagina<Tipo>:IHojaExcel where Tipo : IHojaExcel
    {
        string nombre;
        Tipo hoja;
        public Pagina(string nombre, Tipo hoja)
        {
            this.nombre = nombre;
            this.hoja = hoja;
        }
        public ExcelWorksheet getHoja(ExcelWorksheet excelWorksheet)
        {
           return hoja.getHoja(excelWorksheet);
        }
        public string getNombre()
        {
            return nombre;
        }
    }
}
