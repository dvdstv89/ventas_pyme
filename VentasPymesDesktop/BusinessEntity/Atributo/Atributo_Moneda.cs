using Database.Class;
using ModelData.Model;
using System.Data.Common;

namespace ModelData.Atributo
{
    public class Atributo_Moneda : Atributo_Objeto_FK<Moneda,int>
    {     
        public Atributo_Moneda(string columnName) :base(columnName)
        {
           
        }
        public Atributo_Moneda(Moneda value, string columnName): base(value, columnName)
        {
           
        }
        public new void setValue(DbDataReader reader)
        {
            base.setValue(reader);
            this.Objeto = MonedaData.getMonedaById(getValueAsInt());
        }
    }
}
