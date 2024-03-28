using ExternalSystem.Message;
using ExternalSystem.Fichero;
using MyUI.Service;
using System;

namespace ExternalSystem.LocalService
{
    public class FicheroService<Tipo>
    {
        File fichero;

        public FicheroService()
        {
            fichero = new File();
        }

        public Tipo AbrirFichero()
        {
            try
            {              
                return fichero.ExisteFichero() ? (Tipo)fichero.LeerFichero() : default;               
            }
            catch (Exception)
            {               
                return default;
            }
        }
        public void GuardarFichero(Tipo model)
        {
            try
            {               
                fichero.GuardarFichero(model);
                DialogService.SUCCESS(TextMensaje.FICHERO_GUARDADO);
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public void DeleteFichero()
        {
            try
            {               
                fichero.EliminarFichero();               
            }
            catch (Exception)
            {               
                throw;
            }
        }
    }
}
