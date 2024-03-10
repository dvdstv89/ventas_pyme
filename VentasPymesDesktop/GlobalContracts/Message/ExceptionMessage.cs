using GlobalContracts.Model.Mensaje;

namespace GlobalContracts.Message
{
    public static class ExceptionMessage
    {          
        public static Mensaje MODULE_DB_CONEXION_FALLIDA = MensajeFactory.EXCEPTION("El modulo no fue instalado porque no se establecio conexion con la base de datos.");       
    }
}
