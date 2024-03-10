using ModelData.Report.Hoja;
using System.Diagnostics;
using System.IO;
using System;
using OfficeOpenXml;
using ModelData.Report.Model;
using System.Collections.Generic;
using ModelData.Model;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ModelData.DTO;

namespace ModelData.Report
{
    public static class ReporteFactory
    {  
        public static void getReporteParteVentaDiarioResumidoTienda(ParteDiarioAcumuladosVentasResumidasTienda parteDiarioAcumuladosVentasResumidasTienda)
        {
            List<IHojaExcel> hojas = new List<IHojaExcel>();
            hojas.Add(new Pagina<Hoja_ReporteParteVentaDiarioResumidoTienda>(parteDiarioAcumuladosVentasResumidasTienda.tienda.denominacion.Value, new Hoja_ReporteParteVentaDiarioResumidoTienda(parteDiarioAcumuladosVentasResumidasTienda)));
            string fileName = "Reporte.xlsx";
            generarReporte(hojas, fileName);
            if (VariablesEntorno.sendMail)
                saveAndSendFile(fileName, "destinatarioemail@example.com");
        }
        public static void getReporteParteVentaDiarioResumidoComplejo(ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo)
        {
            List<IHojaExcel> hojas = new List<IHojaExcel>();
            hojas.Add(new Pagina<Hoja_ReporteEstadoTiendasResumidasComplejo>("RESUMEN", new Hoja_ReporteEstadoTiendasResumidasComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            hojas.Add(new Pagina<Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo>("VENTAS DIARIAS", new Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            hojas.Add(new Pagina<Hoja_ReporteParteVentaDiarioResumidoComplejo>(parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value, new Hoja_ReporteParteVentaDiarioResumidoComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            string fileName = "Reporte.xlsx";
            generarReporte(hojas, fileName);
            if (VariablesEntorno.sendMail)
                saveAndSendFile(fileName, "destinatarioemail@example.com");
        }
        public static void getReporteParteVentaDiarioResumidoComplejoAndTiendas(ParteDiarioAcumuladosVentasResumidasComplejo parteDiarioAcumuladosVentasResumidasComplejo, List<ParteDiarioAcumuladosVentasResumidasTienda> parteDiarioAcumuladosVentasResumidasTiendas)
        {
            List<IHojaExcel> hojas = new List<IHojaExcel>();
            hojas.Add(new Pagina<Hoja_ReporteEstadoTiendasResumidasComplejo>("RESUMEN", new Hoja_ReporteEstadoTiendasResumidasComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            hojas.Add(new Pagina<Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo>("VENTAS DIARIAS", new Hoja_ReporteResumenVentasResumidasDiariasXTiendaComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            hojas.Add(new Pagina<Hoja_ReporteParteVentaDiarioResumidoComplejo>(parteDiarioAcumuladosVentasResumidasComplejo.complejo.denominacion.Value, new Hoja_ReporteParteVentaDiarioResumidoComplejo(parteDiarioAcumuladosVentasResumidasComplejo)));
            foreach (var tienda in parteDiarioAcumuladosVentasResumidasTiendas)
            {
                hojas.Add(new Pagina<Hoja_ReporteParteVentaDiarioResumidoTienda>(tienda.tienda.denominacion.Value, new Hoja_ReporteParteVentaDiarioResumidoTienda(tienda)));
            }

            string fileName = "Reporte.xlsx";
            generarReporte(hojas, fileName);
            if(VariablesEntorno.sendMail)
                saveAndSendFile(fileName, "destinatarioemail@example.com");          
        }

        private static void generarReporte<T>(List<T> hojas, string fileName) where T : IHojaExcel
        {
            string filePath = Path.GetTempPath() + fileName;
            applyLicenceExcelPackage();
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                foreach (T pagina in hojas)
                {
                    ExcelWorksheet sheet = workbook.Worksheets.Add(pagina.getNombre());
                    pagina.getHoja(sheet);
                }
                saveAndOpenFile(package, filePath);
            }
        }
        private static void applyLicenceExcelPackage()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        private static void saveAndOpenFile(ExcelPackage package, string tempFilePath)
        {
            package.SaveAs(new FileInfo(tempFilePath));
            try
            {
                System.Diagnostics.Process.Start(tempFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo abrir el archivo de Excel. Error: " + ex.Message);
            }
        }
        private static void saveAndSendFile(string fileName, string recipientEmail)
        {
            string filePath = Path.GetTempPath() + fileName;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("your-email@example.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Archivo adjunto de Excel";
                mail.Body = "Adjunto se encuentra el archivo de Excel generado.";

                Attachment attachment = new Attachment(filePath);
                attachment.Name = fileName;
                mail.Attachments.Add(attachment);

                using (SmtpClient smtp = new SmtpClient("smtp.example.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("your-email@example.com", "your-password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

    }
}