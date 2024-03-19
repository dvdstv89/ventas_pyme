using ExternalSystem.Enum.Message;
using ExternalSystem.Fichero;
using MyUI.Service;
using System;

namespace ExternalSystem.Service
{
    public class FicheroService<Tipo>
    {
        public Tipo AbrirFichero()
        {
            try
            {
                File fichero = new File();
                return fichero.ExisteFichero() ? (Tipo)fichero.LeerFichero() : default;               
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public void GuardarFichero(Tipo model)
        {
            try
            {
                File fichero = new File();
                fichero.GuardarFichero(model);
                DialogService.SUCCESS(TextMensajeExternalSystem.FICHERO_GUARDADO);
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
