using System.Linq;
using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Dto
{   
    public class SecurityTokenDTO
    {
        public bool isSuperAdmin { get; }
        public string securityToken { get; }
        public List<Funcionalidad> funcionalidades { get; set; }      
        public SecurityTokenDTO(string securityToken)
        {
            isSuperAdmin = false;
            this.securityToken = securityToken;
            funcionalidades = new List<Funcionalidad>();
            isSuperAdmin = securityToken.Equals(VentasPymesClientMetadata.tokenProduccion)? true: false;
        }

        public bool existFunctionality(Funcionalidad funcionalidad)
        {
            return isSuperAdmin || funcionalidades.Exists(f => f.Equals(funcionalidad));
        }

    }
}
