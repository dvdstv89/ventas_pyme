using Database;
using Database.Class;
using System.Data.Common;

namespace ModelData.Model
{    
    public class Configuracion : BaseModelPro<Configuracion, int>, ISincronizable<Configuracion, int>
    {       
        public Atributo<string> urlApiRest { get; set; } = new Atributo<string>("url_api_rest");
        public Atributo_ConectionString stringPostgresDb { get; set; } = new Atributo_ConectionString("string_postgres_db");       
        public Configuracion()
        {
            setTabla();
        }
        public Configuracion(DbDataReader sqlReader) : base(sqlReader, TipoBaseDatos.Local)
        {          
            this.id.setValue(sqlReader);
            this.urlApiRest.setValue(sqlReader);
            this.stringPostgresDb.setValue(sqlReader);         
        }
        protected new void setTabla()
        {
            tabla = new Tabla("configuracion", "cof");
        }
    }
}
