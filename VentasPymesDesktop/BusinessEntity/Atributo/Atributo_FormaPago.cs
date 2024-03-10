using Database.Class;
using ModelData.Model;
using System.Data.Common;

namespace ModelData.Atributo
{
    public class Atributo_FormaPago : Atributo_Objeto_FK<FormaPago,int>
    {     
        public Atributo_FormaPago(string columnName) :base(columnName)
        {
           
        }
        public Atributo_FormaPago(FormaPago value, string columnName): base(value, columnName)
        {
           
        }
        public new void setValue(DbDataReader reader)
        {
            base.setValue(reader);
            this.Objeto = FormaPagoData.getFormaPagoById(getValueAsString());
        }
    }
}
