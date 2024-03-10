using ModelData.Model;
using ModelData.Service.LocalDatabaseClient;
using ModelData.Service.RemotoDatabaseClient;
using ModelData;
using System;
using System.Collections.Generic;


namespace NucleoEV.Service
{
    internal class SincronizacionService
    {  
        public bool chequearConectividadConServidor()
        {
            return new Database.CheckConectionService(VariablesEntorno.conectionStringPostgres).existeComunicacionConBDCentral();           
        }
        public void sincronizarTokenActual()
        {
            try
            {
                SecurityToken tokenLocal = new SecurityTokenLDB().getSecurityTokenSistema();
                if (chequearConectividadConServidor())
                {
                    SecurityToken tokenRemoto = new SecurityTokenRDB().getByToken(tokenLocal.token.Value);
                    bool tokenEsAutentico = new SecurityTokenLDB().updateFromRemoteData(tokenRemoto);
                    VariablesEntorno.securityToken = (tokenEsAutentico) ? tokenRemoto : null;                   
                }
                else
                {
                    VariablesEntorno.securityToken = tokenLocal;
                }              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void sincronizarNomencladoresRemoteToLocal()
        {
            if (chequearConectividadConServidor())
            {
                sincronizarServidorSMTP();
                bool monedaSincronizada = new MonedaLDB().updateFromRemoteData(new MonedaRDB().getAll());
                bool grupoConsiliacionSincronizada = new GrupoConciliacionLDB().updateFromRemoteData(new GrupoConciliacionRDB().getAll());
                sincronizarEmpresa();
                bool complejoSincronizado = new ComplejoLDB().updateFromRemoteData(new ComplejoRDB().getAll());
                bool periodoAbiertoSincronizado = new PeriodoAbiertoLDB().updateFromRemoteData(new PeriodoAbiertoRDB().getById(VariablesEntorno.idPeriodoAbierto));
                bool formaPagoSincronizado = new FormaPagoLDB().updateFromRemoteData(new FormaPagoRDB().getAll());
                bool metrocontadorSincronizado = new MetrocontadorLDB().updateFromRemoteData(new MetrocontadorRDB().getAll());
            }
        }        
        public void sincronizarConServidor()
        {
            if (chequearConectividadConServidor())
            {
                sincronizarTienda();
                sincronizarConciliacion(); //local                   
                sincronizarPlanVentaDelAnnoAbierto();              
                sincronizarPlanServicioDelAnnoAbierto();
                sincronizarParteMetrocontadores();
                sincronizarParteVenta();               
            }
        }
        public void sincronizarPlanVentaDelAnnoAbierto()
        {
            if (chequearConectividadConServidor())
            {
                bool planVentaMensualLocalSincronizado = new PlanVentaMensualLDB().updateFromRemoteData(new PlanVentaMensualRDB().getByAnno());
                bool planVentaMensualRemotaSincronizado = new PlanVentaMensualRDB().updateFromLocalData(new PlanVentaMensualLDB().getByAnnoNoSincronizados());               
            }
        }
        public void sincronizarPlanServicioDelAnnoAbierto()
        {
            if (chequearConectividadConServidor())
            {
                List<Metrocontador> metrocontadores = MetrocontadoresData.getAllMetroContadores();
                bool planServicioMensualLocalSincronizado = new PlanServicioMensualLDB().updateFromRemoteData(new PlanServicioMensualRDB().getByAnno());
                bool planServicioMensualRemotaSincronizado = new PlanServicioMensualRDB().updateFromLocalData(new PlanServicioMensualLDB().getByAnnoNoSincronizados());              
            }
        }
        public void sincronizarTienda()
        {
            if (chequearConectividadConServidor())
            {
                bool tiendaLocalSincronizado = new TiendaLDB().updateFromRemoteData(new TiendaRDB().getAll());
                bool tiendaRemotaSincronizado = new TiendaRDB().updateFromLocalData(new TiendaLDB().getActivasByComplejosNotSincronizados(VariablesEntorno.securityToken.getIdComplejos()));                
            }
        }
        public void sincronizarParteVenta()
        {
            if (chequearConectividadConServidor())
            {
                bool parteVentaDiarioLocalSincronizado = new ParteVentaDiarioLDB().updateFromRemoteData(new ParteVentaDiarioRDB().getNoSincronizadosMesActual());
                bool parteVentaDiarioRemotaSincronizado = new ParteVentaDiarioRDB().updateFromLocalData(new ParteVentaDiarioLDB().getNoSincronizadosMesActual());               
            }
        }
        public void sincronizarParteMetrocontadores()
        {
            if (chequearConectividadConServidor())
            {
                bool parteMetroContadorLocalSincronizado = new ParteServicioDiarioLDB().updateFromRemoteData(new ParteServicioDiarioRDB().getNoSincronizadosMesActual());
                bool parteMetroContadorRemotaSincronizado = new ParteServicioDiarioRDB().updateFromLocalData(new ParteServicioDiarioLDB().getNoSincronizadosMesActual());               
            }
        }
        public void sincronizarConciliacion()
        {
            if (chequearConectividadConServidor())
            {
                bool conciliacionLocalSincronizado = new ConciliacionLDB().updateFromRemoteData(new ConciliacionRDB().getNoSincronizadosMesActual());
                bool conciliacionRemotaSincronizado = new ConciliacionRDB().updateFromLocalData(new ConciliacionLDB().getNoSincronizadosMesActual());              
            }
        }        
        public void sincronizarParteVenta(Conciliacion conciliacion)
        {
            if (chequearConectividadConServidor())
            {
                bool parteVentaDiarioLocalSincronizado = new ParteVentaDiarioLDB().updateFromRemoteData(new ParteVentaDiarioRDB().getNoSincronizadosMesActual());
                bool parteVentaDiarioRemotaSincronizado = new ParteVentaDiarioRDB().updateFromLocalData(new ParteVentaDiarioLDB().getByConciliacion(conciliacion));              
            }
        }
        public void sincronizarEmpresa()
        {
            if (chequearConectividadConServidor())
            {
                bool empresaSincronizada = new EmpresaLDB().updateFromRemoteData(new EmpresaRDB().getById(VariablesEntorno.securityToken.empresa.Value));
            }
        }
        public void sincronizarServidorSMTP()
        {
            if (chequearConectividadConServidor())
            {
                bool servidorSMTPLocalSincronizado = new ServidorSmtpLDB().updateFromRemoteData(new ServidorSmtpRDB().getAll());
            }
        }
    }
}
