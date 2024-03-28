using ExternalSystem.Service;
using NucleoEV.Model;
using NucleoEV.UI;
using NucleoEV.UIController;
using System.Windows.Forms;
using System;
using NucleoEV.Message;
using MyUI.Service;

namespace NucleoEV.Service
{
    internal class AppService
    {      
        Session session;
        readonly ExternalSystemService externalSystem;
        readonly EmpresaService empresaService;

        public AppService(Session session)
        {
           this.session = session;         
           this.externalSystem = new ExternalSystemService();
            this.empresaService = new EmpresaService();
        }

        internal Form ejecutarApp()
        {
            try
            {
                verificarFicheroConfiguracion();
                probarServicioRest();

                //abrir selector de empresa
                empresaService.buscarEmpresa();

                return abrirFormularioPrincipal();
            }
            catch (Exception)
            {
                throw;           
            }            
        }

        internal Form abrirFormularioPrincipal()
        {
            var mainUI = new MainUI();
            var mainUIService = new MainUIService(session);
            var mainUIController = new MainUIController(mainUIService, mainUI);
            return mainUIController.Ejecutar();
        }

        internal void verificarFicheroConfiguracion()
        {
            bool isFicheroCorrecto = externalSystem.verificarFicheroConfiguracion();
            if (isFicheroCorrecto == false) 
            { 
                throw new Exception(TextMensajeNucleo.METADADOS_INCORRECTOS.ToString());                
            }           
        }

        internal async void probarServicioRest()
        {
            bool existConexion = await externalSystem.probarServicioRestAsync();
            if (existConexion == false)
            {
                DialogService.ERROR(TextMensajeNucleo.VERIFICANDO_CONEXION_SERVIDOR_ERROR);
                verificarFicheroConfiguracion();
            }            
        }
    }
}
