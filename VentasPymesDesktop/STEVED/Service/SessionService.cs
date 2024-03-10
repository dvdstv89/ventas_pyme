using ModelData.Model;
using ModelData.Service.LocalDatabaseClient;
using ModelData;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using System.Linq;

namespace NucleoEV.Service
{
    internal class SessionService
    {
        public DateTime fechaProximaConciliacion(GrupoConciliacion grupo, Complejo complejo)
        {
            Conciliacion conciliacion = new ConciliacionLDB().ultimaConciliacionRealizada(grupo, complejo);
            return (conciliacion != null) ? conciliacion.fechaFin.sumarDias(1) : VariablesEntorno.primeraFechaValida;
        }
        public Configuracion getConfiguracion()
        {
            Configuracion configuracion = new ConfiguracionLDB().getConfiguracion();
            VariablesEntorno.conectionStringPostgres = configuracion.stringPostgresDb.conectionString;
            return configuracion;           
        }
        public PeriodoAbierto getPeriodoAbierto()
        {
            PeriodoAbierto periodoAbierto = new PeriodoAbiertoLDB().getPeriodoAbierto();
            VariablesEntorno.primeraFechaValida = periodoAbierto.minDateOfMount();
            VariablesEntorno.ultimaFechaValida = periodoAbierto.maxDateOfMount();
            VariablesEntorno.annoAbierto = periodoAbierto.annoAbierto;
            VariablesEntorno.mesAbierto = periodoAbierto.mesAbierto;
            return periodoAbierto;
        }
        public Empresa actualizarPlanesVentasTiendas(Empresa empresa)
        {
            for (int i = 0; i < empresa.complejos.Count; i++)
            {               
                empresa.complejos[i].updatePlanesVentas();
                empresa.complejos[i].tiendas.ForEach(t => t.updatePlanesVentas());
            }
            return empresa;
        }
        public Empresa actualizarPartesVentasTiendas(Empresa empresa)
        {
            for (int i = 0; i < empresa.complejos.Count; i++)
            {
               
                empresa.complejos[i].updatePartesVentas();
                empresa.complejos[i].tiendas.ForEach(t => t.updatePartesVentas());
            }
            return empresa;
        }
        public Empresa getEmpresaInSessionToken()
        {
            List<Empresa> empresas = new EmpresaLDB().inicializar();
            int id = VariablesEntorno.securityToken.empresa.Value;            
            return empresas.Find(x => x.id.getValueAsInt() == id);
        }
    }
}
