using Database;
using ModelData.Model;

namespace ModelData.Repository
{
    internal static class RepositoryFactory
    {
        public static ComplejoRepository Complejo_Postgres()
        {
            return new ComplejoRepository(new Complejo(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ComplejoRepository Complejo_Local()
        {
            return new ComplejoRepository(new Complejo(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static ConciliacionRepository Conciliacion_Postgres()
        {
            return new ConciliacionRepository(new Conciliacion(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ConciliacionRepository Conciliacion_Local()
        {
            return new ConciliacionRepository(new Conciliacion(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static ConfiguracionRepository Configuracion_Postgres()
        {
            return new ConfiguracionRepository(new Configuracion(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ConfiguracionRepository Configuracion_Local()
        {
            return new ConfiguracionRepository(new Configuracion(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static EmpresaRepository Empresa_Postgres()
        {
            return new EmpresaRepository(new Empresa(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static EmpresaRepository Empresa_Local()
        {
            return new EmpresaRepository(new Empresa(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static FormaPagoRepository FormaPago_Postgres()
        {
            return new FormaPagoRepository(new FormaPago(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static FormaPagoRepository FormaPago_Local()
        {
            return new FormaPagoRepository(new FormaPago(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static GrupoConciliacionRepository GrupoConciliacion_Postgres()
        {
            return new GrupoConciliacionRepository(new GrupoConciliacion(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static GrupoConciliacionRepository GrupoConciliacion_Local()
        {
            return new GrupoConciliacionRepository(new GrupoConciliacion(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static MonedaRepository Moneda_Postgres()
        {
            return new MonedaRepository(new Moneda(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static MonedaRepository Moneda_Local()
        {
            return new MonedaRepository(new Moneda(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static ParteVentaDiarioRepository ParteVentaDiario_Postgres()
        {
            return new ParteVentaDiarioRepository(new ParteVentaDiario(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ParteVentaDiarioRepository ParteVentaDiario_Local()
        {
            return new ParteVentaDiarioRepository(new ParteVentaDiario(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PeriodoAbiertoRepository PeriodoAbierto_Postgres()
        {
            return new PeriodoAbiertoRepository(new PeriodoAbierto(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PeriodoAbiertoRepository PeriodoAbierto_Local()
        {
            return new PeriodoAbiertoRepository(new PeriodoAbierto(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }      
        public static PlanVentaMensualRepository PlanVentaMensual_Postgres()
        {
            return new PlanVentaMensualRepository(new PlanVentaMensual(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanVentaMensualRepository PlanVentaMensual_Local()
        {
            return new PlanVentaMensualRepository(new PlanVentaMensual(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static SecurityTokenRepository SecurityToken_Postgres()
        {
            return new SecurityTokenRepository(new SecurityToken(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static SecurityTokenRepository SecurityToken_Local()
        {
            return new SecurityTokenRepository(new SecurityToken(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }     
        public static TiendaRepository Tienda_Postgres()
        {
            return new TiendaRepository(new Tienda(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static TiendaRepository Tienda_Local()
        {
            return new TiendaRepository(new Tienda(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static MetrocontadorRepository Metrocontador_Postgres()
        {
            return new MetrocontadorRepository(new Metrocontador(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static MetrocontadorRepository Metrocontador_Local()
        {
            return new MetrocontadorRepository(new Metrocontador(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static ParteServicioDiarioRepository ParteMetrocontador_Postgres()
        {
            return new ParteServicioDiarioRepository(new ParteServicioDiario(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ParteServicioDiarioRepository ParteServicioDiario_Local()
        {
            return new ParteServicioDiarioRepository(new ParteServicioDiario(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static ServidorSmtpRepository ServidorSmtp_Postgres()
        {
            return new ServidorSmtpRepository(new ServidorSMTP(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static ServidorSmtpRepository ServidorSmtp_Local()
        {
            return new ServidorSmtpRepository(new ServidorSMTP(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PlanServicioMensualRepository PlanServicioMensual_Postgres()
        {
            return new PlanServicioMensualRepository(new PlanServicioMensual(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanServicioMensualRepository PlanServicioMensual_Local()
        {
            return new PlanServicioMensualRepository(new PlanServicioMensual(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PlanServicioComplejoRepository PlanServicioComplejo_Postgres()
        {
            return new PlanServicioComplejoRepository(new PlanServicioComplejo(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanServicioComplejoRepository PlanServicioComplejo_Local()
        {
            return new PlanServicioComplejoRepository(new PlanServicioComplejo(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PlanServicioMetrocontadorRepository PlanServicioMetrocontador_Postgres()
        {
            return new PlanServicioMetrocontadorRepository(new PlanServicioMetrocontador(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanServicioMetrocontadorRepository PlanServicioMetrocontador_Local()
        {
            return new PlanServicioMetrocontadorRepository(new PlanServicioMetrocontador(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PlanVentaComplejoRepository PlanVentaComplejo_Postgres()
        {
            return new PlanVentaComplejoRepository(new PlanVentaComplejo(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanVentaComplejoRepository PlanVentaComplejo_Local()
        {
            return new PlanVentaComplejoRepository(new PlanVentaComplejo(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
        public static PlanVentaTiendaRepository PlanVentaTienda_Postgres()
        {
            return new PlanVentaTiendaRepository(new PlanVentaTienda(), VariablesEntorno.conectionStringPostgres, TipoBaseDatos.Postgres);
        }
        public static PlanVentaTiendaRepository PlanVentaTienda_Local()
        {
            return new PlanVentaTiendaRepository(new PlanVentaTienda(), VariablesEntorno.conectionStringLocal, TipoBaseDatos.Local);
        }
    }
}
