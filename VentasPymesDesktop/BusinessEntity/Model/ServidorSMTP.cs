using Database;
using Database.Class;
using ModelData.Atributo;
using System.Data.Common;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ModelData.Model
{  
    public class ServidorSMTP : BaseModelPro<ServidorSMTP, int>, ISincronizable<ServidorSMTP, int>
    {     
        public Atributo<int> puerto { get; set; } = new Atributo<int>("puerto");
        public Atributo_Email usuarioServidor { get; set; } = new Atributo_Email("email_remitente");
        public Atributo<string> servidor { get; set; } = new Atributo<string>("servidor");
        public Atributo<string> password { get; set; } = new Atributo<string>("password");
        public ServidorSMTP(string tokenId) : base(tokenId)
        {            
              
        }
        public ServidorSMTP()
        {
            setTabla();
        }
        public ServidorSMTP(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.puerto.setValue(sqlReader);
            this.servidor.setValue(sqlReader);
            this.usuarioServidor.setValue(sqlReader);
            this.password.setValue(sqlReader);
        }
        public bool validar()
        {
            if (password.Value == "") return false;
            if (servidor.Value == "") return false;         
            if (puerto.Value == 0) return false;
            if (!usuarioServidor.isValido()) return false;
            return true;
        }
        public override string ToString()
        {
            return usuarioServidor.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("servidor_smtp", "smtp");
        }
    }   
}
