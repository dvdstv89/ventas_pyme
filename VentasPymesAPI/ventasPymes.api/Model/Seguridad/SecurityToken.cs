using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Seguridad
{
    internal class SecurityToken
    {
        [Key]
        public Guid Token { get; set; }      
        public List<SecurityTokenRol> SecurityTokenRolPermisos { get; set; }
        public string Descripcion { get; set; }
        public Pyme Pyme { get; set; }

        public SecurityToken()
        {
            Token = Guid.NewGuid();
        }
    }
}
