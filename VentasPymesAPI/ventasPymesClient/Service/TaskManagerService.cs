using System.Diagnostics;
using ventasPymesClient.Dto;

namespace ventasPymesClient.Service
{
    public class TaskManagerService
    {
        ServerRestInfoToSaveDTO serverRestInfo;
        public TaskManagerService(ServerRestInfoToSaveDTO serverRestInfo) 
        {
            this.serverRestInfo = serverRestInfo;            
        }

        public void EjecutarServidorApiRest()
        {
            try
            {
                if (serverRestInfo.checkApi && !isProcesoEnEjecucion(VentasPymesClientMetadata.nombreProceso) && System.IO.File.Exists(serverRestInfo.rutaBackend))
                {
                    Process.Start(serverRestInfo.rutaBackend);
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
