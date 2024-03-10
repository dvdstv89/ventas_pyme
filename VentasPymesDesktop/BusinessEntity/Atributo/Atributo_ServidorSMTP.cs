using Database.Class;
using ModelData.Model;
using System.Data.Common;

namespace ModelData.Atributo
{
    public class Atributo_ServidorSMTP : Atributo_Objeto_FK<ServidorSMTP, int>
    {     
        public Atributo_ServidorSMTP(string columnName) :base(columnName)
        {
           
        }
        public Atributo_ServidorSMTP(ServidorSMTP value, string columnName): base(value, columnName)
        {
           
        }
        public new void setValue(DbDataReader reader)
        {
            base.setValue(reader);
            this.Objeto = ServidorSmtpData.getServidorSmtpById(getValueAsString());
        }
    }
}
