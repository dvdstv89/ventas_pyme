using ExternalSystem.Fichero;
using GlobalContracts.Message;
using GlobalContracts.Model;
using MyUI.Service;
using System;

namespace ExternalSystem.Service
{
    public class FicheroService<Tipo> where Tipo: BaseDTO
    {
        Tipo model;
        public FicheroService(Tipo model)
        {
            this.model = model;
        }
       
        public bool AbrirFichero()
        {
            try
            {
                File fichero = new File();
                if (fichero.ExisteFichero())
                {
                    model = (Tipo)fichero.LeerFichero();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GuardarFichero()
        {
            try
            {
                File fichero = new File();
                fichero.GuardarFichero(model);
                DialogService.ShowDialog(SuccessMessage.FICHERO_GUARDADO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tipo GetTipo()
        {
            return model;
        }
    }
}
