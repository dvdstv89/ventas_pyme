using GlobalContracts.Model.Mensaje;

namespace GlobalContracts.Message
{
    public static class ErrorMessage
    {          
        public static Mensaje DATABASE_NO_DISPONIBLE = MensajeFactory.ERROR("No se puede establecer comunicación con la base de datos. Por favor revise los datos de conexión.", "");
        public static Mensaje MODULE_VERSION_INCORRECTA = MensajeFactory.ERROR("La versión de los modulo no coincide con la de los desplegados en el servidor.", "");
        public static Mensaje FICHERO_CONFIGURACION_CORRUPTO = MensajeFactory.ERROR("El fichero de configuración esta corrupto, por favor reparelo.", "");
    }
}
