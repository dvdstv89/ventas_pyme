using System.Data.Common;
using GlobalContracts.Model;
using GlobalContracts.Interface;
using GlobalContracts.Atributos;
using GlobalContracts.Model.Mensaje;
using GlobalContracts.Enum;

namespace ExternalSystem.Model
{   
    public class DatabaseChangeLog : BaseModel<DatabaseChangeLog>, IGestionable
    {
        public Atributo_Datetime dateExecuted { get; set; } = new Atributo_Datetime("dateexecuted");
        public Atributo<bool> executed { get; set; } = new Atributo<bool>("executed");
        public Atributo<string> description { get; set; } = new Atributo<string>("description");
        public Atributo<string> code { get; set; } = new Atributo<string>("code");
        public Atributo<double> version { get; set; } = new Atributo<double>("version");
        public Atributo<string> app { get; set; } = new Atributo<string>("app");
        public DatabaseChangeLog()
        {
            initI18n();
        }
        public DatabaseChangeLog(DbDataReader sqlReader) : base(sqlReader)
        {
            this.dateExecuted.setValue(sqlReader);
            this.executed.setValue(sqlReader);
            this.description.setValue(sqlReader);
            this.code.setValue(sqlReader);
            initI18n();
        }           
        protected override void setTabla()
        {
            tabla = new Tabla("databasechangelog", "dblog");
        }       
        protected override void setNameByUI()
        {
            nameByUI = new Mensaje(MensajeType.Title, "Registro de cambios BD", "Changes Logs DB");
        }  
        public override string getCreateTableScript()
        {
            return base.getCreateTableScript() +
                "\"dateexecuted\" varchar(255) NOT NULL," +
                "\"executed\" bool NOT NULL DEFAULT false," +
                "\"description\" varchar(255) NOT NULL," +
                "\"code\" varchar NOT NULL," +
                "PRIMARY KEY (\"id\")" +
                ");";
        }       
    }    
}
