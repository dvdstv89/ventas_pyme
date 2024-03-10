using ModelData.Model;
using NucleoEV.Tema;
using System;
using System.Collections.Generic;
using System.Globalization;
using ModelData;
using NucleoEV.Service;
using Database.Class;
using NucleoEV.UI;

namespace NucleoEV.Model
{
    internal class Session
    {       
        public Configuracion configuracion { get; set; }
        public PeriodoAbierto periodoAbierto { get; set; }
        public Empresa empresa { get; set; }      
        public TemaAplication temaAplication { get; }
        public bool tokenEsAutentico { get; set; }
        public CultureInfo cultureInfo { get; set; }       
        public bool sincronizacionAutomatica { get; set; }
        SincronizacionService sincronizacionService;      
        SessionService sessionService;
        public Session(CultureInfo cultureInfo)
        {
            this.sessionService = new SessionService();
            this.sincronizacionService = new SincronizacionService();           
            this.cultureInfo = cultureInfo;
            this.tokenEsAutentico = true;
            this.temaAplication = new TemaAplication();
            this.configuracion = sessionService.getConfiguracion();
            sincronizacionService.sincronizarTokenActual();            
            if (VariablesEntorno.securityToken != null)
            {
                sincronizacionService.sincronizarNomencladoresRemoteToLocal();
                this.periodoAbierto = sessionService.getPeriodoAbierto();                
                this.empresa = sessionService.getEmpresaInSessionToken();
                sincronizacionService.sincronizarConServidor();
                empresa.complejos = ComplejoData.getByComplejosAutorizadosInSessionToken();                
                actualizarPlanesVentasTiendas();
                actualizarPartesVentasTiendas();
            }
        }       
        public void actualizarPlanesVentasTiendas()
        {
            this.empresa = sessionService.actualizarPlanesVentasTiendas(this.empresa);          
        }
        public void actualizarPartesVentasTiendas()
        {
            this.empresa = sessionService.actualizarPartesVentasTiendas(this.empresa);
        }
        public DateTime fechaProximaConciliacion(GrupoConciliacion grupo, Complejo complejo)
        {
            return sessionService.fechaProximaConciliacion(grupo, complejo);           
        } 
        public DateTime makeDate(int dia) 
        {
            return new DateTime(VariablesEntorno.annoAbierto.Value, VariablesEntorno.mesAbierto.Value, dia);           
        }      
        public static int countDaysOfMounth(int mes = 0)
        {
            if (mes == 0)
                mes = VariablesEntorno.mesAbierto.Value;
            Atributo_Mes mesAux = new Atributo_Mes(mes, "");
            return mesAux.countDays(VariablesEntorno.annoAbierto.Value);            
        }
        public string getTokenId()
        {
            return VariablesEntorno.securityToken.token.Value;
        }
        public void sincronizarPlanVentaDelAnnoAbierto()
        {
            sincronizacionService.sincronizarPlanVentaDelAnnoAbierto();
        }
        public void sincronizarConciliacion()
        {
            sincronizacionService.sincronizarConciliacion();
        }
        public void sincronizarParteVenta()
        {
            sincronizacionService.sincronizarParteVenta();
        }
        public void sincronizarParteVenta(Conciliacion conciliacion)
        {
            sincronizacionService.sincronizarParteVenta(conciliacion);
        }
        public bool chequearConectividadConServidor()
        {
            return sincronizacionService.chequearConectividadConServidor();
        }
        public void sincronizarEmpresa()
        {
            sincronizacionService.sincronizarEmpresa();
        }
        public void sincronizarServidorSMTP()
        {
            sincronizacionService.sincronizarServidorSMTP();
        }
    }
}
