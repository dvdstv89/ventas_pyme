using Database.Class;
using ModelData.Model;
using System.Data.Common;

namespace ModelData.Atributo
{
    public class Atributo_Complejo : Atributo_Objeto_FK<Complejo, int>
    {     
        public Atributo_Complejo(string columnName) :base(columnName)
        {
           
        }
        public Atributo_Complejo(Complejo value, string columnName): base(value, columnName)
        {
           
        }
        public new void setValue(DbDataReader reader)
        {
            base.setValue(reader);
            this.Objeto = ComplejoData.getComplejoById(getValueAsInt());
        }
    }
}
