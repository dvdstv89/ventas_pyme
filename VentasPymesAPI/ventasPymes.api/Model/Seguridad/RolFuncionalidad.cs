using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;
using ventasPymesClient.Model.Enums;

namespace ventasPymes.api.Model.Seguridad
{
    internal class RolFuncionalidad
    {
        [Key]
        public Guid Id { get; set; }
        public Nomenclador Rol { get; set; } //Administrador
        public Funcionalidad Funcionalidad { get; set; } //Funcionalidad.ChequearStatusApi
        public SecurityTokenRol SecurityTokenRol { get; set; }

        public RolFuncionalidad()
        {
            Id = Guid.NewGuid();
            Rol = new Nomenclador(TipoNomenclador.Rol);          
        }
    }
}
