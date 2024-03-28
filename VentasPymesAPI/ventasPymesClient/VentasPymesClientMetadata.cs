using ventasPymesClient.Dto;
using ventasPymesClient.Model;

namespace ventasPymesClient
{
    public static class VentasPymesClientMetadata
    {
        public static ServerRestInfoToSaveDTO serverRestInfo;
        public static readonly string nombreProceso = "ventasPymes.api";        
        internal static ServerRest serverRest = null;        
        internal static bool isMetadataInicializada = false;
        
        internal static void initMetadata(ServerRestInfoToSaveDTO serverRestInfoToSaveDTO)
        {
            if(serverRestInfoToSaveDTO == null)
                serverRestInfoToSaveDTO = new ServerRestInfoToSaveDTO();

            serverRestInfo = serverRestInfoToSaveDTO;           
            serverRest = new ServerRest()
            {
                host = serverRestInfoToSaveDTO.host,
                port = serverRestInfoToSaveDTO.port,
                protocol = serverRestInfoToSaveDTO.protocol,
                token = serverRestInfoToSaveDTO.token,                
            };
            isMetadataInicializada= true;
        }
    }
}
