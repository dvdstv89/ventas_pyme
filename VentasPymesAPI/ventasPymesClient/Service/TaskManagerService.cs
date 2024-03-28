using System.Diagnostics;
using ventasPymesClient.Dto;

namespace ventasPymesClient.Service
{
    public class TaskManagerService
    {         
        public TaskManagerService(ServerRestInfoToSaveDTO serverRestInfo) 
        {
            VentasPymesClientMetadata.initMetadata(serverRestInfo);
        }

        public void EjecutarServidorApiRest()
        {
            try
            {
                if (VentasPymesClientMetadata.serverRestInfo.checkApi && !isProcesoEnEjecucion(VentasPymesClientMetadata.nombreProceso))
                {
                    if (System.IO.File.Exists(VentasPymesClientMetadata.serverRestInfo.rutaBackend))
                    {
                        Process.Start(VentasPymesClientMetadata.serverRestInfo.rutaBackend);
                    }
                    //else
                    //{
                    //    DialogService.ERROR(Message.TextMensaje.ABRIR_BACKEND_APP_ERROR);
                    //}
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private bool isProcesoEnEjecucion(string nombreProceso)
        {
            try
            {
                Process[] procesos = Process.GetProcessesByName(nombreProceso);
                return procesos.Length > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
