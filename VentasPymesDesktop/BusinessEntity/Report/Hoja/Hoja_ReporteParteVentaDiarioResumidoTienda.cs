using ModelData.Report.Model;
using OfficeOpenXml;
using System;

namespace ModelData.Report.Hoja
{
    public class Hoja_ReporteParteVentaDiarioResumidoTienda : Hoja_ReporteBase, IHojaExcel
    {
        ParteDiarioAcumuladosVentasResumidasTienda parteDiarioAcumuladosVentasResumidasTienda;        
        public Hoja_ReporteParteVentaDiarioResumidoTienda(ParteDiarioAcumuladosVentasResumidasTienda parteDiarioAcumuladosVentasResumidasTienda) : base("Parte Diario y Acumulado", parteDiarioAcumuladosVentasResumidasTienda.ubicacion, 10)
        {
            this.parteDiarioAcumuladosVentasResumidasTienda = parteDiarioAcumuladosVentasResumidasTienda;
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
                ponerTexto(3, 2, parteDiarioAcumuladosVentasResumidasTienda.mes.Mes);
                textoBold(3, 4, "Año:");
                ponerTexto(3, 5, parteDiarioAcumuladosVentasResumidasTienda.anno.ToString());
                textoBold_ExtraLarge(5, 1, "Plan de Ingresos del Mes:", 2);
                ponerTexto(5, 3, parteDiarioAcumuladosVentasResumidasTienda.planMes.getMoneyFormated());
                textoBold_ExtraLarge(5, 5, "Plan Acumulado del Mes anterior:", 3);
                ponerTexto(5, 8, parteDiarioAcumuladosVentasResumidasTienda.planAcumulado.getMoneyFormated());
                textoBold_ExtraLarge(6, 1, "Plan Diario:", 2);
                ponerTexto(6, 3, parteDiarioAcumuladosVentasResumidasTienda.planDiario.getMoneyFormated());
                textoBold_ExtraLarge(6, 5, "Real Acumulado del Mes anterior:", 3);
                ponerTexto(6, 8, parteDiarioAcumuladosVentasResumidasTienda.realAcumulado.getMoneyFormated());
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
                for (int i = 0; i < parteDiarioAcumuladosVentasResumidasTienda.ventaResumidaDias.Count; i++)
                {
                    VentaResumidaTiendaDia venta = parteDiarioAcumuladosVentasResumidasTienda.ventaResumidaDias[i];

                    texto_Bordered(fil, 1, (i + 1).ToString());
                    texto_Bordered(fil, 2, venta.planDiario.getMoneyFormated());
                    texto_Bordered(fil, 4, venta.porcientoCumplimientoVentasDia.Value);
                    texto_Bordered(fil, 7, venta.porcientoAcumuladasMes.Value);
                    texto_Bordered(fil, 10, venta.porcientoAcumuladoAnno.Value);

                    if (venta.isVentaRealizada)
                    {  
                        texto_Bordered(fil, 3, venta.ventaDia.getMoneyFormated());                       
                        texto_Bordered(fil, 5, venta.planAcumuladoMes.getMoneyFormated());
                        texto_Bordered(fil, 6, venta.ventaAcumuladoMes.getMoneyFormated());                      
                        texto_Bordered(fil, 8, venta.planAcumuladoAnno.getMoneyFormated());
                        texto_Bordered(fil++, 9, venta.ventaAcumuladoAnno.getMoneyFormated());
                    }
                    else
                    {
                        texto_Bordered(fil, 3, "");
                        texto_Bordered(fil, 5, "");
                        texto_Bordered(fil, 6, "");
                        texto_Bordered(fil, 8, "");
                        texto_Bordered(fil++, 9, "");
                    }
                }
                texto_Bordered(fil, 1, "Total");
                texto_Bordered(fil, 2, "");
                texto_Bordered(fil, 3, "");
                texto_Bordered(fil, 4, "");
                texto_Bordered(fil, 5, parteDiarioAcumuladosVentasResumidasTienda.planMes.getMoneyFormated());
                texto_Bordered(fil, 6, parteDiarioAcumuladosVentasResumidasTienda.getventaResumidasMes().getMoneyFormated());
                texto_Bordered(fil, 7, parteDiarioAcumuladosVentasResumidasTienda.porcientoMes().Value);
                texto_Bordered(fil, 8, parteDiarioAcumuladosVentasResumidasTienda.getPlanAcumuladoAnno().getMoneyFormated());
                texto_Bordered(fil, 9, parteDiarioAcumuladosVentasResumidasTienda.getVentasAcumuladoAnno().getMoneyFormated());
                texto_Bordered(fil, 10, parteDiarioAcumuladosVentasResumidasTienda.porcientoAnno().Value);
                autoWith(1, 10);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}