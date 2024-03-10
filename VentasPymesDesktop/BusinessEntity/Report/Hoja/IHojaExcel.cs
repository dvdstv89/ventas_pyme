using OfficeOpenXml;

namespace ModelData.Report.Hoja
{
    public interface IHojaExcel
    {
        ExcelWorksheet getHoja(ExcelWorksheet hoja);
        string getNombre();
    }
}
