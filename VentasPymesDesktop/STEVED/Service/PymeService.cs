using System;

namespace NucleoEV.Service
{
    internal class PymeService
    {   
        public bool empresaSeleccionada { get; set; }
        public PymeService()
        {
            empresaSeleccionada = false;

        }

        internal void buscarEmpresa()
        {
            try
            {
               empresaSeleccionada = true;

                //TODO: abrir selector de empresa

              
            }
            catch (Exception)
            {
                throw;           
            }            
        }

      
    }
}
