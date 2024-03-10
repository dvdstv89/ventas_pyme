using ModelData.DTO;
using ModelData.Report.Model;
using OfficeOpenXml;
using System;

namespace ModelData.Report.Hoja
{
    public class Hoja_ReporteParteVentaDiarioResumidoComplejo : Hoja_ReporteBase, IHojaExcel
    {
        ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo;        
        public Hoja_ReporteParteVentaDiarioResumidoComplejo(ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo) : base("Parte Diario y Acumulado", parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value, 10)
        {
            this.parteDiarioAcumuladosVentasResumidasComplejo = parteDiarioAcumuladosVentasResumidasComplejo;
        }
        public ExcelWorksheet getHoja(ExcelWorksheet hoja)
        {
            this.hoja = hoja;
            generarReporte();
            return hoja;
        }
        private new void generarReporte()
        {
            try
            {
                base.generarReporte();             
                textoBold(3, 1, "Mes:");
                ponerTexto(3, 2, parteDiarioAcumuladosVentasResumidasComplejo.mes.Mes);
                textoBold(3, 4, "Año:");
                ponerTexto(3, 5, parteDiarioAcumuladosVentasResumidasComplejo.anno.ToString());
                textoBold_ExtraLarge(5, 1, "Plan de Ingresos del Mes:", 2);
                ponerValorMoneda(5, 3, parteDiarioAcumuladosVentasResumidasComplejo.planMes);
                textoBold_ExtraLarge(5, 5, "Plan Acumulado del Mes anterior:", 3);
                ponerValorMoneda(5, 8, parteDiarioAcumuladosVentasResumidasComplejo.planAcumulado);
                textoBold_ExtraLarge(6, 1, "Plan Diario:", 2);
                ponerValorMoneda(6, 3, parteDiarioAcumuladosVentasResumidasComplejo.planDiario);
                textoBold_ExtraLarge(6, 5, "Real Acumulado del Mes anterior:", 3);
                ponerValorMoneda(6, 8, parteDiarioAcumuladosVentasResumidasComplejo.realAcumulado);
                textoBold_ExtraLarge_Bordered(8, 2, "VENTAS POR DIA", 3);
                textoBold_ExtraLarge_Bordered(8, 5, "ACUMULADO MES", 3);
                textoBold_ExtraLarge_Bordered(8, 8, "ACUMULADO AÑO", 3);
                textoBold_Bordered(9, 1, "DIA");
                textoBold_Bordered(9, 2, "PLAN");
                textoBold_Bordered(9, 3, "REAL");
                textoBold_Bordered(9, 4, "%");
                textoBold_Bordered(9, 5, "PLAN");
                textoBold_Bordered(9, 6, "REAL");
                textoBold_Bordered(9, 7, "%");
                textoBold_Bordered(9, 8, "PLAN");
                textoBold_Bordered(9, 9, "REAL");
                textoBold_Bordered(9, 10, "%");

                int fil = 10;
                for (int i = 0; i < parteDiarioAcumuladosVentasResumidasComplejo.ventaResumidaDias.Count; i++)
                {
                    VentaResumidaComplejoDia venta = parteDiarioAcumuladosVentasResumidasComplejo.ventaResumidaDias[i];

                    texto_Bordered(fil, 1, (i + 1).ToString());
                    money_Bordered(fil, 2, venta.planDiario);
                    money_Bordered(fil, 3, venta.ventaDia);
                    texto_Bordered(fil, 4, venta.porcientoCumplimientoVentasDia.Value);
                    money_Bordered(fil, 5, venta.planAcumuladoMes);
                    money_Bordered(fil, 6, venta.ventaAcumuladoMes);
                    texto_Bordered(fil, 7, venta.porcientoAcumuladasMes.Value);
                    money_Bordered(fil, 8, venta.planAcumuladoAnno);
                    money_Bordered(fil, 9, venta.ventaAcumuladoAnno);
                    texto_Bordered(fil++, 10, venta.porcientoAcumuladoAnno.Value);
                }
                texto_Bordered(fil, 1, "Total");
                texto_Bordered(fil, 2, "");
                texto_Bordered(fil, 3, "");
                texto_Bordered(fil, 4, "");
                money_Bordered(fil, 5, parteDiarioAcumuladosVentasResumidasComplejo.planMes);
                money_Bordered(fil, 6, parteDiarioAcumuladosVentasResumidasComplejo.getventaResumidasMes());
                texto_Bordered(fil, 7, parteDiarioAcumuladosVentasResumidasComplejo.porcientoMes().Value);
                money_Bordered(fil, 8, parteDiarioAcumuladosVentasResumidasComplejo.getPlanAcumuladoAnno());
                money_Bordered(fil, 9, parteDiarioAcumuladosVentasResumidasComplejo.getVentasAcumuladoAnno());
                texto_Bordered(fil, 10, parteDiarioAcumuladosVentasResumidasComplejo.porcientoAnno().Value);
                autoWith(1, 10);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}