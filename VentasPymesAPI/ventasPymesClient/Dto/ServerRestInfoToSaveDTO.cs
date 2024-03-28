using ventasPymesClient.Model;

namespace ventasPymesClient.Dto
{
    [Serializable]
    public class ServerRestInfoToSaveDTO
    {
        public string rutaBackend { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public string token { get; set; }
        public bool checkApi { get; set; }
        public Protocol protocol { get; set; }
        public ServerRestInfoToSaveDTO()
        {
            rutaBackend = @"D:\Pyme\ventas_pyme\VentasPymesAPI\ventasPymes.api\bin\Debug\net7.0\ventasPymes.api.exe";
            protocol = Protocol.HTTP;
            host = "";
            port = 0;
            token = String.Empty;
            checkApi = true;
        }

        public bool apiRestHasInformation()
        {
            return host != "" && port != 0 ;
        }
    }
}
