using GlobalContracts.Model.Mensaje;

namespace GlobalContracts.Message
{
    public static class SuccessMessage
    {   
        public static Mensaje FICHERO_GUARDADO = MensajeFactory.SUCCESS("El fichero de configuración fue actualizado satisfactoriamente", "");
        public static Mensaje PRUEBA_CONECTIVIDAD_DATABASE = MensajeFactory.SUCCESS("Se establecio la conexión con la base de datos satifactoriamente", "");
    }
}
