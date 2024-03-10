using Database.Class;
using ModelData.DTO;
using ModelData.Model;
using ModelData.Report.Model;
using OfficeOpenXml;
using System;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace ModelData.Report.Hoja
{
    public class Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo : Hoja_ReporteBase, IHojaExcel
    {
        ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo;        
        public Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo(ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo) : base("Resumen de ventas diarias", parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value, parteDiarioAcumuladosVentasResumidasComplejo.mes.countDays() + 2)
        {
            this.parteDiarioAcumuladosVentasResumidasComplejo = parteDiarioAcumuladosVentasResumidasComplejo;
        }       
        protected override void generarReporte()
        {
            try
            {
                Atributo_Mes mes = parteDiarioAcumuladosVentasResumidasComplejo.mes;
                HeadingTextoFullRow(1, 1, nombreReporte);
                textoBold(2, 2, "Mes:");
                ponerTexto(2, 3, parteDiarioAcumuladosVentasResumidasComplejo.mes.Mes);
                textoBold(2, 5, "Año:");
                ponerTexto(2, 6, parteDiarioAcumuladosVentasResumidasComplejo.anno.ToString());             
                textoBold_ExtraLarge_Bordered(4, 2, "DIAS", mes.countDays());
                textoBold_Bordered(5, 1, "TIENDA");
                for (int i = 0; i < mes.countDays(); i++)
                {
                    textoBold_Bordered(5, 2 + i, (i+1).ToString());
                }              
                textoBold_Bordered(5, 2+ mes.countDays(), "TOTAL");

                int fil = 6;
                foreach (Tienda tienda in parteDiarioAcumuladosVentasResumidasComplejo.complejo.tiendas)
                {                   
                    texto_Bordered(fil, 1, tienda.denominacion.Value);
                    for (int j = 0; j < mes.countDays(); j++)
                    {
                        texto_Bordered(fil, 2+j, tienda.getVentaTotalDia(mes.Value, j+1, true).getMoneyFormated());
                    }
                    texto_Bordered(fil++, mes.countDays()+2, tienda.getVentasRealesResumidasMes(mes.Value).getMoneyFormated());                   
                }
                texto_Bordered(fil, 1, "TOTAL");
                for (int i = 0; i < mes.countDays(); i++)
                {
                    texto_Bordered(fil, 2 + i, parteDiarioAcumuladosVentasResumidasComplejo.complejo.getVentaTotalDia(mes.Value, i + 1,true).getMoneyFormated());
                }
                texto_Bordered(fil, mes.countDays()+2, parteDiarioAcumuladosVentasResumidasComplejo.complejo.getVentasRealesResumidasMes(mes.Value).getMoneyFormated());
                autoWith(1, mes.countDays()+2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}