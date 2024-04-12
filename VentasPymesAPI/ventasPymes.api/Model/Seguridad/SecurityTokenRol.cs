using System.ComponentModel.DataAnnotations;

namespace ventasPymes.api.Model.Seguridad
{
    internal class SecurityTokenRol
    {
        [Key]
        public Guid Id { get; set; }    
        public SecurityToken SecurityToken { get; set; }
        public List<RolFuncionalidad> RolFuncionalidades { get; set; }
        public SecurityTokenRol()
        {
            Id = Guid.NewGuid();
        }
    }
}
