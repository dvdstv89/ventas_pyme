using ModelData.DTO;
using ModelData.Report.Model;
using OfficeOpenXml;
using System;

namespace ModelData.Report.Hoja
{
    public class Hoja_ReporteEstadoTiendasResumidasComplejo : Hoja_ReporteBase, IHojaExcel
    {
        ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo;        
        public Hoja_ReporteEstadoTiendasResumidasComplejo(ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo) : base("Estado actual de las tiendas", parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value, 10)
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
                HeadingTextoFullRow(1, 1, nombreReporte);
                textoBold(2, 2, "Mes:");
                ponerTexto(2, 3, parteDiarioAcumuladosVentasResumidasComplejo.mes.Mes);
                textoBold(2, 5, "Año:");
                ponerTexto(2, 6, parteDiarioAcumuladosVentasResumidasComplejo.anno.ToString());             
                textoBold_ExtraLarge_Bordered(4, 2, "MES", 6);              
                textoBold_ExtraLarge_Bordered(4, 8, "AÑO", 3);
                textoBold_Bordered(5, 1, "TIENDA");
                textoBold_Bordered(5, 2, "PLAN DIARIO");
                textoBold_Bordered(5, 3, "PLAN MES");
                textoBold_Bordered(5, 4, "REAL VENTAS");
                textoBold_Bordered(5, 5, "% VIVO");
                textoBold_Bordered(5, 6, "% MES");
                textoBold_Bordered(5, 7, "FALTAN PLAN");
                textoBold_Bordered(5, 8, "PLAN");
                textoBold_Bordered(5, 9, "REAL");
                textoBold_Bordered(5, 10, "% AÑO");

                int fil = 6;
                for (int i = 0; i < parteDiarioAcumuladosVentasResumidasComplejo.estadoTiendaMes.Count; i++)
                {
                    EstadoResumidoTiendaMes venta = parteDiarioAcumuladosVentasResumidasComplejo.estadoTiendaMes[i];
                    texto_Bordered(fil, 1, venta.tienda.denominacion.Value);
                    texto_Bordered(fil, 2, venta.planDiario.getMoneyFormated());
                    texto_Bordered(fil, 3, venta.planMes.getMoneyFormated());
                    texto_Bordered(fil, 4, venta.ventasMes.getMoneyFormated());
                    texto_Bordered(fil, 5, venta.porcientoVentasVivo.Value);
                    texto_Bordered(fil, 6, venta.porcientoMes.Value);
                    texto_Bordered(fil, 7, venta.faltaMes.getMoneyFormated());
                    texto_Bordered(fil, 8, venta.planAnno.getMoneyFormated());
                    texto_Bordered(fil, 9, venta.ventaAnno.getMoneyFormated());
                    texto_Bordered(fil++, 10, venta.porcientoAnno.Value);
                }
                texto_Bordered(fil, 1, parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value);
                texto_Bordered(fil, 2, parteDiarioAcumuladosVentasResumidasComplejo.planDiario.getMoneyFormated());
                texto_Bordered(fil, 3, parteDiarioAcumuladosVentasResumidasComplejo.planMes.getMoneyFormated());
                texto_Bordered(fil, 4, parteDiarioAcumuladosVentasResumidasComplejo.getventaResumidasMes().getMoneyFormated());
                texto_Bordered(fil, 5, parteDiarioAcumuladosVentasResumidasComplejo.porcientoVivoMes().Value);
                texto_Bordered(fil, 6, parteDiarioAcumuladosVentasResumidasComplejo.porcientoMes().Value);
                texto_Bordered(fil, 7, parteDiarioAcumuladosVentasResumidasComplejo.getFaltaMes().getMoneyFormated());
                texto_Bordered(fil, 8, parteDiarioAcumuladosVentasResumidasComplejo.complejo.planVentaAnno.getMoneyFormated());
                texto_Bordered(fil, 9, parteDiarioAcumuladosVentasResumidasComplejo.complejo.ventasRealesResumidasAnnoActual.getMoneyFormated());
                texto_Bordered(fil, 10, parteDiarioAcumuladosVentasResumidasComplejo.complejo.porcientoVentaResumidaAnnoActual.Value);
                autoWith(1, 10);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}