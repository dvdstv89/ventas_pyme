using ventasPymesClient.Dto;

namespace ventasPymesClient
{
    public static class VentasPymesClientMetadata
    {
        public static string tokenProduccion = "1234";
        public static SecurityTokenDTO securityToken = null;
        public static ServerRestInfoToSaveDTO serverRestInfo = null;
        public static readonly string nombreProceso = "ventasPymes.api";        
        internal static ServerRest serverRest = null;        
        internal static bool isMetadataInicializada = false;
        
        public static void initMetadata(ServerRestInfoToSaveDTO serverRestInfoToSaveDTO)
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
            securityToken = new SecurityTokenDTO(serverRest.token);
            isMetadataInicializada = true;
        }      
    }
}
